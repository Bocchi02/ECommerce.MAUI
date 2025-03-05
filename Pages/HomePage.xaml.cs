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
                new Product { Name = "Laptop", Price = "P45,000", Image = "dotnet_bot.png" },
                new Product { Name = "Smartphone", Price = "P25,000", Image = "dotnet_bot.png" },
                new Product { Name = "Headphones", Price = "P3,500", Image = "dotnet_bot.png" }
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
