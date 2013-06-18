using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTools.Notification
{
    /// <summary>
    /// The notification center allows events to be sent to various listeners without the need of a direct reference between the two.
    /// This mechanism allows for loose coupling of certain components.
    /// The NotificationCenter allows for multiple contained instanced of itself but provides a default singleton instance that can be used out of the box.
    /// </summary>
    public class NotificationCenter
    {
        /// <summary>
        /// Singleton instance of the NotificationCenter
        /// </summary>
        public static readonly NotificationCenter DefaultCenter = new NotificationCenter();

        private IDictionary<string, NotificationHandler> Handlers;

        /// <summary>
        /// Handles notifications
        /// </summary>
        /// <param name="sender">Object that triggered the notification (nullable)</param>
        /// <param name="notification">Informations about the notification</param>
        public delegate void NotificationEventHandler(object sender, Notification notification);

        /// <summary>
        /// This handler will trigger on every notification that goes through this center.
        /// </summary>
        public event NotificationEventHandler OnNotify;

        /// <summary>
        /// Builds a new NotificationCenter with its own set of handlers
        /// </summary>
        public NotificationCenter()
        {
            Handlers = new Dictionary<string, NotificationHandler>();
        }

        /// <summary>
        /// Shortcut for <see cref="FetchHandler"/>
        /// </summary>
        /// <param name="key">Handler name</param>
        /// <returns>Notification handler</returns>
        public NotificationHandler this[string key]
        {
            get { return FetchHandler(key); }
        }

        /// <summary>
        /// Fetches a named handler from the center.
        /// This function will return a new handler if it does not already exist.
        /// </summary>
        /// <param name="key">Handler name</param>
        /// <returns>Notification Handler</returns>
        public NotificationHandler FetchHandler(string key)
        {
            NotificationHandler handler = null;

            if (!Handlers.TryGetValue(key, out handler)) {
                handler = Handlers[key] = new NotificationHandler(this, key);
                // Subscribe to every notification managed by this center to allow the global OnNotify callback
                handler.Observe(NotificationPosted);
            }

            return handler;
        }

        internal void NotificationPosted(object sender, Notification notif)
        {
            if (OnNotify != null) {
                OnNotify(sender, notif);
            }
        }

        /// <summary>
        /// Attach an event observer to OnNotify
        /// </summary>
        /// <param name="handler"></param>
        public void Observe(NotificationEventHandler handler)
        {
            this.OnNotify += handler;
        }

        /// <summary>
        /// Send the specified notification through the default handler.
        /// </summary>
        /// <param name="name">Notification name</param>
        /// <param name="sender">Sender object</param>
        /// <param name="parameter">Optional parameters</param>
        public static void Post(string name, object sender, object parameter = null)
        {
            DefaultCenter[name].Post(sender, parameter);
        }
    }

    /// <summary>
    /// Represents a sent notification
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Name of the notification
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// The originator of the notification
        /// </summary>
        public object Sender { get; internal set; }

        /// <summary>
        /// Optional parameters
        /// </summary>
        public object Parameter { get; internal set; }

        /// <summary>
        /// The handler responsible for this notification
        /// </summary>
        public NotificationHandler Handler { get; internal set; }

        /// <summary>
        /// The notification center responsible for this notification
        /// </summary>
        public NotificationCenter NotificationCenter { get; internal set; }
    }

    /// <summary>
    /// Manages the receivers for a notification.
    /// </summary>
    public class NotificationHandler
    {
        private NotificationCenter center;

        /// <summary>
        /// Name of the attached notification
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Handles notifications
        /// </summary>
        /// <param name="sender">Object that triggered the notification (nullable)</param>
        /// <param name="notification">Informations about the notification</param>
        public delegate void NotificationEventHandler(object sender, Notification notification);

        /// <summary>
        /// This event is triggered when the notification is posted
        /// </summary>
        public event NotificationEventHandler OnNotify;

        internal NotificationHandler(NotificationCenter center, string name)
        {
            this.Name = name;
            this.center = center;
        }

        /// <summary>
        /// Adds an observer to this notification
        /// </summary>
        /// <param name="handler">Observer callback</param>
        public void Observe(NotificationEventHandler handler)
        {
            this.OnNotify += handler;
        }

        /// <summary>
        /// Send the notification and its parameters to the observers
        /// </summary>
        /// <param name="sender">Object that triggered the notification</param>
        /// <param name="parameter">Optional parameters</param>
        public void Post(object sender, object parameter = null)
        {
            var notif = new Notification() {
                Name = Name,
                Parameter = parameter,
                Sender = sender,
                Handler = this,
                NotificationCenter = this.center,
            };

            if (OnNotify != null) {
                OnNotify(sender, notif);
            }
        }
    }

    public static class NotificationExtensions
    {
        /// <summary>
        /// Post the named notification through the default center using <code>this</code> as the sender.
        /// </summary>
        /// <param name="self">Sender</param>
        /// <param name="name">Notification name</param>
        /// <param name="parameter">Optional parameters</param>
        public static void PostNotification(this object self, string name, object parameter = null)
        {
            NotificationCenter.DefaultCenter[name].Post(self, parameter);
        }
    }
}
