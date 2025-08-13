using HealthApp.ContentPages;
using HealthApp.Dtos;
using HealthApp.Shared;
using Newtonsoft.Json;

namespace HealthApp
{
    public partial class MainPage : ContentPage
    {
        private readonly SqlLiteConnectionFactory _connectionFactory;
        public MainPage(SqlLiteConnectionFactory connectionFactory)
        {

            InitializeComponent();
            Routing.RegisterRoute("AppDataContent", typeof(AppDataContent));
            Routing.RegisterRoute("About", typeof(About));
            Routing.RegisterRoute("Poop", typeof(Poop));
            Routing.RegisterRoute("Other", typeof(Other));
            Routing.RegisterRoute("Medical", typeof(Medical));
            Routing.RegisterRoute("Medication", typeof(Medication));
            Routing.RegisterRoute("Drink", typeof(Drink));

            Routing.RegisterRoute("Food", typeof(Food));
            _connectionFactory = connectionFactory;

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
            //await Navigation.PushAsync(new Food());
        }

        private async void Medication_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Medication");
        }

        private async void AppDataContent_Clicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("AppDataContent");

        }

        private async void ExportAppContent_Clicked(object sender, EventArgs e)
        {
            var db = _connectionFactory.CreateConnection();
            var eatenFoods = await db.Table<FoodDto>().ToListAsync();

            // Write the file content to the app data directory  
            var targetFileName = "FoodsConsumed.json";
            string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            using FileStream outputStream = File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(JsonConvert.SerializeObject(eatenFoods));
        }
    }

}
