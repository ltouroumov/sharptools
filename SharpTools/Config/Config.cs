using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SharpTools.Xml;
using SharpTools.Utils.Collections;

namespace SharpTools.Config
{
    public class Config : Dictionary<string, string>
    {
        public static Config Load(string path)
        {
            var reader = XmlReader.Create(path);
            reader.ReadUntil(xml => xml.NodeType == XmlNodeType.Element);
            var config = new Config();

            reader.ObjectNodeList("Parameter",
                (x) => new Tuple() { Key = x.GetAttribute("Name") },
                (x, node) => x.ReadText().Bind(val => node.Val = val))
                .Bind(list => {
                    list.ForEach(t => config.Add(t.Key, t.Val));
                });

            return config;
        }

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
