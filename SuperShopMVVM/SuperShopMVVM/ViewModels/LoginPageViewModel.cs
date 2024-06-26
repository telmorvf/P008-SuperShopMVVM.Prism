﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperShopMVVM.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _password;
        private bool _isRunning;
        private bool _isEnable;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Login";
            IsEnable = true;
        }


        // Command's
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        // Properties
        // Only get
        public string Email { get; set; }

        // get and set
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnable
        {
            get => _isEnable;
            set => SetProperty(ref _isEnable, value);
        }


        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an Email.", "Accept");
                Password = string.Empty;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a Password.", "Accept");
                Password = string.Empty;
                return;
            }

            await App.Current.MainPage.DisplayAlert("OK", "Boa, Entrámos", "Accept");

        }
    }
}
