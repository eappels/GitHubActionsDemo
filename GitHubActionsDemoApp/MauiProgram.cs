﻿using GitHubActionsDemoApp.Data.Models;
using GitHubActionsDemoApp.Data.Repositories;
using GitHubActionsDemoApp.Interfaces;
using GitHubActionsDemoApp.ViewModels;
using GitHubActionsDemoApp.Views;
using Microsoft.Extensions.Logging;

namespace GitHubActionsDemoApp;

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

        builder.Services.AddSingleton<IRepository<DemoContact>, ContactRepository>();

        builder.Services.AddSingleton<DemoViewModel>();
        builder.Services.AddTransient<DemoView>();

        return builder.Build();
    }
}