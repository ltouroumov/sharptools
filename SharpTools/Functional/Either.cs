using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpTools.Functional.Matchable;

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
        /// Check and get the left value
        /// </summary>
        /// <param name="value">Left value</param>
        /// <returns>Left value exists</returns>
        bool AsLeft(out A value);

        /// <summary>
        /// Check and get the left value
        /// </summary>
        /// <param name="value">Right value</param>
        /// <returns>Right value exists</returns>
        bool AsRight(out B value);
    }

    /// <summary>
    /// Default implementation of the IEither interface
    /// </summary>
    abstract public class Either<A, B> : IEither<A, B>, IMatchable<A, B>
    {
        virtual public bool AsLeft(out A value)
        {
            value = default(A);
            return false;
        }

        virtual public bool AsRight(out B value)
        {
            value = default(B);
            return false;
        }

        public void Match(Action<A> func1, Action<B> func2)
        {
            this.WhenLeft(func1).WhenRight(func2);
        }
    }

    public static class EitherExtensions
    {
        /// <summary>
        /// Will call func if the left value is defined
        /// </summary>
        public static IEither<A, B> WhenLeft<A, B>(this IEither<A, B> self, Action<A> func)
        {
            A value = default(A);
            if (self.AsLeft(out value))
                func(value);

            return self;
        }

        /// <summary>
        /// Will call func if the right value is defined
        /// </summary>
        public static IEither<A, B> WhenRight<A, B>(this IEither<A, B> self, Action<B> func)
        {
            B value = default(B);
            if (self.AsRight(out value))
                func(value);

            return self;
        }

        internal static IEither<A, B> WhenBoth<A, B>(this IEither<A, B> self, Action<A, B> func)
        {
            var both = self as Both<A, B>;
            if (both != null)
            {
                var a = both.left;
                var b = both.right;
                func(a, b);
            }

            return self;
        }

        /// <summary>
        /// Flips the two operands of a IEither
        /// </summary>
        public static IEither<B, A> Flip<A, B>(this IEither<A, B> self)
        {
            var other = new None<B, A>() as IEither<B, A>;

            self.WhenLeft(left => other = new Right<B, A>(left))
                .WhenRight(right => other = new Left<B, A>(right))
                .WhenBoth((l, r) => other = new Both<B, A>(r, l));

            return other;
        }
    }

    public class Left<A, B> : Either<A, B>
    {
        public A value { get; private set; }

        public Left(A value)
        {
            this.value = value;
        }

        public override bool AsLeft(out A value)
        {
            value = this.value;
            return true;
        }
    }

    public class Right<A, B> : Either<A, B>
    {
        public B value { get; private set; }

        public Right(B value)
        {
            this.value = value;
        }

        public override bool AsRight(out B value)
        {
            value = this.value;
            return true;
        }
    }

    public class Both<A, B> : Either<A, B>
    {
        public A left { get; private set; }
        public B right { get; private set; }

        public Both(A left, B right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool AsLeft(out A value)
        {
            value = this.left;
            return true;
        }

        public override bool AsRight(out B value)
        {
            value = this.right;
            return true;
        }
    }

    public class None<A, B> : Either<A, B>
    {
        public override bool AsLeft(out A value)
        {
            value = default(A);
            return false;
        }

        public override bool AsRight(out B value)
        {
            value = default(B);
            return false;
        }
    }

    public static class Either
    {
        public static EitherBuilder<A> AsLeft<A>(this A left)
        {
            return new EitherBuilder<A>(left);
        }

        public static EitherBuilder<B> AsRight<B>(this B right)
        {
            return new EitherBuilder<B>(right);
        }
    }

    public class EitherBuilder<A>
    {
        private A first;

        internal EitherBuilder(A first)
        {
            this.first = first;
        }

        public Either<A, B> WithRight<B>()
        {
            return new Left<A, B>(first);
        }

        public Either<B, A> WithLeft<B>()
        {
            return new Right<B, A>(first);
        }
    }
}
