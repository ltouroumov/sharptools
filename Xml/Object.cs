using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SharpTools.Functional;
using SharpTools.Functional.Option;

namespace SharpTools.Xml
{
    public static class ObjectReaderExtension
    {
        public static Option<IList<T>> ObjectNodeList<T>(this XmlReader self, string nodeName, Func<XmlReader, T> transformer)
        {
            //if (self.IsElement(nodeName)) return Nothing.New<IList<T>>();

            var list = new List<T>();

            self.ReadCurrentNode(reader1 => {
                reader1.ObjectNode(nodeName, transformer).Bind(list.Add);
            });

            return Option.New(list as IList<T>, val => val.Count > 0);
        }

        public static Option<IList<T>> ObjectNodeList<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
        {
            return self.ObjectNodeList(nodeName, FunctionsBuilder.MakeIterableItemBuilder(builder, iterator));
        }

        // ---------- ---------- ---------- ---------- ---------- ---------- ---------- ---------- ---------- ----------

        public static Option<T> ObjectNode<T>(this XmlReader self, string nodeName, Func<XmlReader, T> transformer)
        {
            if (!self.IsElement(nodeName)) return Nothing.New<T>();

            return transformer(self).ToMaybe();
        }

        public static Option<T> ObjectNode<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
        {
            return self.ObjectNode(nodeName, FunctionsBuilder.MakeIterableItemBuilder(builder, iterator));
        }

        public static Option<T> ObjectNodeWithContent<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<string, T> text)
        {
            return self.ObjectNode(nodeName, FunctionsBuilder.MakeTextReaderBuilder(builder, text));
        }
    }
}
