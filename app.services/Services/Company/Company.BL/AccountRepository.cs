using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.BL.Interfaces;
using app.entities;
using MongoDB.Driver;
using MongoDB.Bson;
using app.common;
using System.Configuration;

namespace Company.BL
{
  
    public class AccountRepository : IAccountRepository
    {
        string connectionString = ConfigurationManager.AppSettings["connectionstring"];

        public List<Account> getByName(string name)
        {

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("company");
            List<Account> accountCollection = db.GetCollection<Account>("account").AsQueryable().Select(x => new Account { Id=x.Id, Number = x.Number, Balance = x.Balance, Name = x.Name }).ToList();
            fuzzySearch.Search(name, accountCollection, 0.70);
            return accountCollection;
        }

        public List<Account> getAll()
        {

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("company");
            List<Account> accountCollection = db.GetCollection<Account>("account").AsQueryable().Select(x => new Account {Id = x.Id, Number = x.Number, Balance = x.Balance, Name = x.Name }).ToList();
            return accountCollection;
        }

      

        public Account create(Account accountDetails)
        {
            throw new NotImplementedException();
        }

        public Account update(int id) {
           throw new NotImplementedException();
        }

        public int delete(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
