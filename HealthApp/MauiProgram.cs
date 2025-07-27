using HealthApp.Dtos;
using HealthApp.Shared;
using Microsoft.Extensions.Logging;

namespace HealthApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<SqlLiteConnectionFactory>();
            builder.Services.AddSingleton<IAppSettings, AppSettings>();
            builder.Services.AddSingleton<DataCrudOperations<AppDataDto>>();
            builder.Services.AddSingleton<DataCrudOperations<FoodDto>>();
            builder.Services.AddSingleton<SeedingData>();

            return builder.Build();
        }
    }
}
