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
        public static void ReadUntil(this XmlReader self, Func<XmlReader, bool> cond, Action<XmlReader> reader = null)
        {
            while (!cond(self)) {
                if (reader != null) reader(self);
                if (!self.Read()) break;
            }
        }

        public static void ReadNode(this XmlReader self, string nodeName, Action<XmlReader> reader)
        {
            if (!self.IsElement(nodeName)) return;

            var currentDepth = self.Depth;

            var guard = self.MakeElementScannerGuard();
            while (self.Read()) {
                // Double guard condition
                if (guard(self)) break;

                reader(self);
                // Prevent braking when using the XmlReader.ReadText() method
                if (guard(self)) break;
            }
        }

        public static void ReadCurrentNode(this XmlReader self, Action<XmlReader> reader)
        {
            self.ReadNode(self.Name, reader);
        }
    }
}
