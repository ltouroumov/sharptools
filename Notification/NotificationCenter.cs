using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTools.Notification
{
    public class NotificationCenter
    {
        public static readonly NotificationCenter DefaultCenter = new NotificationCenter();

        private IDictionary<string, NotificationHandler> Handlers;

        public delegate void NotificationEventHandler(object sender, Notification notification);
        public event NotificationEventHandler OnNotify;

        public NotificationCenter()
        {
            Handlers = new Dictionary<string, NotificationHandler>();
        }

        public NotificationHandler this[string key]
        {
            get { return FetchHandler(key); }
        }

        public NotificationHandler FetchHandler(string key)
        {
            NotificationHandler handler = null;

            if (!Handlers.TryGetValue(key, out handler)) {
                handler = Handlers[key] = new NotificationHandler(this, key);
            }

            return handler;
        }

        internal void PostNotification(object sender, Notification notif)
        {
            if (OnNotify != null) {
                OnNotify(sender, notif);
            }
        }

        public static void Post(string name, object sender, object parameter = null)
        {
            DefaultCenter[name].Post(sender, parameter);
        }
    }

    public class Notification
    {
        public string Name { get; internal set; }

        public object Parameter { get; internal set; }
    }

    public class NotificationHandler
    {
        private NotificationCenter center;
        public string Name { get; private set; }

        public delegate void NotificationEventHandler(object sender, Notification notification);
        public event NotificationEventHandler OnNotify;

        public NotificationHandler(NotificationCenter center, string name)
        {
            this.Name = name;
            this.center = center;
        }

        public void Observe(NotificationEventHandler handler)
        {
            OnNotify += handler;
        }

        public void Post(object sender, object parameter = null)
        {
            var notif = new Notification() {
                Name = Name,
                Parameter = parameter
            };

            if (OnNotify != null) {
                OnNotify(sender, notif);
            }
        }
    }

    public static class NotificationExtensions
    {
        public static void PostNotification(this object self, string name, object parameter = null)
        {
            NotificationCenter.DefaultCenter[name].Post(self, parameter);
        }
    }
}
