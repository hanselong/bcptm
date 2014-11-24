using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose from the following menu:");
            Console.WriteLine("1. Apple $1.00");
            Console.WriteLine("2. Grapes $2.00");
            Console.WriteLine("3. Mango $3.00");
            Console.WriteLine("Which one would you like to purchase?");

            int userInput = 0;
            try
            {
                userInput = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number matching the selection!");
            }

            if (userInput > 0)
            {
                int subtotal = 0;
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("You purchased an apple for $1.00");
                        subtotal = 1;
                        break;
                    case 2:
                        Console.WriteLine("You purchased grapes for $2.00");
                        subtotal = 2;
                        break;
                    case 3:
                        Console.WriteLine("You purchased a mango for $3.00");
                        subtotal = 3;
                        break;
                    default:
                        Console.WriteLine("Please enter a number matching the selection!");
                        break;
                }

                if (subtotal > 0)
                {
                    double tax = (double)(subtotal) * (0.095);
                    Console.WriteLine("Tax (9.5%): {0}", tax);
                    Console.WriteLine("Total: {0}", subtotal + tax);
                }
            }

            Console.WriteLine("Press any key to end the program.");
            Console.ReadKey();
        }
    }
}
