using ControleFinanceiro.App.Views;

namespace ControleFinanceiro.App;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(  new TransactionList() );
	}
}
