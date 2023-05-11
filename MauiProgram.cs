using ControleFinanceiro.App.Repositories;
using LiteDB;
using Microsoft.Extensions.Logging;

namespace ControleFinanceiro.App;

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
			})
			.RegisterDatabaseAndRepositories();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterDatabaseAndRepositories(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<LiteDatabase>(
			opitions =>
			{
				return new LiteDatabase($"Filename={AppSettings.DatabasePath};Connection=Shared");
            }
			);
		mauiAppBuilder.Services.AddTransient<ITransactionRepositories, TransactionRepositories>();
		return mauiAppBuilder;
	}
}
