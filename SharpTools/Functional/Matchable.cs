using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTools.Functional.Matchable
{
    interface IMatchable<A, B>
    {
        void Match(Action<A> func1, Action<B> func2);
    }
}
