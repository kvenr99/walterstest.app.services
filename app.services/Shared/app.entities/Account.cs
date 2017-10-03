using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.entities
{
    public class Account
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
