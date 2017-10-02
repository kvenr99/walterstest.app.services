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
  
    public class Account : IAccount
    {
        string connectionString = ConfigurationManager.AppSettings["connectionstring"];

        public List<account> getByName(string name)
        {
            
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("company");
            List<account> accountCollection = db.GetCollection<account>("account").AsQueryable().Select(x => new account { Number = x.Number, Balance = x.Balance, Name = x.Name }).ToList();
            fuzzySearch.Search(name, accountCollection, 0.70);
            return accountCollection;
        }

        public List<account> getAll()
        {

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("company");
            List<account> accountCollection = db.GetCollection<account>("account").AsQueryable().Select(x => new account {Id = x.Id, Number = x.Number, Balance = x.Balance, Name = x.Name }).ToList();
            return accountCollection;
        }

        public account getById(int id)
        {

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("company");
            account accountDetails = db.GetCollection<account>("account").AsQueryable().Where(x => x.Id == id).Select(x => new account { Id = x.Id, Number = x.Number, Balance = x.Balance, Name = x.Name }).FirstOrDefault();
           
            return accountDetails;
        }

        public account create(account accountDetails)
        {
            throw new NotImplementedException();
        }

        public account update(int id) {
           throw new NotImplementedException();
        }

        public int delete(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
