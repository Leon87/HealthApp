namespace HealthApp.ContentPages;

public class Medical : ContentPage
{
    public Medical()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Record any medical issues"
                }
            }
        };
    }
}