namespace HealthApp.ContentPages;

public class Poop : ContentPage
{
    public Poop()
    {
        Content = new VerticalStackLayout
        {
            Children = {
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Record your pap consistency."
                }
            }
        };
    }
}