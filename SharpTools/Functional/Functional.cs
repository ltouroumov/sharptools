using System;

namespace SharpTools.Functional
{
    public static class Function
    {
        /// <summary>
        /// Provides an identity function which returns its first argument
        /// </summary>
        /// <typeparam name="A">Return and input type</typeparam>
        /// <returns>Identity function</returns>
        public static Func<A, A> Identity<A>()
        {
            return a => a;
        }

        /// <summary>
        /// Creates a function that will always return the same value when invoked
        /// </summary>
        /// <typeparam name="A">Return type</typeparam>
        /// <param name="value">Value to return</param>
        /// <returns>A function</returns>
        public static Func<A> Unit<A>(A value)
        {
            return () => value;
        }

        /// <summary>
        /// Creates a function that will always return the same value when invoked with any parameter.
        /// WARNING: This is a dangerous function.
        /// </summary>
        /// <typeparam name="A">Return and input type</typeparam>
        /// <param name="value">Value to return</param>
        /// <returns>A function</returns>
        public static Func<A, A> BlackholeUnit<A>(A value)
        {
            return a => value;
        }
    }

    /// <summary>
    /// Various functions to group other functions together
    /// </summary>
    public static class FuncCompositionExtensions
    {
        /// <summary>
        /// Will compose f with g as <code>x -> f(g(x))</code>.
        /// </summary>
        /// <param name="f">First function</param>
        /// <param name="g">Second function</param>
        /// <returns>Composed function</returns>
        public static Func<A, C> Compose<A, B, C>(this Func<B, C> f, Func<A, B> g)
        {
            return (a) => f(g(a));
        }


        /// <summary>
        /// Will compose f with g as <code>x -> f(g(x))</code>. In which f has no return type.
        /// </summary>
        /// <param name="f">First function</param>
        /// <param name="g">Second function</param>
        /// <returns>Composed function</returns>
        public static Action<B> Compose<A, B>(this Action<A> f, Func<B, A> g)
        {
            return (a) => f(g(a));
        }

        /// <summary>
        /// Will compose f with g as <code>x -> g(f(x))</code>.
        /// </summary>
        /// <param name="f">First function</param>
        /// <param name="g">Second function</param>
        /// <returns>Composed function</returns>
        public static Func<A, C> AndThen<A, B, C>(this Func<A, B> f, Func<B, C> g)
        {
            return (a) => g(f(a));
        }

        /// <summary>
        /// Will compose f with g as <code>x -> g(f(x))</code>. In which g has no return type.
        /// </summary>
        /// <param name="f">First function</param>
        /// <param name="g">Second function</param>
        /// <returns>Composed function</returns>
        public static Action<A> AndThen<A, B>(this Func<A, B> f, Action<B> g)
        {
            return (a) => g(f(a));
        }

        /// <summary>
        /// Will chain two parameterless functions
        /// </summary>
        /// <param name="f">First function</param>
        /// <param name="g">Second function</param>
        /// <returns>Composed function</returns>
        public static Action AndThen(this Action f, Action g)
        {
            return () => { f(); g(); };
        }
    }
}
