﻿// Sample.Plugin
// German.cs

using System.Windows;

namespace Sample.Plugin.Localization
{
    public abstract class German
    {
        private static readonly ResourceDictionary Dictionary = new ResourceDictionary();

        /// <summary>
        /// </summary>
        /// <returns> </returns>
        public static ResourceDictionary Context()
        {
            Dictionary.Clear();
            Dictionary.Add("sample_", "*PH*");
            Dictionary.Add("sample_ChatLogTabHeader", "Chat");
            Dictionary.Add("sample_ClearChatLogMessage", "Clear ChatLogFD");
            Dictionary.Add("sample_ClearChatLogToolTip", "Clear Chat");
            return Dictionary;
        }
    }
}
