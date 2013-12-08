// Sample.Plugin
// SettingsViewModel.cs

#region Usings

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FFXIVAPP.Common.Events;
using FFXIVAPP.Common.Models;
using FFXIVAPP.Common.ViewModelBase;
using Sample.Plugin.Views;

#endregion

namespace Sample.Plugin.ViewModels
{
    internal sealed class SettingsViewModel : INotifyPropertyChanged
    {
        #region Property Bindings

        private static SettingsViewModel _instance;

        public static SettingsViewModel Instance
        {
            get { return _instance ?? (_instance = new SettingsViewModel()); }
        }

        #endregion

        #region Declarations

        public ICommand ClearChatLogCommand { get; private set; }

        #endregion

        public SettingsViewModel()
        {
            ClearChatLogCommand = new DelegateCommand(ClearChatLog);
        }

        #region Loading Functions

        #endregion

        #region Utility Functions

        #endregion

        #region Command Bindings

        /// <summary>
        /// </summary>
        public static void ClearChatLog()
        {
            var popupContent = new PopupContent();
            popupContent.PluginName = Plugin.PName;
            popupContent.Title = PluginViewModel.Instance.Locale["app_WarningMessage"];
            popupContent.Message = PluginViewModel.Instance.Locale["sample_ClearChatLogMessage"];
            popupContent.CanCancel = true;
            Plugin.PHost.PopupMessage(Plugin.PName, popupContent);
            EventHandler<PopupResultEvent> resultChanged = null;
            resultChanged = delegate(object sender, PopupResultEvent e)
            {
                switch (e.NewValue.ToString())
                {
                    case "OK":
                        MainView.View.ChatLogFD._FD.Blocks.Clear();
                        break;
                    case "Cancel":
                        break;
                }
                PluginViewModel.Instance.PopupResultChanged -= resultChanged;
            };
            PluginViewModel.Instance.PopupResultChanged += resultChanged;
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }

        #endregion
    }
}
