namespace HealthApp.ContentPages;

public class Drink : ContentPage
{
    public Drink()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Record any liquids"
                }
            }
        };
    }
}