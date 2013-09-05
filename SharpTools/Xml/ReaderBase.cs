using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SharpTools.Functional;
using SharpTools.Functional.Option;

namespace SharpTools.Xml
{
    public static class BasicReaderExtensions
    {
        /// <summary>
        /// Advance the reader until the condition is satisfied. If the <code>reader</code> argument is given, it will be yielded the XmlReader at each node.
        /// </summary>
        /// <param name="cond">Condition checker</param>
        /// <param name="reader">Reader callback</param>
        public static void ReadUntil(this XmlReader self, Func<XmlReader, bool> cond, Action<XmlReader> reader = null)
        {
            while (!cond(self)) {
                if (reader != null) reader(self);
                if (!self.Read()) break;
            }
        }

        /// <summary>
        /// Will read an entire Xml Element and yield to the reader at each <code>Read()</code> call
        /// </summary>
        /// <param name="nodeName">Name of the node to read</param>
        /// <param name="reader">Reader callback</param>
        public static void ReadNode(this XmlReader self, string nodeName, Action<XmlReader> reader)
        {
            if (!self.IsElement(nodeName)) return;

            var guard = self.MakeElementScannerGuard();
            while (self.Read()) {
                // Double guard condition
                if (guard(self)) break;

                reader(self);
                // Prevent braking when using the XmlReader.ReadText() method
                if (guard(self)) break;
            }
        }

		public static XmlReader ReadNodeHead(this XmlReader self, string nodeName, Action<XmlReader> reader)
		{
			if (self.IsElement(nodeName))
				reader(self);
			return self;
		}

        /// <summary>
        /// Will read the current node, works the same as <see cref="ReadNode"/>.
        /// </summary>
        /// <param name="reader">Reader callback</param>
        public static void ReadCurrentNode(this XmlReader self, Action<XmlReader> reader)
        {
            self.ReadNode(self.Name, reader);
        }
    }
}
