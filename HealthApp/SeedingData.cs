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
            AppDataDto DbUpdate = new AppDataDto();
            AppDataDto MedicationData = new AppDataDto();
            AppDataDto FoodData = new AppDataDto();
            AppDataDto Medical = new AppDataDto();
            AppDataDto DrinkData = new AppDataDto();
            AppDataDto PooData = new AppDataDto();
            AppDataDto BreakfastData = new AppDataDto();
            AppDataDto LunchData = new AppDataDto();
            AppDataDto DinnerData = new AppDataDto();
            AppDataDto SweetSnacksData = new AppDataDto();
            AppDataDto SavorySnacksData = new AppDataDto();

            DbUpdate.Id = "DbUpdate";
            DbUpdate.Contents = "20250824";

            MedicationData.Id = "Medication";
            MedicationData.Contents =
                "Paracetamol," +
                "Infliximab," +
                "Codine," +
                "Asprin," +
                "Ant-acids," +
                "Lanzoprazole," +
                "Citirizine";

            BreakfastData.Id = "Breakfast";
            BreakfastData.Contents =
                "Porridge" +
                ",Eggs" +
                ",Bacon" +
                ",Sausage" +
                ",Toast" +
                ",Cereal" +
                ",Fruit" +
                ",Yoghurt";

            LunchData.Id = "Lunch";
            LunchData.Contents =
                "Sandwich" +
                ",Soup" +
                ",Salad" +
                ",Pasta" +
                ",Rice" +
                ",Wraps" +
                ",Burgers" +
                ",Fries";

            DinnerData.Id = "Dinner";
            DinnerData.Contents =
                "Rice" +
                ",Curry" +
                ",Chicken" +
                ",Salad" +
                ",Fajitas" +
                ",Burgers" +
                ",Wedges" +
                ",RoastDinner" +
                ",Bolognese" +
                ",Nachos" +
                ",PastaBake";

            SweetSnacksData.Id = "SweetSnacks";
            SweetSnacksData.Contents =
                "Chocolate" +
                ",DietBars" +
                ",IceCream" +
                ",Cookie";

            SavorySnacksData.Id = "SavorySnacks";
            SavorySnacksData.Contents =
                "RiceCakes" +
                ",Crisps" +
                ",BombayMix" +
                ",Muffin";


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
            appDataDtos.Add(DbUpdate);
            appDataDtos.Add(BreakfastData);
            appDataDtos.Add(LunchData);
            appDataDtos.Add(DinnerData);
            appDataDtos.Add(SweetSnacksData);
            appDataDtos.Add(SavorySnacksData);

            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            await database.CreateTableAsync<AppDataDto>();
            await database.CreateTableAsync<FoodDto>();
            await database.InsertAllAsync(appDataDtos);
        }
    }
}
