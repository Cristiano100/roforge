﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using CommunityToolkit.Mvvm.Input;

namespace Roforge.UI.ViewModels.Bootstrapper
{
    public class BootstrapperDialogViewModel : NotifyPropertyChangedViewModel
    {
        private readonly IBootstrapperDialog _dialog;

        public ICommand CancelInstallCommand => new RelayCommand(CancelInstall);

        public string Title => App.Settings.Prop.BootstrapperTitle;
        public ImageSource Icon { get; set; } = App.Settings.Prop.BootstrapperIcon.GetIcon().GetImageSource();
        public string Message { get; set; } = "Please wait...";
        public bool ProgressIndeterminate { get; set; } = true;
        public int ProgressValue { get; set; } = 0;

        public bool CancelEnabled { get; set; } = false;
        public Visibility CancelButtonVisibility => CancelEnabled ? Visibility.Visible : Visibility.Collapsed;

        public BootstrapperDialogViewModel(IBootstrapperDialog dialog)
        {
            _dialog = dialog;
        }

        private void CancelInstall()
        {
            _dialog.Bootstrapper?.CancelInstall();
            _dialog.CloseBootstrapper();
        }
    }
}
