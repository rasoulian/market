using Market.ViewModels;

namespace Market.Pages;

public partial class NotificationPage : ContentPage
{

    public NotificationPage(NotificationViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}