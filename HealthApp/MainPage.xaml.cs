namespace HealthApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        private async void Medication_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Medication());
        }
    }

}
