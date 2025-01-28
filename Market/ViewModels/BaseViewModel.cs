using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using Market.Pages;
using Market.Services;
using System.Windows.Input;




namespace Market.ViewModels;



public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isRefreshing;

    [ObservableProperty]
    private bool _isBusy;


    protected readonly PersianService _persianService = ServiceHelper.GetService<PersianService>();
    private readonly IPopupService _popupService = ServiceHelper.GetService<IPopupService>();

    public ICommand OpenUrlCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    public ICommand PhoneCallCommand => new Command<string>(PhoneDialer.Default.Open);



    public ICommand OnTermsCommand => new Command(async () =>
    {
        //await Shell.Current.GoToAsync($"//{nameof(NotificationPage)}");
    });

    public ICommand OnNotificationCommand => new Command(async () =>
    {
        await Shell.Current.GoToAsync($"//{nameof(NotificationPage)}");
    });

    public ICommand OnRegisterCommand => new Command(async () =>
    {
        //this._popupService.ShowPopup<RegisterViewModel>();
    });


    public ICommand OnBillCommand => new Command(async () =>
    {
        this._popupService.ShowPopup<BillViewModel>();
    });

}





