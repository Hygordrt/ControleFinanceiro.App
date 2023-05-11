using ControleFinanceiro.App.Models;

namespace ControleFinanceiro.App.Repositories
{
    public interface ITransactionRepositories
    {
        void Add(Transaction transaction);
        void Delete(Transaction transaction);
        List<Transaction> GetAll();
        void Update(Transaction transaction);
    }
}