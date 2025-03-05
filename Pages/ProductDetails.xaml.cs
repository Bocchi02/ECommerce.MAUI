using ECommerce.Models;

namespace ECommerce.Pages;

public partial class ProductDetails : ContentPage
{
    public ProductDetails(Product selectedProduct)
    {
        InitializeComponent();
        BindingContext = selectedProduct;
    }
}
