using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTools.Utils.Async
{
    public static class TaskExtensions
    {
        public static void Sync(this Task self)
        {
            self.RunSynchronously();
        }

        public static T Sync<T>(this Task<T> self)
        {
            self.Sync();
            return self.Result;
        }
    }
}
