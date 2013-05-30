using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using SharpTools.Functional;
using SharpTools.Functional.Option;

namespace SharpTools.Xml
{
    public static class ReaderInitExtensions
    {
        public static XmlReader Prepare(this XmlReader self)
        {
            self.ReadUntil(x => x.NodeType == XmlNodeType.Element);
            return self;
        }
    }
}
