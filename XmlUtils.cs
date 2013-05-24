﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Utils.Monads;

namespace Utils.Xml
{
    public static class XmlReaderDslExtension
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
            if (self.Name != nodeName || self.NodeType != XmlNodeType.Element) return;
            var currentDepth = self.Depth;

            while (self.Read()) {
                if (self.Depth <= currentDepth) break;
                if (self.NodeType == XmlNodeType.EndElement && self.Name == nodeName) break;
                reader(self);
            }
        }

        public static void ReadCurrentNode(this XmlReader self, Action<XmlReader> reader)
        {
            self.ReadNode(self.Name, reader);
        }

        public static Maybe<string> ReadText(this XmlReader self)
        {
            if (self.NodeType != XmlNodeType.Text) return Monad.Nothing<string>();

            var sb = new StringBuilder();
            ReadUntil(self,
                x => x.NodeType != XmlNodeType.Text,
                x => sb.Append(x.Value));

            return sb.ToString().ToMaybe();
        }

        public static Maybe<string> ScalarNode(this XmlReader self, string nodeName)
        {
            return ScalarNode<string>(self, nodeName, x => x.Trim());
        }

        public static Maybe<A> ScalarNode<A>(this XmlReader self, string nodeName, Func<string, A> transformer)
        {
            if (self.NodeType == XmlNodeType.Element && self.Name == nodeName) {
                var buffer = new StringBuilder();

                if (self.IsEmptyElement) {
                    return Monad.Nothing<A>();
                }

                while (self.Read()) {
                    if (self.NodeType == XmlNodeType.EndElement && self.Name == nodeName) break;

                    buffer.Append(self.Value);
                }

                var returnValue = buffer.ToString();
                return transformer(returnValue).ToMaybe();
            }

            return Monad.Nothing<A>();
        }

        public static IList<T> ObjectNodeList<T>(this XmlReader self, string nodeName, Func<XmlReader, T> transformer)
        {
            var list = new List<T>();

            self.ReadCurrentNode(reader1 => {
                reader1.ObjectNode(nodeName, transformer).Bind(list.Add);
            });

            return list;
        }

        public static IList<T> ObjectNodeList<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
        {
            return self.ObjectNodeList(nodeName, MakeIterableItemBuilder(builder, iterator));
        }

        public static Maybe<T> ObjectNode<T>(this XmlReader self, string nodeName, Func<XmlReader, T> transformer)
        {
            if (self.Name == nodeName && self.NodeType == XmlNodeType.Element) {
                return transformer(self).ToMaybe();
            }

            return Monad.Nothing<T>();
        }

        public static Maybe<T> ObjectNode<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
        {
            return self.ObjectNode(nodeName, MakeIterableItemBuilder(builder, iterator));
        }

        private static Func<XmlReader, T> MakeIterableItemBuilder<T>(Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
        {
            return (xml) => {
                var item = builder(xml);
                xml.ReadCurrentNode(reader => {
                    iterator(reader, item);
                });
                return item;
            };
        }
    }
}