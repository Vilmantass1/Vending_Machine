using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class VendingMachine
    {
        public List<Items> Items { get; set; }
        public List<decimal> Coins { get; set; }

       public VendingMachine(List<Items> items, List<decimal> coins)
        {
            Items = items;
            Coins = coins;

        }
    }
}
