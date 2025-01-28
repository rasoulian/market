using Market.ViewModels;
using System.Globalization;

namespace Market.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var geoLocationRequest = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(20));
        var location = await Geolocation.GetLocationAsync(geoLocationRequest);

        try
        {
            NumberFormatInfo nfi = new();
            nfi.NumberDecimalSeparator = ".";

            Uri uri = new($"https://www.google.com/maps/search/{location.Latitude.ToString(nfi)},{location.Longitude.ToString(nfi)}");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            // An unexpected error occurred. No browser may be installed on the device.
        }

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

    }
}