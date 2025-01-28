using Market.ViewModels;

namespace Market.Pages;

public partial class VitrinPage : ContentPage
{
    public VitrinPage(VitrinViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;

        carouselView.ItemsSource = viewModel.Products1;
        picker.ItemsSource = viewModel.Products1.Select(i => i.Title).ToList();
        collectionView.ItemsSource = viewModel.Products2;
    }
}

