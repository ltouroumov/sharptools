using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Utils.Dynamic
{
    public class DictionaryProxy<V> : DynamicObject
        where V : class
    {
        public IDictionary<string, V> source { get; private set; }

        public DictionaryProxy(IDictionary<string, V> source = null)
        {
            Attach(source);
        }

        public void Attach(IDictionary<string, V> source)
        {
            this.source = source;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;

            V value;
            if (source.TryGetValue(binder.Name, out value)) {
                result = value;
            }

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (source.Keys.Contains(binder.Name)) {
                source[binder.Name] = value as V;
            } else {
                source.Add(binder.Name, value as V);
            }

            return true;
        }
    }

    public class ObjectProxy : DynamicObject
    {
        private dynamic theObject = null;
        private object defaultValue = null;
        private Type theType = null;

        public ObjectProxy(dynamic theObject, object defaultValue = null)
        {
            this.theObject = theObject;
            this.defaultValue = defaultValue;
            if (theObject != null) {
                this.theType = (theObject as object).GetType();
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (theObject == null) {
                result = this.defaultValue;
                return true;
            }

            var props = theType.GetRuntimeProperties();

            var prop = theType.GetRuntimeProperty(binder.Name);

            if (prop != null) {
                result = prop.GetValue(theObject);
                return true;
            }

            result = this.defaultValue;
            return true;
        }
    }
}
