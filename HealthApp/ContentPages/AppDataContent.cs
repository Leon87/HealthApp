using HealthApp.Dtos;
using HealthApp.Models;
using HealthApp.Shared;

namespace HealthApp.ContentPages;

public partial class AppDataContent : ContentPage
{
    private readonly IAppSettings _settings;
    private readonly SqlLiteConnectionFactory _connectionFactory;
    private readonly DataCrudOperations<AppDataDto> _dataCrudOperations;

    public AppDataContent(IAppSettings settings, SqlLiteConnectionFactory connectionFactory, DataCrudOperations<AppDataDto> dataCrudOperations)
    {
        _settings = settings;
        _connectionFactory = connectionFactory;
        _dataCrudOperations = dataCrudOperations;

        _connectionFactory.CreateConnection();
        object dataOject;
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
        goButton.Clicked += async (s, e) => dataOject = await _dataCrudOperations.GetAllAsync(AppData.ContentTypes[picker.SelectedIndex]);

        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Base App Data"
                }, picker, goButton
            }
        };
    }


}