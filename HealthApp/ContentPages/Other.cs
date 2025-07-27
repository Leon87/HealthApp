namespace HealthApp.ContentPages;

public class Other : ContentPage
{
    public Other()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "A bucket to record anything that is not included in the app"
                }
            }
        };
    }
}