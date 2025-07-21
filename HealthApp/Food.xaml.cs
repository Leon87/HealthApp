using HealthApp.Dtos;
using HealthApp.Shared;
using SQLite;

namespace HealthApp;

public partial class Food : ContentPage
{
    private readonly SqlLiteConnectionFactory _connectionFactory;

    public Food()
    {
    }

    public Food(SqlLiteConnectionFactory connectionFactory)
    {
        InitializeComponent();
        _connectionFactory = connectionFactory;
    }

    private async Task CreateFood()
    {
        ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

        FoodDto food = new FoodDto
        {
            Amount = "Handful",
            Consumed = DateTime.Now,
            Food = "Peanuts"
        };

        await database.InsertAsync(food);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await CreateFood();
    }
}