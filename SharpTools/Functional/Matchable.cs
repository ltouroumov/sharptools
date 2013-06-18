using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTools.Functional.Matchable
{
    /// <summary>
    /// Class that supports the Match function which branches according to the internal state of the class. Option and Either are Match-compatible.
    /// </summary>
    interface IMatchable<A, B>
    {
        /// <summary>
        /// This function will call either func1 OR func2 depending on the class state.
        /// Behavior depends on the implementing class.
        /// </summary>
        void Match(Action<A> func1, Action<B> func2);
    }

    /// <summary>
    /// Linear type contraint implementation of IMatchable
    /// </summary>
    interface ILinearMatchable<A>
    {
        /// <summary>
        /// Behavior depends on the implementing class
        /// </summary>
        /// <param name="funcs"></param>
        void Match(params Action<A> funcs);
    }

    /// <summary>
    /// Supports the tri-state boolean pattern for the IMatchable
    /// </summary>
    interface IMatchable3<A, B, C>
    {
        /// <summary>
        /// Tri-state implementation of IMatchable
        /// </summary>
        void Match(Action<A> func1, Action<B> func2, Action<C> func3);
    }
}
