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
        ChooseFoodObject();
    }

    private async void ChooseFoodObject()
    {
        var option1 = new Button { Text = "Breakfast" };
        option1.Clicked += async (s, e) =>
        {
            var breakfastItems = await _dataCrudOperations.GetAllKeysAsync("Breakfast");
            foreach (var item in breakfastItems.Contents.Split(","))
            {
                Foods.Add(new FoodList { Food = item });
            }
            SetPage();
        };

        var option2 = new Button { Text = "Lunch" };
        option2.Clicked += async (s, e) =>
        {
            var lunchItems = await _dataCrudOperations.GetAllKeysAsync("Lunch");
            foreach (var item in lunchItems.Contents.Split(","))
            {
                Foods.Add(new FoodList { Food = item });
            }
            SetPage();
        };

        var option3 = new Button { Text = "Dinner" };
        option3.Clicked += async (s, e) =>
        {
            var dinnerItems = await _dataCrudOperations.GetAllKeysAsync("Dinner");
            foreach (var item in dinnerItems.Contents.Split(","))
            {
                Foods.Add(new FoodList { Food = item });
            }
            SetPage();
        };
        var option4 = new Button { Text = "Sweet Snacks" };
        option4.Clicked += async (s, e) =>
        {
            var sweetSnackItems = await _dataCrudOperations.GetAllKeysAsync("SweetSnacks");
            foreach (var item in sweetSnackItems.Contents.Split(","))
            {
                Foods.Add(new FoodList { Food = item });
            }
            SetPage();
        };
        var option5 = new Button { Text = "Savory Snacks" };
        option5.Clicked += async (s, e) =>
        {
            var savorySnackItems = await _dataCrudOperations.GetAllKeysAsync("SavorySnacks");
            foreach (var item in savorySnackItems.Contents.Split(","))
            {
                Foods.Add(new FoodList { Food = item });
            }
            SetPage();
        };

        Content = new VerticalStackLayout
        {
            Children = { option1, option2, option3, option4, option5 }
        };
    }

    public class FoodList
    {
        public string Food { get; set; }
    }

    public void SetPage()
    {
        Label header = new Label
        {

            Text = "Food Selection",
            HorizontalOptions = LayoutOptions.Center
        };

        // Create the ListView.
        ListView listView = new ListView
        {
            HorizontalOptions = LayoutOptions.Center,
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
                foodButton.WidthRequest = 230;
                foodButton.Clicked += async (sender, args) => await AddToDiary(foodButton.Text);

                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        WidthRequest = 250,
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        Children =
                                {
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
            HorizontalOptions = LayoutOptions.Fill,
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
            Food = text,
            Consumed = DateTime.Now
        });

        await DisplayAlert("Info recorded", $"Your food \"{text}\" has been recorded", "OK");
    }
}