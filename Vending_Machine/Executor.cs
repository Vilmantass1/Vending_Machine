using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Executor : IExecutor
    {

        public void Run()
        {
            VendingMachineLoader();
        }


       // public void Meniu


        public void VendingMachineLoader()
        {
            Console.Clear();
            var solved = false;

            while (!solved)
            {


                List<Items> ItemList = new List<Items>() { new Items("Snickers", 1.5m), new Items("Mars", 1.7m), new Items("Twix", 1.8m) }; // list of items that are currently in Vending Machine

                List<decimal> CoinList = new List<decimal>() {2,2,2,2,2,1,1,1,1,1,0.5m, 0.5m, 0.5m, 0.5m, 0.5m, 0.2m, 0.2m, 0.2m, 0.2m, 0.2m, 0.2m,
                0.1m, 0.1m, 0.1m, 0.1m, 0.1m, 0.05m, 0.05m, 0.05m, 0.05m, 0.05m, 0.02m,0.02m,0.02m,0.02m,0.02m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m }; // list of Coins that are currently in Vending Machine
                CoinList.OrderByDescending(x=>x);

                List<decimal> UsedCoins = new List<decimal>() { }; // List of Coins that are removed from Vending Machine and to be given as a change.

                var VendingMachine = new VendingMachine(ItemList, CoinList);

                Console.WriteLine("Welcome to our Vending Machine. Please select item No. and press enter");
                var count = -1; // item no counter
                foreach (var item in VendingMachine.Items)
                {
                    count++;
                    Console.WriteLine($"Please input {count} to buy {item.ItemName} for {item.Price} Eur"); // prints current list of items in the Vending Machine, so that user could select item id
                }

                var SelectedItem = Console.ReadLine();
                Console.WriteLine("\n");
          
                decimal change = 0;
                decimal remainingAmount = 0;
                if (int.TryParse(SelectedItem, out var SelectedItemNumber) && SelectedItemNumber < VendingMachine.Items.Count())
                {
                    Console.WriteLine("Please type (2, 5) and click enter to insert Coins"); // add if to not accept certain coins
                    Console.WriteLine("\n");
                    var UserInput = Console.ReadLine(); ; // Money that user inserted into vending Machine
                    if (int.TryParse(UserInput, out var UserInputCoin) && UserInputCoin == 2 || UserInputCoin == 5)
                    {

                        if (UserInputCoin >= VendingMachine.Items.ElementAt(SelectedItemNumber).Price) // User Input coins have to be greater or equal value than selected item
                        {
                            change = UserInputCoin - VendingMachine.Items.ElementAt(SelectedItemNumber).Price;
                            remainingAmount = change;

                            foreach (var coin in CoinList)
                            {
                                if (remainingAmount / coin >= 1) // remaining amout for change divided by coin In Vending Machine (tests all coins from largest to smalles) if result is intiger then coin is used to give a change, repeats until remaining amount is 0.
                                {
                                    remainingAmount = remainingAmount - coin;
                                    UsedCoins.Add(coin); // adds coins to a new list so that we can display coins that user gets as a change and later remove from VendingMachine

                                }

                                if (remainingAmount == 0)
                                {
                                    foreach (var item in UsedCoins)
                                    {
                                        CoinList.Remove(item); // removes coin from VendingMachine coin list, because these coins were given as a change
                                    }
                                    break;
                                }
                            }

                            // change for the user
                            Console.WriteLine("Please take your change");

                            foreach (var coin in UsedCoins)
                            {
                                Console.WriteLine(coin);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance to buy selected item");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have inserted a coin that is not supported. Please enter 2 or 5 nominal coin and start over again");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");

                    }
                }
              
                else
                {
                    Console.WriteLine("Please enter numeric value from a list");
                    Console.WriteLine("\n");
                }



            }
        }

    }
}
