using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SharpTools.Functional;
using SharpTools.Functional.Option;

namespace SharpTools.Xml
{
    public static class TextPrimitivesExtension
    {
        /// <summary>
        /// Reads all contiguos text nodes and returns their value.
        /// </summary>
        /// <returns>Some(Text value)</returns>
		public static IOption<string> ReadText(this XmlReader self)
        {
            if (self.NodeType != XmlNodeType.Text) return Nothing.New<string>();

            var sb = new StringBuilder();
            self.ReadUntil(
                x => x.NodeType != XmlNodeType.Text,
                x => sb.Append(x.Value));

            return Option.New(sb.ToString());
        }

        /// <summary>
        /// Reads the text content of a named node and return its value.
        /// This method returns a Nothing object if the cursor is not on the start of the node.
        /// A transformer method must be supplied to parse the returned text.
        /// </summary>
        /// <typeparam name="A">Type of the contents</typeparam>
        /// <param name="nodeName">Name of the node</param>
        /// <param name="transformer">Text parser</param>
        /// <returns>Some(Parsed value) | Nothing</returns>
		public static IOption<A> ScalarNode<A>(this XmlReader self, string nodeName, Func<string, A> transformer)
        {
            if (!self.IsElement(nodeName) || self.IsEmptyElement) return Nothing.New<A>();

            var buffer = new StringBuilder();
            self.ReadUntil(
                self.MakeElementScannerGuard(useDepth: false),
                x => buffer.Append(x.Value));

            var returnValue = buffer.ToString();
            return Option.New(transformer(returnValue));
        }

        /// <summary>
        /// Runs the <see cref="ScalarNode"/> method and returns the raw string contents.
        /// </summary>
        /// <param name="nodeName">Name of the node</param>
        /// <returns>Some(Text value) | Nothing</returns>
		public static IOption<string> ScalarNode(this XmlReader self, string nodeName)
        {
            return ScalarNode<string>(self, nodeName, Function.Identity<string>());
        }

		public static IOption<A> ScalarAttribute<A>(this XmlReader self, string attrName, Func<string, A> transformer)
		{
			var attrValue = self.GetAttribute(attrName);
			if (attrValue != null) {
				return Option.Some(transformer(attrValue));
			}
			return Option.Nothing<A>();
		}
    }
}
