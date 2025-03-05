using Microsoft.Maui.Controls;
using System;
using ECommerce.Models;

namespace ECommerce.Pages
{
    public partial class AccountDetails : ContentPage
    {
        public AccountDetail UserAccount { get; set; }

        public AccountDetails()
        {
            InitializeComponent();

            // Initialize the user account data
            UserAccount = new AccountDetail
            {
                FullName = "Emo Dinsil",
                Email = "emodinsil@example.com",
                Phone = "+63 912 345 6789",
                Address = "Bacon, Sorsogon, Philippines",
                JoinedDate = new DateTime(2023, 5, 15)
            };

            BindingContext = UserAccount; // Bind to UI
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Edit Profile", "Navigate to edit account page", "OK");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure you want to log out?", "Yes", "No");
            if (confirm)
            {
                await Navigation.PopToRootAsync(); // Simulates logging out
            }
        }
    }
}
