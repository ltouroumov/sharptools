using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpTools.Functional.Option;

namespace SharpTools.Functional.Either
{
    /// <summary>
    /// Binary value container to allow distinct return types
    /// </summary>
    /// <typeparam name="A">Left branch type</typeparam>
    /// <typeparam name="B">Right branch type</typeparam>
    public interface IEither<A, B>
    {
		/// <summary>
		/// Gets a value indicating whether this instance has a left value.
		/// </summary>
		/// <value><c>true</c> if this instance has a left value; otherwise, <c>false</c>.</value>
		bool HasLeft { get; }
		/// <summary>
		/// Gets a value indicating whether this instance has a right value.
		/// </summary>
		/// <value><c>true</c> if this instance has a right value; otherwise, <c>false</c>.</value>
		bool HasRight { get; }

		/// <summary>
		/// Fold the specified internal value through leftFold and rightFold.
		/// </summary>
		/// <param name="leftFold">Left fold function.</param>
		/// <param name="rightFold">Right fold function.</param>
		/// <typeparam name="C">Final return type.</typeparam>
		C Fold<C>(Func<A, C> leftFold, Func<B, C> rightFold);

		/// <summary>
		/// Maps the left value.
		/// </summary>
		/// <returns>The new IEither.</returns>
		/// <param name="mapper">Mapper function.</param>
		/// <typeparam name="C">New left type.</typeparam>
		IEither<C, B> MapLeft<C>(Func<A, C> mapper);
		/// <summary>
		/// Maps the right value.
		/// </summary>
		/// <returns>The new IEither.</returns>
		/// <param name="mapper">Mapper function.</param>
		/// <typeparam name="C">New right type.</typeparam>
		IEither<A, C> MapRight<C>(Func<B, C> mapper);

		IEither<B, A> Swap();

        /// <summary>
        /// Projects the IEither to the left, returning an IOption compatible object.
        /// </summary>
        /// <returns>Left projection</returns>
        IOption<A> Left();
        /// <summary>
        /// Projects the IEither to the right, returning an IOption compatible object.
        /// </summary>
        /// <returns>Right projection</returns>
        IOption<B> Right();

		IEither<A, B> WhenLeft(Action<A> leftAction);
		IEither<A, B> WhenRight(Action<B> rightAction);
    }

    /// <summary>
    /// Default implementation of the IEither interface
    /// </summary>
    internal class Either<A, B> : IEither<A, B>
    {
		private IOption<A> left;
		private IOption<B> right;

		public bool HasLeft {
			get { return left.IsDefined; }
		}
		public bool HasRight {
			get { return right.IsDefined; }
		}

		internal Either(IOption<A> left, IOption<B> right)
		{
			this.left = left;
			this.right = right;
		}

		public IOption<A> Left()
		{
			return this.left;
		}

		public IOption<B> Right()
		{
			return this.right;
		}

		public C Fold<C>(Func<A, C> leftMapper, Func<B, C> rightMapper)
		{
			return left.Map(leftMapper)
				.OrElse(() => right.Map(rightMapper))
				.Value;
		}

		public IEither<C, B> MapLeft<C>(Func<A, C> mapper)
		{
			return new Either<C, B>(left.Map(mapper), right);
		}

		public IEither<A, C> MapRight<C>(Func<B, C> mapper)
		{
			return new Either<A, C>(left, right.Map(mapper));
		}

		public IEither<B, A> Swap()
		{
			return new Either<B, A>(right, left);
		}

		public IEither<A, B> WhenLeft(Action<A> leftAction)
		{
			left.MatchSome(leftAction);
			return this;
		}

		public IEither<A, B> WhenRight(Action<B> rightAction)
		{
			right.MatchSome(rightAction);
			return this;
		}
    }

    public static class Either
    {
        public static LeftBuilder<A> Left<A>(A value)
		{
			return new LeftBuilder<A>(value);
		}

		public class LeftBuilder<A>
		{
			private A value;
			internal LeftBuilder(A value)
			{
				this.value = value;
			}

			public IEither<A, B> WithRight<B>()
			{
				return new Either<A, B>(Some.New(this.value), None.New<B>());
			}
		}

		public static RightBuilder<A> Right<A>(A value)
		{
			return new RightBuilder<A>(value);
		}

		public class RightBuilder<B>
		{
			private B value;
			internal RightBuilder(B value)
			{
				this.value = value;
			}

			public IEither<A, B> WithLeft<A>()
			{
				return new Either<A, B>(None.New<A>(), Some.New(this.value));
			}
		}

    }
}
