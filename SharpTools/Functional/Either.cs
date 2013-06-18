using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTools.Functional.Either
{
    interface IEither<A, B>
    {
        bool Left(out A value);
        bool Right(out B value);
    }

    abstract public class Either<A, B>
    {
        public bool Left(out A value)
        {
            value = default(A);
            return false;
        }

        public bool Right(out B value)
        {
            value = default(B);
            return false;
        }
    }

    public static class Either
    {
        public static Either<A, B> Left<A, B>(A left)
        {
            return new Left<A, B>(left);
        }

        public static Either<A, B> Right<A, B>(B right)
        {
            return new Right<A, B>(right);
        }

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

    public class Left<A, B> : Either<A, B>
    {
        private A value = default(A);

        public Left(A value)
        {
            this.value = value;
        }

        public override bool Left(out A value)
        {
            value = this.value;
            return true;
        }
    }

    public class Right<A, B> : Either<A, B>
    {
        private B value = default(B);

        public Right(B value)
        {
            this.value = value;
        }

        public override bool Right(out B value)
        {
            value = this.value;
            return true;
        }
    }
}
