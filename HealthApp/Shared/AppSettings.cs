namespace HealthApp.Shared
{
    public class AppSettings : IAppSettings
    {
        public double ScreenWidth { get; set; } = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density / 2 - 10;
    }
}
