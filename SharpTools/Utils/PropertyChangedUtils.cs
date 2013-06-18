using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace SharpTools.Utils.ComponentModel
{
    /// <summary>
    /// Provide an implementation of the <see cref="INotifyPropertyChanged"/> on top of a dictionary.
    /// This class must be inherited since it will create entries in the dictionary for each public property.
    /// </summary>
    public abstract class PropertyBag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Dictionary<string, object> Properties = new Dictionary<string, object>();

        public PropertyBag()
        {
            var myType = this.GetType();

            // Enumerate type properties to populate the values dictionary
            foreach (var prop in myType.GetRuntimeProperties()) {
                SetValue(prop.Name, null);
            }
        }

        /// <summary>
        /// Fetch a value from the dictionary and cast it.
        /// </summary>
        /// <typeparam name="A">Type of the value</typeparam>
        /// <param name="key">Name of the property</param>
        /// <returns>Property value</returns>
        protected A GetValue<A>(string key)
            where A : class
        {
            return Properties[key] as A;
        }

        /// <summary>
        /// Put a value in the dictionary and trigger the <code>PropertyChanged</code> event.
        /// </summary>
        /// <param name="key">Property name</param>
        /// <param name="val">Property value</param>
        protected void SetValue(string key, object val)
        {
            Properties[key] = val;
            TriggerPropertyChange(key);
        }

        protected void TriggerPropertyChange(string key)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(key));
            }
        }

        /// <summary>
        /// Export the properties dictionary
        /// </summary>
        public Dictionary<string, object> SaveProperties()
        {
            return this.Properties;
        }

        /// <summary>
        /// Import the properties dictionary
        /// </summary>
        public void LoadProperties(Dictionary<string, object> properties)
        {
            this.Properties = properties;
        }
    }
}
