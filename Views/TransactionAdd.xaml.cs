using ControleFinanceiro.App.Models;
using System.Text;
using System.Transactions;

namespace ControleFinanceiro.App.Views;

public partial class TransactionAdd : ContentPage
{
	public TransactionAdd()
	{
		InitializeComponent();

        
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void OnButtonClicked_Save(object sender, EventArgs e)
    {
        if( IsValidData() == false ) 
            return;

        Transaction transaction = new Transaction();
        {
            Type = TransactionType.Income || TransactionType.Expenses
            Name = EntryName.Text,
        }

        //TODO - Salvar no Banco (Pegar os dados, Criar obj Transaction, Enviar Repository)
        //TODO - Fechar a Tela*
    }

    private bool IsValidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text)) 
        {
            sb.AppendLine("O campo 'Nome' deve ser preenchido!");
            valid = false;
        }

        if (string.IsNullOrEmpty(EntryVaule.Text) || string.IsNullOrWhiteSpace(EntryVaule.Text))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido!");
            valid = false;
        }
        double result;
        if((string.IsNullOrEmpty(EntryVaule.Text) && !double.TryParse(EntryVaule.Text, out result)))
        {
            sb.AppendLine("O campo 'Valor' e inválido!");
            valid |= false;
        }

        if(valid == false)
        {
            LabelError.Text = sb.ToString();
        }
        return valid;
    }
}