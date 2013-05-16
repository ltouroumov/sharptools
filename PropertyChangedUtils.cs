using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace Utils.ComponentModel
{
    public class PropertyBag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Dictionary<string, object> Properties = new Dictionary<string, object>();

        public PropertyBag()
        {
            var myType = this.GetType();

            foreach (var prop in myType.GetRuntimeProperties()) {
                SetValue(prop.Name, null);
            }
        }

        protected A GetValue<A>(string key)
            where A : class
        {
            return Properties[key] as A;
        }

        protected void SetValue(string key, object val)
        {
            Properties[key] = val;
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(key));
            }
        }

        public Dictionary<string, object> SaveProperties()
        {
            return this.Properties;
        }

        public void LoadProperties(Dictionary<string, object> properties)
        {
            this.Properties = properties;
        }
    }
}
