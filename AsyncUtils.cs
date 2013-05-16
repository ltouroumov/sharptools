using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Async
{
    public static class TaskExtensions
    {
        public static T Await<T>(this Task<T> self)
        {
            self.Wait();
            return self.Result;
        }
    }
}
