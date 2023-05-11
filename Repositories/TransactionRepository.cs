using ControleFinanceiro.App.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.App.Repositories
{
    public class TransactionRepositories : ITransactionRepositories
    {
        
        private readonly LiteDatabase _database;
        private readonly string collectionName = ("transactions");
        //Local do banco de dados
        public TransactionRepositories(LiteDatabase database)
        {
            _database = database;
        }
        //Lista tranzasoes/buscar dados do banco
        public List<Transaction> GetAll()
        {
            return _database
                .GetCollection<Transaction>(collectionName)
                .Query()
                .OrderByDescending(a=>a.Date)
                .ToList();
        }
        //Adisionar tranzasoes
        public void Add(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectionName);
            col.Insert(transaction);
            col.EnsureIndex(a => a.Date);
        }
        //Atualizar tranzasoes
        public void Update(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectionName);
            col.Update(transaction);
        }
        //Deletar tranzasoes
        public void Delete(Transaction transaction)
        {
            var col = _database.GetCollection<Transaction>(collectionName);
            col.Delete(transaction.Id);
        }
    }
}
