namespace HealthApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void StoolType_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Poop());
        }

        private async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

        private async void Other_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Other());
        }

        private async void AcidRecorder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Acid());
        }

        private async void EnterDrink_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Drink());
        }

        private async void EnterFood_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Food());
        }
    }

}
