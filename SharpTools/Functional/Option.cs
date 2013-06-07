using System;

namespace SharpTools.Functional.Option
{
    /// <summary>
    /// Base interface for the Option type. Allows other types to act as an option type without extending the base class
    /// </summary>
    /// <typeparam name="A">Type of the wrapped value</typeparam>
    public interface IOption<A>
    {
        /// <summary>
        /// Converts the Option type to a value.
        /// </summary>
        /// <returns>Wrapped value</returns>
        /// <exception cref="InvalidOperationException" />
        A ToValue();

        /// <summary>
        /// Binds the Option type.
        /// When the type is ISome the binder is called and expects an Option as an output.
        /// When the type is INothing the binder is NOT called and instead a INothing of the new type is returned
        /// </summary>
        /// <typeparam name="B">Return type of the binder function</typeparam>
        /// <param name="binder">Function to be called when the value is ISome</param>
        /// <returns>New Option type</returns>
        IOption<B> Bind<B>(Func<A, IOption<B>> binder);
    }

    /// <summary>
    /// Objects that implement this interface are an option type which carry a value
    /// </summary>
    /// <typeparam name="A"></typeparam>
    public interface ISome<A> : IOption<A>
    {
        /// <summary>
        /// Value wrapped by the option type
        /// </summary>
        A Value { get; }
    }


    /// <summary>
    /// Objects that implement this interface are an option type which carries no value.
    /// </summary>
    /// <typeparam name="A"></typeparam>
    public interface INothing<A> : IOption<A>
    {

    }

    /// <summary>
    /// Concrete implementation of the IOption type.
    /// </summary>
    /// <typeparam name="A"><see cref="IOption"/></typeparam>
    public abstract class Option<A> : IOption<A>
    {
        public virtual A ToValue()
        {
            throw MakeException("ToValue");
        }

        /// <summary>
        /// Implementation of <see cref="IOption.Bind"/>
        /// </summary>
        /// <typeparam name="B"></typeparam>
        /// <param name="binder"></param>
        /// <returns></returns>
        public IOption<B> Bind<B>(Func<A, IOption<B>> binder)
        {
            return this.Bind(binder) as IOption<B>;
        }

        /// <summary>
        /// Works the same as <see cref="IOption.Bind"/>
        /// </summary>
        /// <typeparam name="B">New wrapped value</typeparam>
        /// <param name="binder">Binding callback</param>
        /// <returns>New Option type</returns>
        public abstract Option<B> Bind<B>(Func<A, Option<B>> binder);

        /// <summary>
        /// Binds a void function and returns self.
        /// </summary>
        /// <param name="binder">Binding callback</param>
        /// <returns>self</returns>
        public abstract Option<A> Bind(Action<A> binder);

        /// <summary>
        /// This method is the reverse of Bind, the binder is invoked when INothing is encountered.
        /// </summary>
        /// <param name="binder">Binding callback</param>
        /// <returns>self</returns>
        public abstract Option<A> WhenNothing(Action binder);

        /// <summary>
        /// This method is tasked to provide a fallback value in case it encounters a Nothing value.
        /// </summary>
        /// <param name="binder">Value provider</param>
        /// <returns>A value</returns>
        public abstract Option<A> Fallback(Func<Option<A>> binder);

        protected virtual InvalidOperationException MakeException(string method = null)
        {
            Type type = this.GetType();
            string message;
            if (method != null) {
                message = string.Format("Maybe({0}) does not support {1}", type.Name, method);
            } else {
                message = string.Format("Invalid operation on Maybe({0})", type.Name);
            }

            return new InvalidOperationException(message);
        }
    }

    /// <summary>
    /// Implementation of Option and ISome
    /// </summary>
    /// <typeparam name="A">Wrapped value</typeparam>
    public class Some<A> : Option<A>, ISome<A>
    {
        public A Value { get; private set; }
        public Some(A value)
        {
            this.Value = value;
        }

        public override A ToValue()
        {
            return Value;
        }

        public override Option<B> Bind<B>(Func<A, Option<B>> binder)
        {
            return binder(Value);
        }

        public override Option<A> Bind(Action<A> binder)
        {
            binder(Value);
            return this;
        }

        // Polymorphism is awesome
        public override Option<A> WhenNothing(Action binder)
        {
            return this;
        }

        public override Option<A> Fallback(Func<Option<A>> binder)
        {
            return this;
        }
    }

    /// <summary>
    /// Implementation of Option and INothing
    /// </summary>
    /// <typeparam name="A">Wrapped value</typeparam>
    public class Nothing<A> : Option<A>, INothing<A>
    {
        public override A ToValue()
        {
            // Return the default value for the wrapped type
            return default(A);
        }

        public override Option<B> Bind<B>(Func<A, Option<B>> binder)
        {
            return Nothing.New<B>();
        }

        public override Option<A> Bind(Action<A> binder)
        {
            return this;
        }

        public override Option<A> WhenNothing(Action binder)
        {
            binder();
            return this;
        }

        public override Option<A> Fallback(Func<Option<A>> binder)
        {
            return binder();
        }
    }

    /// <summary>
    /// Static class to allow easy creation of Some type
    /// </summary>
    public static class Some
    {
        public static Some<A> New<A>(A value)
        {
            return new Some<A>(value);
        }
    }

    /// <summary>
    /// Static class to allow easy creation of Nothing type
    /// </summary>
    public static class Nothing
    {
        public static Nothing<A> New<A>()
        {
            return new Nothing<A>();
        }
    }


    /// <summary>
    /// Static class to allow easy creation of Option types
    /// </summary>
    public static partial class Option
    {
        /// <summary>
        /// Builds a new Option type based on null check
        /// </summary>
        /// <typeparam name="A">Wrapped value type</typeparam>
        /// <param name="value">Value to wrap</param>
        /// <returns>Wrapped value</returns>
        public static Option<A> New<A>(A value)
        {
            return New(value, val => val != null);
        }

        /// <summary>
        /// Builds a new Option type based on a discriminator function.
        /// When the discriminator returns true the value is a Some else the value is Nothing
        /// </summary>
        /// <typeparam name="A">Wrapped value type</typeparam>
        /// <param name="value">Value to wrap</param>
        /// <param name="discriminator">Discriminator function</param>
        /// <returns>Wrapped value</returns>
        public static Option<A> New<A>(A value, Func<A, bool> discriminator)
        {
            if (discriminator(value)) {
                return Some(value);
            } else {
                return Nothing<A>();
            }
        }

        /// <summary>
        /// Create a new Some<A> boxed as Option<A>
        /// </summary>
        /// <typeparam name="A">Wrapped value type</typeparam>
        /// <param name="value">Value to wrap</param>
        public static Option<A> Some<A>(A value)
        {
            return SharpTools.Functional.Option.Some.New(value);
        }

        /// <summary>
        /// Create a new Nothing<A> boxed as Option<A>
        /// </summary>
        /// <typeparam name="A">Wrapped value type</typeparam>
        public static Option<A> Nothing<A>()
        {
            return SharpTools.Functional.Option.Nothing.New<A>();
        }

        /// <summary>
        /// Returns a function that works as an identity to transform its input arguments into Option types.
        /// </summary>
        /// <typeparam name="A">Wrappable type</typeparam>
        /// <returns>Wrapper funtion</returns>
        public static Func<A, Option<A>> Identity<A>()
        {
            return a => Option.New(a);
        }

        /// <summary>
        /// Returns a function that returns only Nothing.
        /// </summary>
        /// <typeparam name="A">Wrappable type</typeparam>
        /// <returns>Function that returns Nothing</returns>
        public static Func<A, Option<A>> Void<A>()
        {
            return a => Nothing<A>();
        }
    }

    public static class MonadExtensions
    {
        /// <summary>
        /// Will transform any value to an Option type
        /// </summary>
        /// <typeparam name="A">Value type</typeparam>
        /// <param name="self">value to wrap</param>
        /// <returns>Wrapped value</returns>
        public static Option<A> ToOption<A>(this A self)
        {
            return Option.New(self);
        }

        /// <summary>
        /// Attempting to wrap an Option type will return an option type.
        /// </summary>
        /// <typeparam name="A"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Option<A> ToOption<A>(this Option<A> self)
        {
            return self;
        }

        /// <summary>
        /// Double binding function. Allows a couple of Option types to be chained with Bind.
        /// </summary>
        /// <typeparam name="A">First wrapped type</typeparam>
        /// <typeparam name="B">Second wrapped type</typeparam>
        /// <typeparam name="C">return wrapped type</typeparam>
        /// <param name="option1">First option type</param>
        /// <param name="option2">Second option type</param>
        /// <param name="binder">Combined binder</param>
        /// <returns>Bound value</returns>
        public static Option<C> BindWith<A, B, C>(this Option<A> option1, Option<B> option2, Func<A, B, Option<C>> binder)
        {
            return option1.Bind(val1 => option2.Bind(val2 => binder(val1, val2)));
        }

        /// <summary>
        /// Will get the value of Some types and the type's default value for Nothing
        /// </summary>
        /// <typeparam name="A">Wrapped value type</typeparam>
        /// <param name="self">Option value</param>
        /// <returns>Unwrapped value</returns>
        public static A ToValueOrDefault<A>(this Option<A> self)
        {
            if (self is Nothing<A>) {
                return default(A);
            } else {
                return (self as Some<A>).Value;
            }
        }

        /// <summary>
        /// Will get the value of Some types and invoke the provider for Nothing types
        /// </summary>
        /// <typeparam name="A">Wrapped value type</typeparam>
        /// <param name="self">Option value</param>
        /// <param name="provider">Fallback callback</param>
        /// <returns>Unwrapped value</returns>
        public static A ToValueOrDefault<A>(this Option<A> self, Func<A> provider)
        {
            if (self is Nothing<A>) {
                return provider();
            } else {
                return (self as Some<A>).Value;
            }
        }
    }
}
