using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using ECommerce.Models;

namespace ECommerce.Pages
{
    public partial class Products : ContentPage
    {
        public ObservableCollection<Product> ProductList { get; set; }
        public ObservableCollection<string> CategoryList { get; set; }
        public ObservableCollection<Product> FilteredProductList { get; set; }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    FilterProducts();
                }
            }
        }

        public Products()
        {
            InitializeComponent();

            // Define Product List with Categories
            ProductList = new ObservableCollection<Product>
{
                new Product { Name = "Laptop", Category = "Electronics", Price = "P45,000", Image = "dotnet_bot.png", Description = "High-performance laptop with the latest processor and long battery life." },
                new Product { Name = "Smartphone", Category = "Electronics", Price = "P25,000", Image = "dotnet_bot.png", Description = "Sleek and powerful smartphone with an advanced camera and fast charging." },
                new Product { Name = "Headphones", Category = "Accessories", Price = "P3,500", Image = "dotnet_bot.png", Description = "Noise-canceling headphones with crystal-clear sound and deep bass." },
                new Product { Name = "Smartwatch", Category = "Accessories", Price = "P8,000", Image = "dotnet_bot.png", Description = "Feature-packed smartwatch with fitness tracking and call notifications." },
                new Product { Name = "Shoes", Category = "Fashion", Price = "P2,000", Image = "dotnet_bot.png", Description = "Comfortable and stylish shoes perfect for casual or athletic wear." },
                new Product { Name = "Backpack", Category = "Fashion", Price = "P1,500", Image = "dotnet_bot.png", Description = "Durable and spacious backpack ideal for school, work, or travel." }
            };


            // Define Categories List
            CategoryList = new ObservableCollection<string>
            {
                "All Categories",
                "Electronics",
                "Accessories",
                "Fashion"
            };

            // Default selection & filter
            SelectedCategory = "All Categories";
            FilteredProductList = new ObservableCollection<Product>(ProductList);

            BindingContext = this;
        }

        private void FilterProducts()
        {
            if (SelectedCategory == "All Categories")
            {
                FilteredProductList = new ObservableCollection<Product>(ProductList);
            }
            else
            {
                FilteredProductList = new ObservableCollection<Product>(
                    ProductList.Where(p => p.Category == SelectedCategory)
                );
            }

            OnPropertyChanged(nameof(FilteredProductList));
        }

        private async void OnViewDetails(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedProduct = button?.BindingContext as Product;

            if (selectedProduct != null)
            {
                await Navigation.PushAsync(new ProductDetails(selectedProduct));
            }
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            await Navigation.PushAsync(new HomePage());
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
