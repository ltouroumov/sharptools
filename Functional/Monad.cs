using System;

namespace SharpTools.Functional.Monads
{
    // <summary>
    // Represents a result with the potential for a value
    // </summary>
    public abstract class Maybe<A>
    {
        public virtual A ToValue()
        {
            throw MakeException("ToValue");
        }

        public virtual Maybe<B> Bind<B>(Func<A, Maybe<B>> binder)
        {
            throw MakeException("Bind");
        }

        public virtual Maybe<A> Bind(Action<A> binder)
        {
            throw MakeException("Bind");
        }

        public virtual Maybe<B> WhenNothing<B>(Func<Maybe<B>> binder)
        {
            throw MakeException("WhenNothing");
        }

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
    public class Just<A> : Maybe<A>
    {
        public A Value { get; private set; }
        public Just(A value)
        {
            this.Value = value;
        }

        public override A ToValue()
        {
            return Value;
        }

        public override Maybe<B> Bind<B>(Func<A, Maybe<B>> binder)
        {
            return binder(Value);
        }

        public override Maybe<A> Bind(Action<A> binder)
        {
            binder(Value);
            return this;
        }
    }

    // <summary>
    // Represents the absence of value
    // </summary>
    public class Nothing<A> : Maybe<A>
    {
        public override A ToValue()
        {
            return default(A);
        }

        public override Maybe<B> WhenNothing<B>(Func<Maybe<B>> binder)
        {
            return binder();
        }
    }

    public static partial class Monad
    {
        public static Maybe<A> Nothing<A>()
        {
            return new Nothing<A>();
        }

        public static Maybe<A> Just<A>(A value)
        {
            return new Just<A>(value);
        }

        public static Maybe<A> Maybe<A>(A value)
        {
            if (value == null) {
                return Nothing<A>();
            } else {
                return Just(value);
            }
        }

        public static Func<A, Maybe<A>> Identity<A>()
        {
            return a => Monad.Maybe(a);
        }

        public static Func<A, Maybe<A>> Void<A>()
        {
            return a => Monad.Nothing<A>();
        }
    }

    public static class MonadExtensions
    {
        public static Maybe<A> ToMaybe<A>(this A self)
        {
            return Monad.Maybe(self);
        }

        public static Maybe<A> ToMaybe<A>(this Maybe<A> self)
        {
            return self;
        }
    }
}