using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SharpTools.Functional.Matchable;

namespace SharpTools.Functional.Option
{
    /// <summary>
    /// Base interface for the Option type. Allows other types to act as an option type without extending the base class
    /// </summary>
    /// <typeparam name="A">Type of the wrapped value</typeparam>
    public interface IOption<A> : IEnumerable<A>
    {
		/// <summary>
		/// Gets underlyig the value.
		/// </summary>
		/// <exception cref="InvalidOperationException">If IsDefined is false</exception>
		/// <value>The underlying value.</value>
		A Value { get; }

		/// <summary>
		/// Determines whether this instance is defined.
		/// </summary>
		/// <returns><c>true</c> if this instance is defined; otherwise, <c>false</c>.</returns>
		bool IsDefined { get; }

		/// <summary>
		/// Provides an alternative when this option is not defined
		/// </summary>
		/// <returns>The option OR the alternative if it is not defined</returns>
		/// <param name="alternative">The alternative provider</param>
		IOption<A> OrElse(Func<IOption<A>> alternative);

		/// <summary>
		/// Returns null when the Option is not defined
		/// </summary>
		/// <returns>value OR null</returns>
		A OrNull();

		/// <summary>
		/// Fold the Option type, retreiving a value.
		/// </summary>
		/// <param name="alternative">Alternative provider</param>
		/// <param name="mapper">Mapper function</param>
		B Fold<B>(Func<B> alternative, Func<A, B> mapper);

		/// <summary>
		/// Filter the option returning itself OR None.
		/// </summary>
		/// <param name="filter">Filtering function</param>
		IOption<A> Filter(Func<A, bool> filter);

        /// <summary>
        /// Binds the Option type.
        /// When the type is Some the binder is called and expects an Option as an output.
        /// When the type is Nothing the binder is NOT called and instead a None of the new type is returned
        /// </summary>
        /// <typeparam name="B">Return type of the binder function</typeparam>
        /// <param name="binder">Function to be called when the value is Some</param>
        /// <returns>New Option type</returns>
        IOption<B> FlatMap<B>(Func<A, IOption<B>> mapper);

		/// <summary>
		/// Binds the Option type.
		/// When the type is Some the mapper is called and expects an result as an output.
		/// When the type is Nothing the mapper is NOT called and instead a None of the new type is returned
		/// </summary>
		/// <typeparam name="B">Return type of the mapper function</typeparam>
		/// <param name="binder">Function to be called when the value is Some</param>
		/// <returns>New Option type</returns>
		IOption<B> Map<B>(Func<A, B> mapper);

		IOption<A> MatchSome(Action<A> func);
		IOption<A> MatchNone(Action func);
    }

    /// <summary>
    /// Concrete implementation of the IOption type.
    /// </summary>
    /// <typeparam name="A"><see cref="IOption"/></typeparam>
    internal class Option<A> : IOption<A>
    {
		private A _value = default(A);
		private bool _hasValue = false;

		public Option()
		{
			_hasValue = false;
		}

		public Option(A value)
		{
			_value = value;
			_hasValue = true;
		}

		public bool IsDefined
		{
			get { return _hasValue; }
		}

		public A Value
		{
			get { return GetValueOrException(); }
		}

		private A GetValueOrException()
		{
			if (IsDefined) {
				return _value;
			} else {
				throw new InvalidOperationException("This option type has no value");
			}
		}

		public IOption<A> OrElse(Func<IOption<A>> alternative)
		{
			if (IsDefined) {
				return this;
			} else {
				return alternative();
			}
		}

		public A OrNull()
		{
			if (IsDefined) {
				return _value;
			} else {
				return default(A);
			}
		}

		public B Fold<B>(Func<B> alternative, Func<A, B> mapper)
		{
			if (IsDefined) {
				return mapper(_value);
			} else {
				return alternative();
			}
		}

		public IOption<A> Filter(Func<A, bool> filter)
		{
			if (IsDefined) {
				if (filter(_value)) {
					return this;
				} else {
					return new Option<A>();
				}
			} else {
				return this;
			}
		}

		public IOption<B> FlatMap<B>(Func<A, IOption<B>> mapper)
		{
			if (IsDefined) {
				return mapper(_value);
			} else {
				return new Option<B>();
			}
		}

		public IOption<B> Map<B>(Func<A, B> mapper)
		{
			if (IsDefined) {
				var newVal = mapper(_value);
				return new Option<B>(newVal);
			} else {
				return new Option<B>();
			}
		}

		public IOption<A> MatchSome(Action<A> func)
		{
			if (IsDefined)
				func(_value);

			return this;
		}

		public IOption<A> MatchNone(Action func)
		{
			if (!IsDefined)
				func();

			return this;
		}

		public IEnumerator<A> GetEnumerator()
		{
			if (IsDefined) {
				yield return _value;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (IEnumerator)GetEnumerator();
		}
    }

    /// <summary>
    /// Static class to allow easy creation of Some type
    /// </summary>
    public static class Some
    {
        public static IOption<A> New<A>(A value)
        {
            return new Option<A>(value);
        }
    }

    /// <summary>
    /// Static class to allow easy creation of Nothing type
    /// </summary>
    public static class Nothing
    {
        public static IOption<A> New<A>()
        {
            return new Option<A>();
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
        public static IOption<A> New<A>(A value)
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
        public static IOption<A> New<A>(A value, Func<A, bool> discriminator)
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
        public static IOption<A> Some<A>(A value)
        {
            return SharpTools.Functional.Option.Some.New(value);
        }

        /// <summary>
        /// Create a new Nothing<A> boxed as Option<A>
        /// </summary>
        /// <typeparam name="A">Wrapped value type</typeparam>
        public static IOption<A> Nothing<A>()
        {
            return SharpTools.Functional.Option.Nothing.New<A>();
        }

        /// <summary>
        /// Returns a function that works as an identity to transform its input arguments into Option types.
        /// </summary>
        /// <typeparam name="A">Wrappable type</typeparam>
        /// <returns>Wrapper funtion</returns>
        public static Func<A, IOption<A>> Identity<A>()
        {
            return a => Option.New(a);
        }

        /// <summary>
        /// Returns a function that returns only Nothing.
        /// </summary>
        /// <typeparam name="A">Wrappable type</typeparam>
        /// <returns>Function that returns Nothing</returns>
        public static Func<A, IOption<A>> Void<A>()
        {
            return a => Nothing<A>();
        }
    }

    public static class MonadExtensions
    {
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
		public static IOption<C> Product<A, B, C>(this IOption<A> option1, IOption<B> option2, Func<A, B, C> binder)
        {
            return option1.FlatMap(val1 => option2.Map(val2 => binder(val1, val2)));
        }
    }
}
