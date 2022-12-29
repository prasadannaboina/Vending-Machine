using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interfaces;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var vm = new VendingMachine(new CoinService(), new ProductService(new ProductData(), new ProductInventoryData()));

            //case 1 - invalid coins            
            Console.WriteLine("\ncase 1 - invalid coins\n");
            WriteVendingResponseToScreen(vm.AcceptCoin(new InputCoin() { Weight = 3.25m, Diameter = 18.0m, Thickness = 1.70000m }));

            //case 2 - valid coins,return coins            
            Console.WriteLine("\ncase 2 - valid coins,return coins\n");
            WriteVendingResponseToScreen(vm.AcceptCoin(new InputCoin() { Weight = 3.25m, Diameter = 18.0m, Thickness = 1.70m }));
            WriteItemChangeToScreen(vm.ReturnCoins());

            //case 3 - valid coins, invalid product code           
            Console.WriteLine("\ncase 3 - valid coins, invalid product code\n");
            WriteVendingResponseToScreen(vm.AcceptCoin(new InputCoin() { Weight = 3.25m, Diameter = 18.0m, Thickness = 1.70m }));
            WriteVendingResponseToScreen(vm.SelectProduct("COOL1"));

            //case 4 - valid coins, valid product code, less amount entered            
            Console.WriteLine("\ncase 4 - valid coins, valid product code, less amount entered\n");
            WriteVendingResponseToScreen(vm.AcceptCoin(new InputCoin() { Weight = 3.25m, Diameter = 18.0m, Thickness = 1.70m }));
            WriteVendingResponseToScreen(vm.SelectProduct("COLA1"));

            //case 5 - valid coins, valid product code, more amount entered, make change            
            Console.WriteLine("\ncase 5 - valid coins, valid product code, more amount entered, make change\n");
            WriteVendingResponseToScreen(vm.AcceptCoin(new InputCoin() { Diameter = 28.4m, Thickness = 2.5m, Weight = 12.0m }));
            WriteVendingResponseToScreen(vm.SelectProduct("CHIPS1"));

            //case 6 - valid coins, valid product code, correct(>=) amount entered, sold out            
            Console.WriteLine("\ncase 6 - valid coins, valid product code, correct(>=) amount entered, sold out\n");
            WriteVendingResponseToScreen(vm.AcceptCoin(new InputCoin() { Diameter = 22.5m, Thickness = 3.15m, Weight = 9.5m }));
            WriteVendingResponseToScreen(vm.SelectProduct("CANDY1"));

            //case 7 - valid coins, valid product code, correct(>=) amount entered, sold out, return coins            
            Console.WriteLine("\ncase 7 - valid coins, valid product code, correct(>=) amount entered, sold out, return coins\n");
            WriteVendingResponseToScreen(vm.AcceptCoin(new InputCoin() { Diameter = 22.5m, Thickness = 3.15m, Weight = 9.5m }));
            WriteVendingResponseToScreen(vm.SelectProduct("CANDY1"));
            WriteItemChangeToScreen(vm.ReturnCoins());

            Console.ReadLine();
        }

        static void WriteVendingResponseToScreen(VendingResponse response)
        {
            Console.WriteLine("Message : " + response.Message);
            Console.WriteLine("IsRejectedCoin : " + response.IsRejectedCoin);

            if (response.RejectedCoin != null)
            {
                Console.WriteLine("Coin Diameter: " + response.RejectedCoin.Diameter);
                Console.WriteLine("Coin Weight: " + response.RejectedCoin.Weight);
                Console.WriteLine("Coin Thickness: " + response.RejectedCoin.Thickness);
            }

            if (response.Change != null)
                WriteItemChangeToScreen(response.Change);

            Console.WriteLine("IsSuccess : " + response.IsSuccess);
        }

        static void WriteItemChangeToScreen(IEnumerable<ItemChange> change)
        {
            Console.WriteLine("\nChange Returned\n");

            foreach (var item in change)
            {
                switch (item.Type)
                {
                    case CoinType.Nickels:
                        Console.WriteLine("No Of 5 Nickels : " + item.Number);
                        break;
                    case CoinType.Dimes:
                        Console.WriteLine("No Of 10 Dimes : " + item.Number);
                        break;
                    case CoinType.Quarters:
                        Console.WriteLine("No Of 20 Quarters : " + item.Number);
                        break;
                    case CoinType.Pennies:
                        Console.WriteLine("No Of 50 Pennies : " + item.Number);
                        break;             
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

        }
    }
}