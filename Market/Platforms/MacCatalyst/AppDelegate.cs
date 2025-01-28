using Foundation;

namespace Market
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

    public partial class GetDeviceInfo
    {
        public partial string GetDeviceID()
        {
            return "MacCatalyst";
        }
    }
}
