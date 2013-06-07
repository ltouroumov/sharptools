using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using SharpTools.Functional;

namespace SharpTools.Utils.Dynamic
{
    /// <summary>
    /// Dynamic object proxy which invokes a callback to get a default value when the property is not defined
    /// </summary>
    public class ObjectProxy : DynamicObject
    {
        private dynamic theObject = null;
        private Func<string, object> defaultValueProvider = null;
        private Type theType = null;

        /// <summary>
        /// Builds a dynamic object proxy.
        /// </summary>
        /// <param name="theObject">Object to proxy</param>
        /// <param name="defaultValueProvider">Default property value provider function</param>
        public ObjectProxy(dynamic theObject, Func<string, object> defaultValueProvider = null)
        {
            this.theObject = theObject;
            this.defaultValueProvider = defaultValueProvider;
            if (theObject != null) {
                this.theType = (theObject as object).GetType();
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var defaultValue = this.defaultValueProvider.Partial(binder.Name);

            if (theObject == null) {
                result = defaultValue();
                return true;
            }

            var prop = theType.GetRuntimeProperty(binder.Name);

            if (prop != null) {
                result = prop.GetValue(theObject);
                return true;
            }

            result = defaultValue();
            return true;
        }
    }
}
