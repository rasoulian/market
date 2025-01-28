using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using Market.Pages;
using Market.Pages.Popups;
using Market.Services;
using Market.ViewModels;
using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Plugin.Maui.ScreenSecurity;
using Refit;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;



namespace Market;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("IRANSans.ttf", "IRANSans");
                fonts.AddFont("IRANSans_Bold.ttf", "IRANSansBold");
                fonts.AddFont("IRANSans_Light.ttf", "IRANSansLight");
                fonts.AddFont("IRANSans_Medium.ttf", "IRANSansMedium");
                fonts.AddFont("IRANSans_UltraLight.ttf", "IRANSansUltraLight");


                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "MaterialIconsOutlined-Regular");
            });


        builder.Services.AddSingleton<GetDeviceInfo>();
        builder.Services.AddSingleton<PersianService>(new PersianService());
        builder.Services.AddSingleton<IScreenSecurity>(ScreenSecurity.Default);
        builder.Services.AddSingleton<INotificationService>(LocalNotificationCenter.Current);

        builder.Services.AddSingleton<IPlatformHttpMessageHandler>(_ =>
        {
#if ANDROID
            return new AndroidHttpMessageHandler();
#elif IOS
            return new IosHttpMessageHandler();
#endif
            return null;
        });


#if DEBUG
        builder.Logging.AddDebug().SetMinimumLevel(LogLevel.Trace);
#endif

        RegisterServices(builder.Services);
        RegisterViews(builder.Services);
        RegisterViewModels(builder.Services);
        var app = builder.Build();

        ServiceHelper.Initialize(app.Services);
        //Expander.EnableAnimations();

        return app;
    }

    private static void RegisterServices(in IServiceCollection services)
    {
        services.AddSingleton<IVibration>(Vibration.Default);
        services.AddSingleton<Plugin.Maui.ScreenSecurity.IScreenSecurity>(Plugin.Maui.ScreenSecurity.ScreenSecurity.Default);
        services.AddSingleton<Plugin.LocalNotification.INotificationService>(Plugin.LocalNotification.LocalNotificationCenter.Current);
        services.AddTransient<IPopupService, PopupService>();
        services.AddSingleton(new PersianService());
        services.AddSingleton<GetDeviceInfo>();


        ConfigureRefit(services);

    }

    private static void RegisterViews(in IServiceCollection services)
    {
        services.AddTransient<MainPage>();
        services.AddTransient<VitrinPage>();
        services.AddTransient<VisitPage>();
        services.AddTransient<ProfilePage>();
        services.AddTransient<NotificationPage>();
    }

    private static void RegisterViewModels(in IServiceCollection services)
    {
        services.AddTransient<MainViewModel>();
        services.AddTransient<VitrinViewModel>();
        services.AddTransient<VisitViewModel>();
        services.AddTransient<ProfileViewModel>();
        services.AddTransient<NotificationViewModel>();


        services.AddTransientPopup<UpdatePopup, UpdateViewModel>();
        services.AddTransientPopup<BillPopup, BillViewModel>();
    }

    private static void ConfigureRefit(IServiceCollection services)
    {
        services.AddSingleton<TokenService>();

        services.AddRefitClient<IApiServices>(ConfigureRefitSettings)
            .ConfigureHttpClient(SetHttpClient);


        static RefitSettings ConfigureRefitSettings(IServiceProvider sp)
        {
            var messageHandler = sp.GetRequiredService<IPlatformHttpMessageHandler>();
            var tokenService = sp.GetRequiredService<TokenService>();
            return new RefitSettings
            {
                HttpMessageHandlerFactory = () => messageHandler.GetHttpMessageHandler(),
                AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(/*tokenService.Token ??*/ tokenService.DefaultToken),
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    //Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }),


            };
        }

        static void SetHttpClient(HttpClient httpClient)
        {
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                               ? "https://core.rasoulian.ir"
                               : "https://core.rasoulian.ir";

            httpClient.BaseAddress = new Uri(baseUrl);
        }
    }
}