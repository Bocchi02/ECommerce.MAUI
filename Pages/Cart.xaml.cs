using System.Collections.ObjectModel;
using ECommerce.Models;

namespace ECommerce.Pages
{
    public partial class Cart : ContentPage
    {
        public ObservableCollection<CartItem> CartItems { get; set; }
        public decimal TotalPrice => CartItems.Sum(item => item.TotalPrice);

        public Cart()
        {
            InitializeComponent();

            // Sample Cart Data
            CartItems = new ObservableCollection<CartItem>
            {
                new CartItem { Name = "Laptop", Price = 45000, Quantity = 1, Image = "dotnet_bot.png" },
                new CartItem { Name = "Smartphone", Price = 25000, Quantity = 1, Image = "dotnet_bot.png" }
            };

            BindingContext = this;
        }

        private void OnIncreaseQuantity(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is CartItem item)
            {
                item.Quantity++;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private void OnDecreaseQuantity(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is CartItem item && item.Quantity > 1)
            {
                item.Quantity--;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private void OnRemoveItem(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.CommandParameter is CartItem item)
            {
                CartItems.Remove(item);
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            if (CartItems.Count == 0)
            {
                await DisplayAlert("Empty Cart", "Your cart is empty. Add items before checkout.", "OK");
                return;
            }

            await Navigation.PushAsync(new Checkout(CartItems));
        }


    }


}
