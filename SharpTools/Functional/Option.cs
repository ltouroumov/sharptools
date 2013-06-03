using System;

namespace SharpTools.Functional.Option
{
    public interface IOption<A>
    {
        A ToValue();
        IOption<B> Bind<B>(Func<A, IOption<B>> binder);
    }

    public interface ISome<A> : IOption<A>
    {
        A Value { get; }
    }

    public interface INothing<A> : IOption<A>
    {

    }

    // <summary>
    // Represents a result with the potential for a value
    // </summary>
    public abstract class Option<A> : IOption<A>
    {
        public virtual A ToValue()
        {
            throw MakeException("ToValue");
        }

        public IOption<B> Bind<B>(Func<A, IOption<B>> binder)
        {
            return this.Bind(binder) as IOption<B>;
        }

        public abstract Option<B> Bind<B>(Func<A, Option<B>> binder);
        public abstract Option<A> Bind(Action<A> binder);
        public abstract Option<A> WhenNothing(Action binder);

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

    // <summary>
    // Represents the presentce of value
    // </summary>
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

        public override Option<A> WhenNothing(Action binder)
        {
            return this;
        }
    }

    // <summary>
    // Represents the absence of value
    // </summary>
    public class Nothing<A> : Option<A>, INothing<A>
    {
        public override A ToValue()
        {
            return default(A);
            // This doesnt sound like a good idea
            // throw new InvalidOperationException("A Nothing monad cannot be converted to a value");
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
    }

    public static class Some
    {
        public static Some<A> New<A>(A value)
        {
            return new Some<A>(value);
        }
    }

    public static class Nothing
    {
        public static Nothing<A> New<A>()
        {
            return new Nothing<A>();
        }
    }

    public static partial class Option
    {
        public static Option<A> New<A>(A value)
        {
            return New(value, val => val != null);
        }

        public static Option<A> New<A>(A value, Func<A, bool> discriminator)
        {
            if (discriminator(value)) {
                return Some.New(value);
            } else {
                return Nothing.New<A>();
            }
        }

        public static Func<A, Option<A>> Identity<A>()
        {
            return a => Option.New(a);
        }

        public static Func<A, Option<A>> Void<A>()
        {
            return a => Nothing.New<A>();
        }
    }

    public static class MonadExtensions
    {
        public static Option<A> ToMaybe<A>(this A self)
        {
            return Option.New(self);
        }

        public static Option<A> ToMaybe<A>(this Option<A> self)
        {
            return self;
        }

        public static Option<C> BindWith<A, B, C>(this Option<A> option1, Option<B> option2, Func<A, B, Option<C>> binder)
        {
            return option1.Bind(val1 => option2.Bind(val2 => binder(val1, val2)));
        }

        public static A ToValueOrDefault<A>(this Option<A> self)
        {
            if (self is Nothing<A>) {
                return default(A);
            } else {
                return (self as Some<A>).Value;
            }
        }

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
