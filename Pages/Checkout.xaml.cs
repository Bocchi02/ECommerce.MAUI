using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using ECommerce.Models;

namespace ECommerce.Pages
{
    public partial class Checkout : ContentPage
    {
        public ObservableCollection<CartItem> CartItems { get; set; } = new();
        public ObservableCollection<string> PaymentMethods { get; set; } = new();

        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        private string _selectedPaymentMethod;
        public string SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set
            {
                if (_selectedPaymentMethod != value)
                {
                    _selectedPaymentMethod = value;
                    OnPropertyChanged(nameof(SelectedPaymentMethod));
                }
            }
        }

        public Checkout(ObservableCollection<CartItem> cartItems)
        {
            InitializeComponent();
            BindingContext = this;

            // ? Assign actual cart items
            foreach (var item in cartItems)
                CartItems.Add(item);

            PaymentMethods.Add("Credit Card");
            PaymentMethods.Add("Debit Card");
            PaymentMethods.Add("GCash");
            PaymentMethods.Add("PayPal");
            PaymentMethods.Add("Cash on Delivery");

            UpdateTotalPrice();
        }

        // ?? Update Total Price
        private void UpdateTotalPrice()
        {
            TotalPrice = CartItems.Sum(item => item.Price * item.Quantity);
        }

        // ?? Checkout Process
        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            if (CartItems.Count == 0)
            {
                await DisplayAlert("Empty Cart", "Your cart is empty. Add items before checkout.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(SelectedPaymentMethod))
            {
                await DisplayAlert("Payment Required", "Please select a payment method.", "OK");
                return;
            }

            bool confirm = await DisplayAlert("Confirm Order",
                $"Proceed with payment using {SelectedPaymentMethod}?", "Yes", "No");

            if (confirm)
            {
                await DisplayAlert("Success", "Your order has been placed!", "OK");
                CartItems.Clear();
                UpdateTotalPrice();
                await Navigation.PushAsync(new HomePage());
            }
        }
    }
}
