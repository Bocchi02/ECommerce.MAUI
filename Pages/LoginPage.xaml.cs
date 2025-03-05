using System;
using Microsoft.Maui.Controls;
using ECommerce.Pages;

namespace ECommerce.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e){ 
            await Navigation.PushAsync(new HomePage());
        }
    }
}
