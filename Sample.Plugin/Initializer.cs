// Sample.Plugin
// Initializer.cs

#region Usings

using System;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;
using FFXIVAPP.Common.Controls;
using Sample.Plugin.Properties;
using Sample.Plugin.Views;

#endregion

namespace Sample.Plugin
{
    internal static class Initializer
    {
        #region Declarations

        #endregion

        /// <summary>
        /// </summary>
        public static void LoadSettings()
        {
            if (Constants.XSettings != null)
            {
                foreach (var xElement in Constants.XSettings.Descendants()
                                                  .Elements("Setting"))
                {
                    var xKey = (string) xElement.Attribute("Key");
                    var xValue = (string) xElement.Element("Value");
                    if (String.IsNullOrWhiteSpace(xKey) || String.IsNullOrWhiteSpace(xValue))
                    {
                        return;
                    }
                    Settings.SetValue(xKey, xValue);
                    if (!Constants.Settings.Contains(xKey))
                    {
                        Constants.Settings.Add(xKey);
                    }
                }
            }
        }

        /// <summary>
        /// </summary>
        public static void ApplyTheming()
        {
            SetupFont(ref MainView.View.ChatLogFD);
            SetupColor(ref MainView.View.ChatLogFD);
        }

        private static void SetupFont(ref xFlowDocument flowDoc)
        {
            var font = Settings.Default.ChatFont;
            flowDoc._FD.FontFamily = new FontFamily(font.Name);
            flowDoc._FD.FontWeight = font.Bold ? FontWeights.Bold : FontWeights.Regular;
            flowDoc._FD.FontStyle = font.Italic ? FontStyles.Italic : FontStyles.Normal;
            flowDoc._FD.FontSize = font.Size;
        }

        private static void SetupColor(ref xFlowDocument flowDoc)
        {
            flowDoc._FD.Background = new SolidColorBrush(Settings.Default.ChatBackgroundColor);
        }
    }
}
