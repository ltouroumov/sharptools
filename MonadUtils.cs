using System;

namespace Utils.Monads
{
    public interface IMaybe { }

    public class Maybe<T> : IMaybe
    {
    }

    public class Just<T> : Maybe<T>
    {
        public T Value { get; private set; }
        public Just(T value)
        {
            this.Value = value;
        }
    }

    public class Nothing<T> : Maybe<T>
    {
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
            if (value == null)
            {
                return Just(value);
            }
            else
            {
                return Nothing<A>();
            }
        }

        public static Func<A, C> Compose<A, B, C>(this Func<A, B> func1, Func<B, C> func2)
        {
            return (a) => func2(func1(a));
        }

        public static Func<B> Partial<A, B>(this Func<A, B> oldFunc, A a)
        {
            return () => oldFunc(a);
        }

        public static Func<A, C> Partial<A, B, C>(this Func<A, B, C> oldfunc, B b)
        {
            return (a) => oldfunc(a, b);
        }

        public static Func<A, Func<B, C>> Curry<A, B, C>(this Func<A, B, C> func)
        {
            return a => b => func(a, b);
        }
    }

    public static class MonadExtensions
    {
        public static Maybe<A> ToMaybe<A>(this A self)
        {
            return new Just<A>(self);
        }

        public static Maybe<A> ToMaybe<A>(this Maybe<A> self)
        {
            return self;
        }

        public static B Bind<A, B>(this A self, Func<A, B> binder)
        {
            return binder(self);
        }

        public static Maybe<B> Bind<A, B>(this Maybe<A> self, Func<A, Maybe<B>> binder)
        {
            var justa = self as Just<A>;
            return justa == null ?
                new Nothing<B>() :
                binder(justa.Value);
        }

        public static Maybe<B> BindValue<A, B>(this Maybe<A> self, Func<A, B> binder)
        {
            var justa = self as Just<A>;
            return justa == null ?
                new Nothing<B>() :
                Monad.Maybe(binder(justa.Value));
        }

        public static void Bind<A>(this Maybe<A> self, Action<A> binder)
        {
            if (self is Just<A>)
            {
                var just = self as Just<A>;
                binder.Invoke(just.Value);
            }
        }

        public static Maybe<A> WhenNothing<A>(this Maybe<A> self, Action<Maybe<A>> trigger)
        {
            if (self is Nothing<A>)
            {
                trigger.Invoke(self);
            }

            return self;
        }

        public static A Value<A>(this Maybe<A> self)
        {
            if (self is Nothing<A>)
            {
                throw new NullReferenceException("Maybe monad was expecting a value but was Nothing instead");
            }

            return (self as Just<A>).Value;
        }
    }
}