using HealthApp.Dtos;
using System.Collections.ObjectModel;

namespace HealthApp.ContentPages;

public partial class Food : ContentPage
{

    private readonly DataCrudOperations<FoodDto> _dataCrudOperations;
    public ObservableCollection<string> Foods { get; set; } = new();

    public Food(DataCrudOperations<FoodDto> dataCrudOperations)
    {
        _dataCrudOperations = dataCrudOperations;
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        var items = await _dataCrudOperations.GetAllKeysAsync("Food");
        foreach (var item in items.Contents.Split(","))
        {
            Foods.Add(item);
        }
    }
}