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
        /// <summary>
        /// This method wil check is the current node is of type Element (start of element) and of the supplied name.
        /// </summary>
        /// <param name="nodeName">Name of the node</param>
        /// <returns>Whether the cursos is on the requested node</returns>
        public static bool IsElement(this XmlReader self, string nodeName)
        {
            return self.Name == nodeName && self.NodeType == XmlNodeType.Element;
        }

        /// <summary>
        /// Makes a function that checks if the XmlReader is still inside a specified node.
        /// </summary>
        /// <param name="useDepth">Whether or not to check te depth of the node in the guard</param>
        /// <returns>Guard function</returns>
        public static Func<XmlReader, bool> MakeElementScannerGuard(this XmlReader self, bool useDepth = true)
        {
            if (self.NodeType != XmlNodeType.Element) throw new InvalidOperationException("A Scanner guard can only be generated on the beginning of a node");

            var depth = self.Depth;
            var name = self.Name;

            return (xml) => (useDepth && xml.Depth <= depth) || (xml.NodeType == XmlNodeType.EndElement && xml.Name == name);
        }
    }
}
