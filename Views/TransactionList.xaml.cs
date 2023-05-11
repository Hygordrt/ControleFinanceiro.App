namespace ControleFinanceiro.App.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

	public void OnButtonClicked_To_TransactionAdd(object sender, EventArgs args)
	{
		App.Current.MainPage = new TransactionAdd();
	}
}