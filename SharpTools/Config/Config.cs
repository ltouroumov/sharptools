using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SharpTools.Xml;
using SharpTools.Utils.Collections;
using SharpTools.Functional.Option;
using System.Runtime.InteropServices;

namespace SharpTools.Config
{
    /// <summary>
    /// Handler simple configuration files
    /// <example>
    /// <Parameters>
    ///     <Paramater Name="Foo">Bar</Paramater>
    /// </Parameters>
    /// </example>
    /// </summary>
    [ComVisible(false)]
    public class Config : Dictionary<string, string>
    {
        /// <summary>
        /// Load the configuration from the file
        /// </summary>
        /// <param name="path">Path of the XML file</param>
        /// <returns></returns>
        public static Config Load(string path)
        {
            var reader = XmlReader.Create(path);
            // Skip until the first node
            reader.ReadUntil(xml => xml.NodeType == XmlNodeType.Element);
            var config = new Config();

            // Read all first level '<Parameter Name="key">val</...>' nodes
            reader.ObjectNodeList("Parameter",
                (x) => new Tuple() { Key = x.GetAttribute("Name") },
                (x, node) => x.ReadText().MatchSome(val => node.Val = val)
			).MatchSome(list => {
                list.ForEach(t => config.Add(t.Key, t.Val));
            });

            return config;
        }

        /// <summary>
        /// Attempt to get the value and fallback to default
        /// </summary>
        /// <param name="key">Key name</param>
        /// <param name="def">Default value</param>
        /// <returns>Stored value or default</returns>
        public string Get(string key, string def)
        {
            string value = null;
            if (TryGetValue(key, out value)) {
                return value;
            }
            return def;
        }

        protected class Tuple
        {
            public string Key { get; set; }
            public string Val { get; set; }
        }
    }
}
