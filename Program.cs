using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace thu_trong_tuan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                typeofcustumer();

                string choice = Getchoice();
                if(choice == "5")
                {
                    break;
                }

                Console.WriteLine("Enter custumer name: ");
                string custumername = Console.ReadLine();

                Console.WriteLine("Enter the previous month water number: ");
                int previousmonthwaternumber;
                while (!int.TryParse(Console.ReadLine(), out previousmonthwaternumber) || previousmonthwaternumber < 0)
                {
                    Console.WriteLine("Re-enter");
                }

                Console.WriteLine("Enter this month water number: ");
                int thismonthwaternumner;
                while (!int.TryParse(Console.ReadLine(), out thismonthwaternumner) || thismonthwaternumner < 0)
                {
                    Console.WriteLine("Re-enter"); 
                }
                while (thismonthwaternumner < previousmonthwaternumber)
                {
                    Console.WriteLine("Re-enter");
                    thismonthwaternumner = int.Parse(Console.ReadLine());
                }

                int amountofwaterconsumed = thismonthwaternumner - previousmonthwaternumber;


                double price = waterbill(thismonthwaternumner - previousmonthwaternumber, choice );

                double bill = Getbill(price);

                double total = Gettotal(bill);


                Console.WriteLine("---Water Bill---");
                Console.WriteLine("Custumer name is: " + custumername );
                Console.WriteLine("Amount of water consumed: " + amountofwaterconsumed + "m3" );
                Console.WriteLine("Water fee is: " +  price + "VND");
                Console.WriteLine("Water fee include environment fee is: " + bill + "VND");
                Console.WriteLine("Total water bill payable is: " + total + "VND");

                Console.ReadLine();
                Console.Clear();
            }

        }
        
        
        static void typeofcustumer()
        {
            Console.WriteLine("1: household");
            Console.WriteLine("2: public services");
            Console.WriteLine("3: production units");
            Console.WriteLine("4: bussiness services");
            Console.WriteLine("5: exit");
        }
        static string Getchoice()
        {
            Console.WriteLine("enter your choose");
            string choice = Console.ReadLine();
            while (choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5")
            {
                Console.WriteLine("Re-enter");
                choice = Console.ReadLine();
            }
            return choice;
        }

        
        static double waterbill(int amountofwaterconsumed, string choice)
        {
            double waterpricebelow10m3 = 5.973; 
            double waterpriceto10from20m3 = 7.052;
            double waterpriceto200from30m3 = 8.699;
            double waterpriceabove30m3 = 15.929;
            double publicservices = 9.955;
            double productionunits = 11.615;
            double bussinessservices = 22.068;
        
            double price = 0;

            switch (choice)
            {
                case "1":
                    if (amountofwaterconsumed <= 10)
                    {
                        price = (amountofwaterconsumed * waterpricebelow10m3);
                    }
                    else if (amountofwaterconsumed > 10 && amountofwaterconsumed <= 20)
                    {
                        price = (10 * 5.973) + ((amountofwaterconsumed - 10) * 7.052);
                    }
                    else if (amountofwaterconsumed > 20 && amountofwaterconsumed <= 30)
                    {
                        price = (10 * 5.973) + (10 * 7.052) + ((amountofwaterconsumed - 20) * 8.699);
                    }
                    else
                    {
                        price = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + ((amountofwaterconsumed - 30) * 15.929);
                    }
                    break;
                case "2":
                    price = (amountofwaterconsumed * 9.955);
                    break;
                case "3":
                    price = (amountofwaterconsumed * 11.615);
                    break;
                case "4":
                    price = amountofwaterconsumed * 22.068;
                    break;
            }

            
            return price;
        }
        static double Getbill(double price)
        {
            double EVF = 0.1;
            double bill = 0;
            bill = (price * 0.1) + price;

            return bill;
        }
        static double Gettotal(double bill)
        {
            double VAT = 0.1;
            double total = 0;
            total = (bill * 0.1) + bill;

            return total;
        }
        

    }   
}
