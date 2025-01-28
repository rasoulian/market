using CommunityToolkit.Maui.Views;
using Market.ViewModels;


namespace Market.Pages.Popups;
public partial class UpdatePopup : Popup
{
    public UpdatePopup(UpdateViewModel viewModel)
    {
        InitializeComponent();
        base.BindingContext = viewModel;
    }
}