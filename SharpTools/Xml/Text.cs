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
        public static Option<string> ReadText(this XmlReader self)
        {
            if (self.NodeType != XmlNodeType.Text) return Nothing.New<string>();

            var sb = new StringBuilder();
            self.ReadUntil(
                x => x.NodeType != XmlNodeType.Text,
                x => sb.Append(x.Value));

            return sb.ToString().ToMaybe();
        }

        public static Option<A> ScalarNode<A>(this XmlReader self, string nodeName, Func<string, A> transformer)
        {
            if (!self.IsElement(nodeName) || self.IsEmptyElement) return Nothing.New<A>();

            var buffer = new StringBuilder();
            self.ReadUntil(
                self.MakeElementScannerGuard(useDepth: false),
                x => buffer.Append(x.Value));

            var returnValue = buffer.ToString();
            return transformer(returnValue).ToMaybe();
        }

        public static Option<string> ScalarNode(this XmlReader self, string nodeName)
        {
            return ScalarNode<string>(self, nodeName, Function.Identity<string>());
        }

    }
}
