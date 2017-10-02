using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.entities;

namespace LoanBL.Interfaces
{
    public interface IAccount
    {
        List<account> getAll();
        account getById(int id);
        List<account> getByName(string name);
        account create(account accountDetails);

        account update(int id);

        int delete(int accountId);

    }
}
