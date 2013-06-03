using System;

namespace SharpTools.Functional
{
    public static class Function
    {
        // <summary>
        // Provides an identity operation for functions
        // </summary>
        public static Func<A, A> Identity<A>()
        {
            return a => a;
        }

        // <summary>
        // Create a function that returns a specific value
        // </summary>
        public static Func<A> Unit<A>(A value)
        {
            return () => value;
        }
    }

    // <summary>
    // Allows to compose two functions together
    // </summary>
    public static class FuncCompositionExtensions
    {
        public static Func<A, C> Compose<A, B, C>(this Func<B, C> func1, Func<A, B> func2)
        {
            return (a) => func1(func2(a));
        }
        
        public static Action<B> Compose<A, B>(this Action<A> func1, Func<B, A> func2)
        {
            return (a) => func1(func2(a));
        }

        public static Func<A, C> AndThen<A, B, C>(this Func<A, B> func1, Func<B, C> func2)
        {
            return (a) => func2(func1(a));
        }
        
        public static Action<A> AndThen<A, B>(this Func<A, B> func1, Action<B> func2)
        {
            return (a) => func2(func1(a));
        }

        public static Action AndThen(this Action func1, Action func2)
        {
            return () => { func1(); func2(); };
        }
    }
}
