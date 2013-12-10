// Sample.Plugin
// LogPublisher.cs

using System;
using FFXIVAPP.Common.Core.Memory;
using FFXIVAPP.Common.Utilities;
using NLog;
using Sample.Plugin.Properties;
using Sample.Plugin.Views;

namespace Sample.Plugin.Utilities
{
    public static class LogPublisher
    {
        public static void Process(ChatLogEntry chatEntry)
        {
            try
            {
                var timeStampColor = Settings.Default.TimeStampColor.ToString();
                var timeStamp = chatEntry.TimeStamp.ToString("[HH:mm:ss] ");
                var line = chatEntry.Line.Replace("  ", " ");
                var color = (Constants.Colors.ContainsKey(chatEntry.Code)) ? Constants.Colors[chatEntry.Code][0] : "FFFFFF";
                FFXIVAPP.Common.Constants.FD.AppendFlow(timeStamp, "", line, new[]
                {
                    timeStampColor, "#" + color
                }, MainView.View.ChatLogFD._FDR);
            }
            catch (Exception ex)
            {
                Logging.Log(LogManager.GetCurrentClassLogger(), "", ex);
            }
        }
    }
}
