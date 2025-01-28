using CommunityToolkit.Maui.Views;
using Market.ViewModels;


namespace Market.Pages.Popups;
public partial class BillPopup : Popup
{
    public BillPopup(BillViewModel viewModel)
    {
        InitializeComponent();
        base.BindingContext = viewModel;
    }
}