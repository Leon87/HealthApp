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

            builder.Services.AddTransient<SeedingData>();

            builder.Services.AddTransient<DataCrudOperations<AppDataDto>>();
            builder.Services.AddTransient<DataCrudOperations<FoodDto>>();
            builder.Services.AddTransient<DataCrudOperations<MedicationDto>>();
            builder.Services.AddTransient<DataCrudOperations<DrinkDto>>();
            builder.Services.AddTransient<DataCrudOperations<MedicalDto>>();
            builder.Services.AddTransient<DataCrudOperations<PoopDto>>();
            builder.Services.AddTransient<DataCrudOperations<OtherDto>>();

            return builder.Build();
        }
    }
}
