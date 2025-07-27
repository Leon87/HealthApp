using HealthApp.Dtos;
using HealthApp.Shared;
using SQLite;

namespace HealthApp
{
    public partial class App : Application
    {
        private readonly SqlLiteConnectionFactory _connectionFactory;
        private readonly SeedingData _seedingData;

        public App(SqlLiteConnectionFactory connectionFactory, SeedingData seedingData)
        {
            InitializeComponent();
            _connectionFactory = connectionFactory;
            _seedingData = seedingData;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override async void OnStart()
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            try
            {
                await database.GetAsync<AppDataDto>(x => true);
            }
            catch (Exception e)
            {
                await _seedingData.SeedAppData();
            }

            base.OnStart();
        }
    }
}