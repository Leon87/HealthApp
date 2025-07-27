using HealthApp.ContentPages;

namespace HealthApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("AppDataContent", typeof(AppDataContent));
            Routing.RegisterRoute("About", typeof(About));
            Routing.RegisterRoute("Poop", typeof(Poop));
            Routing.RegisterRoute("Other", typeof(Other));
            Routing.RegisterRoute("Medical", typeof(Medical));
            Routing.RegisterRoute("Medication", typeof(Medication));
            Routing.RegisterRoute("Food", typeof(Food));
            Routing.RegisterRoute("Drink", typeof(Drink));

        }

        private async void StoolType_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Poop");
        }

        private async void About_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Poop");
        }

        private async void Other_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Other");
        }

        private async void MedicalRecorder_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Medical");
        }

        private async void EnterDrink_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Drink");
        }

        private async void EnterFood_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Food");
        }

        private async void Medication_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Medication");
        }

        private async void AppDataContent_Clicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("AppDataContent");

        }
    }

}
