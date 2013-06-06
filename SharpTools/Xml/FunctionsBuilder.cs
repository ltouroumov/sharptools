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
        /// <summary>
        /// Builds a function that reads a node to convert it to an object using the builder function and text callback.
        /// The hasContent flag can be used to skip the body parsing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">Object builder function</param>
        /// <param name="text">Text callback</param>
        /// <returns>Text teader function</returns>
        public static Func<XmlReader, T> MakeTextReaderBuilder<T>(Func<XmlReader, T> builder, Action<string, T> text = null)
        {
            return (xml) => {
                var item = builder(xml);
                if (text != null) {
                    xml.ReadCurrentNode(reader => {
                        reader.ReadText().Bind(text.Partial(item));
                    });
                }
                return item;
            };
        }

        /// <summary>
        /// Builds a function that reads a node to convert it to an object uing the builder function and iterator callback.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="builder">Object builder function</param>
        /// <param name="iterator">Body iterator</param>
        /// <returns>Object transformer function</returns>
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
