using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SharpTools.Functional;
using SharpTools.Functional.Option;

namespace SharpTools.Xml
{
    static class StateExtensions
    {
        public static bool IsElement(this XmlReader self, string nodeName)
        {
            return self.Name == nodeName && self.NodeType == XmlNodeType.Element;
        }

        public static Func<XmlReader, bool> MakeElementScannerGuard(this XmlReader self, bool useDepth = true)
        {
            var depth = self.Depth;
            var name = self.Name;

            return (xml) => (useDepth && xml.Depth <= depth) || (xml.NodeType == XmlNodeType.EndElement && xml.Name == name);
        }
    }
}
