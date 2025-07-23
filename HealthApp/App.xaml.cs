using HealthApp.Dtos;
using HealthApp.Shared;
using SQLite;

namespace HealthApp
{
    public partial class App : Application
    {
        private readonly SqlLiteConnectionFactory _connectionFactory;

        public App(SqlLiteConnectionFactory connectionFactory)
        {
            InitializeComponent();
            _connectionFactory = connectionFactory;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override async void OnStart()
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();
            await database.CreateTableAsync<FoodDto>();

            base.OnStart();
        }
    }
}