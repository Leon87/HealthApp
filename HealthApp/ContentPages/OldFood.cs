using HealthApp.Dtos;

namespace HealthApp.ContentPages;

public class OldFood : ContentPage
{
    private List<FoodDto> _food;
    private readonly DataCrudOperations<FoodDto> _dataCrudOperations;
    public OldFood(DataCrudOperations<FoodDto> dataCrudOperations)
    {
        _dataCrudOperations = dataCrudOperations;

        Task.Run(async () =>
        {
            SetFood();
        });

        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Record any Food"
                }
            }
        };
    }

    public async void SetFood()
    {
        _food = await _dataCrudOperations.GetAllAsync("Food");
    }
}