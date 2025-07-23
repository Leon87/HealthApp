using HealthApp.Models;
using HealthApp.Shared;

namespace HealthApp.ContentPages;

public class AppDataContent : ContentPage
{
    private readonly IAppSettings _settings;
    public AppDataContent(IAppSettings settings)
    {
        _settings = settings;

        var picker = new Picker();
        picker.ItemsSource = AppData.ContentTypes;
        picker.HeightRequest = 60;
        picker.Title = "Data Selection";
        picker.WidthRequest = _settings.ScreenWidth;
        picker.SelectedIndex = 0;

        var myGrid = new Grid();

        var goButton = new Button();
        goButton.Text = "Get Default Data";
        goButton.MaximumWidthRequest = _settings.ScreenWidth / 2;

        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Base App Data"
                }, picker, goButton
            }
        };
    }
}