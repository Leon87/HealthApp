using HealthApp.Dtos;
using HealthApp.Shared;
using SQLite;
using System.Collections.ObjectModel;

namespace HealthApp.ContentPages;

public partial class Food : ContentPage
{
    private readonly SqlLiteConnectionFactory _connectionFactory;
    private readonly DataCrudOperations<FoodDto> _dataCrudOperations;
    public ObservableCollection<FoodList> Foods { get; set; } = new();

    public Food(DataCrudOperations<FoodDto> dataCrudOperations, SqlLiteConnectionFactory sqlLiteConnectionFactory)
    {
        _connectionFactory = sqlLiteConnectionFactory;
        _dataCrudOperations = dataCrudOperations;
        InitializeComponent();
        LoadData();
        SetPage();
    }

    private async void LoadData()
    {
        var items = await _dataCrudOperations.GetAllKeysAsync("Food");
        foreach (var item in items.Contents.Split(","))
        {

            Foods.Add(new FoodList { Food = item });
        }
    }

    public class FoodList
    {
        public string Food { get; set; }
    }

    public void SetPage()
    {
        Label header = new Label
        {
            Text = "ListView",
            HorizontalOptions = LayoutOptions.Center
        };

        // Create the ListView.
        ListView listView = new ListView
        {
            // Source of data items.
            ItemsSource = Foods,

            // Define template for displaying each item.
            // (Argument of DataTemplate constructor is called for 
            //      each item; it must return a Cell derivative.)
            ItemTemplate = new DataTemplate(() =>
            {

                // Create views with bindings for displaying each property.
                Button foodButton = new Button();
                foodButton.SetBinding(Button.TextProperty, "Food");

                foodButton.Clicked += async (sender, args) => await AddToDiary(foodButton.Text);

                /*                Label birthdayLabel = new Label();
                                birthdayLabel.SetBinding(Label.TextProperty,
                                    new Binding("Birthday", BindingMode.OneWay,
                                        null, null, "Born {0:d}"));
                */
                BoxView boxView = new BoxView();
                boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                                {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        HorizontalOptions = LayoutOptions.Fill,
                                        Spacing = 0,
                                        Children =
                                        {
                                            foodButton
                                        }
                                        }
                                }
                    }
                };
            })
        };

        // Build the page.
        this.Content = new StackLayout
        {
            Children =
                {
                    header,
                    listView
}
        };
    }

    private async Task AddToDiary(string text)
    {
        ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();
        await database.InsertAsync(new FoodDto
        {
            Food = text
        });

        await DisplayAlert("Info recorded", $"Your food \"{text}\" has been recorded", "OK");
    }
}