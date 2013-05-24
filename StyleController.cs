using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using Windows.UI.Xaml;


namespace Utils.Style
{
    public static class StyleController
    {
        public static FrameworkElement ApplicationRootElement = null;
        public static ResourceDictionary ResourceDictionary = null;

        public static void Initialize(FrameworkElement applicationRootElement, ResourceDictionary resourceDictionary)
        {
            ApplicationRootElement = applicationRootElement;
            ResourceDictionary = resourceDictionary;
        }



        public static object FindResource(string name)
        {
            if (ResourceDictionary == null) throw new Exception("ResourceDictionary has not been set.");
            if (ApplicationRootElement == null) throw new Exception("ApplicationRootElement has not been set.");

            if (ResourceDictionary.ContainsKey(name)) return ResourceDictionary[name];

            return ApplicationRootElement.FindResource(name);
        }



        internal static object FindResource(this FrameworkElement root, string name)
        {
            if (root != null && root.Resources.ContainsKey(name)) return root.Resources[name];

            try {
                return root.FindName(name);
            } catch { }
            return null;
        }

    }
}