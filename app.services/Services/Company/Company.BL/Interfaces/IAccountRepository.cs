using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.entities;

namespace Company.BL.Interfaces
{
    public interface IAccountRepository
    {
        List<Account> getAll();
   
        List<Account> getByName(string name);
        Account create(Account accountDetails);

        Account update(int id);

        int delete(int accountId);

    }
}
