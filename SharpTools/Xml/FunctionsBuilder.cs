using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SharpTools.Functional;
using SharpTools.Functional.Option;

namespace SharpTools.Xml
{
    static class FunctionsBuilder
    {
        public static Func<XmlReader, T> MakeTextReaderBuilder<T>(Func<XmlReader, T> builder, Action<string, T> text = null, bool hasContent = true)
        {
            return (xml) => {
                var item = builder(xml);
                if (text != null && hasContent) {
                    xml.ReadCurrentNode(reader => {
                        reader.ReadText().Bind(text.Partial(item));
                    });
                }
                return item;
            };
        }

        public static Func<XmlReader, T> MakeIterableItemBuilder<T>(Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
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
