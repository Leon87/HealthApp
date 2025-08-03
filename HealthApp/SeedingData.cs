using HealthApp.Dtos;
using HealthApp.Shared;
using SQLite;

namespace HealthApp
{
    public class SeedingData
    {
        private readonly SqlLiteConnectionFactory _connectionFactory;

        public SeedingData(SqlLiteConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        private List<AppDataDto> appDataDtos = new List<AppDataDto>();

        public async Task SeedAppData()
        {
            AppDataDto MedicationData = new AppDataDto();
            AppDataDto FoodData = new AppDataDto();
            AppDataDto Medical = new AppDataDto();
            AppDataDto DrinkData = new AppDataDto();
            AppDataDto PooData = new AppDataDto();

            MedicationData.Id = "Medication";
            MedicationData.Contents =
                "Paracetamol," +
                "Infliximab," +
                "Codine," +
                "Asprin," +
                "Ant-acids," +
                "Lanzoprazole," +
                "Citirizine";

            FoodData.Id = "Food";
            FoodData.Contents =
                "Rice" +
                ",Curry" +
                ",Chicken" +
                ",Salad" +
                ",Fajitas" +
                ",Burgers" +
                ",Wedges" +
                ",RiceCakes" +
                ",Crisps" +
                ",Chocolate" +
                ",Yoghurt" +
                ",Banana" +
                ",Orange" +
                ",Kiwi" +
                ",Apple" +
                ",Pepperami" +
                ",Ham" +
                ",Cheese" +
                ",Peanuts" +
                ",RoastDinner" +
                ",Bolognese" +
                ",Nachos" +
                ",PastaBake" +
                ",Bacon" +
                ",Sausage" +
                ",HashBrown" +
                ",Tomatoes" +
                ",DietBars" +
                ",IceCream" +
                ",BombayMix" +
                ",Muffin";

            Medical.Id = "Medical";
            Medical.Contents =
                "Wind" +
                ",ChestPains" +
                ",Panic" +
                ",Stomach" +
                ",Tiredness" +
                ",Sickness";

            DrinkData.Id = "Drink";
            DrinkData.Contents =
                "Wine" +
                ",Juice" +
                ",Water" +
                ",Tea" +
                ",IPA" +
                ",Milk" +
                ",FizzyPop";

            PooData.Id = "Poop";
            PooData.Contents =
                "Type 1 - Rabbit" +
                ",Type 2" +
                ",Type 3" +
                ",Type 4 - Smooth Sausage" +
                ",Type 5" +
                ",Type 6" +
                ",Type 7 - Liquid";

            appDataDtos.Add(MedicationData);
            appDataDtos.Add(PooData);
            appDataDtos.Add(DrinkData);
            appDataDtos.Add(FoodData);
            appDataDtos.Add(Medical);

            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            await database.CreateTableAsync<AppDataDto>();
            await database.InsertAllAsync(appDataDtos);
        }
    }
}
