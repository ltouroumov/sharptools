using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SharpTools.Functional;
using SharpTools.Functional.Option;
using SharpTools.Utils.Collections;

namespace SharpTools.Xml
{
    public static class ObjectReaderExtension
    {
        /// <summary>
        /// Will apply <see cref="ObjectNode"/> to all first level child nodes of the currently selected node.
        /// This function returns <see cref="Nothing"/> if the list is empty
        /// </summary>
        /// <typeparam name="T">Type of the list items</typeparam>
        /// <param name="nodeName">Name of child nodes</param>
        /// <param name="transformer">Transformer function</param>
        /// <returns>Some(Lisr of objects) | Nothing</returns>
        public static IOption<IList<T>> ObjectNodeList<T>(this XmlReader self, string nodeName, Func<XmlReader, T> transformer)
        {
            //if (self.IsElement(nodeName)) return Nothing.New<IList<T>>();

            var list = new List<T>();

            self.ReadCurrentNode(reader1 => {
                reader1.ObjectNode(nodeName, transformer).MatchSome(list.Add);
            });

            return Option.New(list as IList<T>, val => val.Count > 0);
        }

        /// <summary>
        /// Will apply <see cref="ObjectNode"/> to all first level child nodes of the currently selected nodes
        /// using the supplied builder and body callback functions (See <see cref="ObjectNode"/> for more informations about builders).
        /// This function returns <see cref="Nothing"/> is the list is empty.
        /// </summary>
        /// <typeparam name="T">Type of the list items</typeparam>
        /// <param name="nodeName">Name of the child nodes</param>
        /// <param name="builder">Object builder function</param>
        /// <param name="iterator">Body callback function</param>
        /// <returns>Some(List of objects) | Nothing</returns>
		public static IOption<IList<T>> ObjectNodeList<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
        {
            return self.ObjectNodeList(nodeName, FunctionsBuilder.MakeIterableItemBuilder(builder, iterator));
        }

        // ---------- ---------- ---------- ---------- ---------- ---------- ---------- ---------- ---------- ----------

        /// <summary>
        /// Converts an XML node to an object using the specified transformer function.
        /// The transformer function is in charge of advancing the cursor until the end of the node.
        /// <remarks>This function is the basis for its overloads.</remarks>
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="nodeName">Name of the XML node</param>
        /// <param name="transformer">Transformer function</param>
        /// <returns>Some(Object) | Nothing</returns>
		public static IOption<T> ObjectNode<T>(this XmlReader self, string nodeName, Func<XmlReader, T> transformer)
        {
            if (!self.IsElement(nodeName)) return None.New<T>();

            return Option.New(transformer(self));
        }

        /// <summary>
        /// Converts an XML node to an object using the specified object builder and body iterator functions.
        /// The object builder function is invoked when the cursor is positioned on the node itself and allows to build an instance of the object using the node's attributes.
        /// The body iterator function is invoked when the cursor advances a node in the reading of the specified node's children,
        /// this function will receive the previously initialized object as a second argument.
        /// The reader's cursor will be automaticaly advanced by using this function.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="nodeName">Name of the XML node</param>
        /// <param name="builder">Object builder function</param>
        /// <param name="iterator">Body callback function</param>
        /// <returns>Some(Object) | Nothing</returns>
		public static IOption<T> ObjectNode<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<XmlReader, T> iterator)
        {
            return self.ObjectNode(nodeName, FunctionsBuilder.MakeIterableItemBuilder(builder, iterator));
        }

        /// <summary>
        /// Converts an XML node to an object using the specified objet builder and body callback functions.
        /// This function will read the text contents of the node ignoring its children structure.
        /// This is function useful for nodes that have multiple attributes and only text contents.
        /// The reader's cursor will be automaricaly advanced by using this function.
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="nodeName">Name of the XML node</param>
        /// <param name="builder">Object builder function</param>
        /// <param name="text">Body callback function</param>
        /// <returns></returns>
		public static IOption<T> ObjectNodeWithContent<T>(this XmlReader self, string nodeName, Func<XmlReader, T> builder, Action<string, T> text)
        {
            return self.ObjectNode(nodeName, FunctionsBuilder.MakeTextReaderBuilder(builder, text));
        }
    }

    public static class ObjectNodes
    {
        /// <summary>
        /// Provides a function that returns an empty list. Can be used with <see cref="Option.Fallback"/> when an empty list is not considered a <see cref="Nothing"/>.
        /// </summary>
		public static Func<IOption<IList<T>>> EmptyList<T>()
        {
            return () => Option.Some(Collections.IList<T>());
        }

        /// <summary>
        /// Provides a function that returns an empty object. Can be used with <see cref="Option.Fallback"/> when an empty object is not considered a <see cref="Nothing"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
		public static Func<IOption<T>> Empty<T>()
            where T : class, new()
        {
            return () => Option.Some(new T());
        }
    }
}
