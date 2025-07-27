namespace HealthApp.ContentPages;

public class Food : ContentPage
{
    public Food()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Record any Food"
                }
            }
        };
    }
}