using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace SharpTools.Utils.Dynamic
{
    /// <summary>
    /// Dynamic object proxy with returns a default value when the property is not defined
    /// </summary>
    public class ObjectProxy : DynamicObject
    {
        private dynamic theObject = null;
        private object defaultValue = null;
        private Type theType = null;

        /// <summary>
        /// Builds a dynamic object proxy.
        /// </summary>
        /// <param name="theObject">Object to proxy</param>
        /// <param name="defaultValue">Default property value</param>
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
