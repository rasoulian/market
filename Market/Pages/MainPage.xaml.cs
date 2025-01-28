using Market.Services;
using Market.ViewModels;
using System.Text.Json;
using System.Windows.Input;

namespace Market.Pages;


public partial class MainPage : ContentPage
{
    private readonly IApiServices _apiServices;
    int count = 0;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
     

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        var carServices = await _apiServices.Get();
        ali2.Text = JsonSerializer.Serialize(carServices);


        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
