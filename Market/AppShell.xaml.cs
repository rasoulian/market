using CommunityToolkit.Maui.Core;
using Market.Pages;
using Market.Services;

namespace Market
{
    public partial class AppShell : Shell
    {
        private readonly Plugin.LocalNotification.INotificationService _notificationService;
        private readonly Plugin.Maui.ScreenSecurity.IScreenSecurity _screenSecurity;
        private readonly PersianService _persianService;
        private readonly IPopupService _popupService;

        public AppShell()
        {
            InitializeComponent();
            _screenSecurity = ServiceHelper.GetService<Plugin.Maui.ScreenSecurity.IScreenSecurity>();
            _persianService = ServiceHelper.GetService<PersianService>();
            _notificationService = ServiceHelper.GetService<Plugin.LocalNotification.INotificationService>();
            _popupService = ServiceHelper.GetService<IPopupService>();



            //Routing.RegisterRoute($"//{nameof(AboutPage)}", typeof(AboutPage));
            Routing.RegisterRoute($"//{nameof(NotificationPage)}", typeof(NotificationPage));

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var status = PermissionStatus.Unknown;

            status = await Permissions.RequestAsync<Permissions.PostNotifications>();
            if (status != PermissionStatus.Granted)
            {
                //await DisplayAlert("Permission Required", "location permission is required!", "Ok");
            }

            status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                //await DisplayAlert("Permission Required", "location permission is required!", "Ok");
            }


#if ANDROID
            _screenSecurity.ActivateScreenSecurityProtection();
#endif

#if IOS
            _screenSecurity.ActivateScreenSecurityProtection(true, true, true);
#endif

            await Task.WhenAll(OnWelcome(), OnTips(), OnUpdates()).ConfigureAwait(false);
        }

        private Task OnWelcome()
        {
            return _notificationService.Show(new Plugin.LocalNotification.NotificationRequest
            {
                NotificationId = 145613,
                Title = "دکتر سارا سادات محبوب",
                Subtitle = "145613",
                Description = $"جراح و متخصص زنان و زایمان\nبیمار عزیز خوش آمدید.\n{_persianService.GetTime()}\n{_persianService.GetDate().Replace('/', '.')}",
                BadgeNumber = 1,
                CategoryType = Plugin.LocalNotification.NotificationCategoryType.Status,

                Schedule = new Plugin.LocalNotification.NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1),
                },
                Sound = DeviceInfo.Platform == DevicePlatform.Android ? "notif" : "notif.mp3",
            });
        }

        private Task OnTips()
        {
            var tips = new List<(string Title, string Description)>
            {
                ("تقویت حافظه جنین","توصیه یک"),
                ("بارداری ناخواسته پس از زایمان","توصیه دو"),
                ("بعد از زایمان بدنسازی ممنوع","توصیه سه"),
                ("اولین پریود پس از زایمان","توصیه چهار"),
                ("استفاده از تجارب والدین","توصیه پنج"),
                ("کوچک شدن شکم بعد از زایمان","توصیه شش"),
                ("آموزش توالت و از پوشک گرفتن بچه","توصیه هفت"),
                ("بررسی تست تحمل قند برای دیابت بارداری بعد 6هفته از زایمان","توصیه هشت"),
            };
            int index = Random.Shared.Next(tips.Count);
            return _notificationService.Show(new Plugin.LocalNotification.NotificationRequest
            {
                NotificationId = 145614,
                Title = tips[index].Title,
                Subtitle = "توصیه پزشکی",
                Description = tips[index].Description,
                BadgeNumber = 1,
                CategoryType = Plugin.LocalNotification.NotificationCategoryType.Status,

                Schedule = new Plugin.LocalNotification.NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(10),
                },
                Sound = DeviceInfo.Platform == DevicePlatform.Android ? "notif" : "notif.mp3",
            });
        }


        private Task OnUpdates()
        {
            bool newVer = false;
            if (newVer) return Task.CompletedTask;

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(3000);
                this._popupService.ShowPopup<ViewModels.UpdateViewModel>();
                Vibration.Default.Vibrate(TimeSpan.FromSeconds(1));
            });
            return Task.CompletedTask;
        }

    }
}
