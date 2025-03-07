using System.Collections.ObjectModel;
using ECommerce.Models;

namespace ECommerce.Pages
{
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<Product> FeaturedProducts { get; set; }

        public HomePage()
        {
            InitializeComponent();

            // Sample Data
            FeaturedProducts = new ObservableCollection<Product>
            {
                new Product { Name = "Laptop", Price = 45000, Image = "dotnet_bot.png" },
                new Product { Name = "Smartphone", Price = 25000, Image = "dotnet_bot.png" },
                new Product { Name = "Headphones", Price = 3500, Image = "dotnet_bot.png" }
            };

            BindingContext = this;
        }

        private async void OnProductsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Products());
        }

        private async void OnCartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cart());
        }

        private async void OnAccountClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccountDetails());
        }
    }
}
