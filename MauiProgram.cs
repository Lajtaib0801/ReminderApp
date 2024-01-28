using CommunityToolkit.Maui;
using Lajtai_Benjamin_ReminderApp.ViewModels;
using Microsoft.Extensions.Logging;

namespace Lajtai_Benjamin_ReminderApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa_solid.ttf", "fasolid");
                });
            builder.Services.AddSingleton<ManageEventPage>();

            builder.Services.AddSingleton<ModifyEventPage>();
            builder.Services.AddSingleton<ModifyEventViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
