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
            int userInput;
            int subtotal = 0;

            // Set up the initial inventory to purchase
            List<Inventory> inventoryList = new List<Inventory>();
            inventoryList.Add(new Inventory("Apple", 1));
            inventoryList.Add(new Inventory("Grapes", 2));
            inventoryList.Add(new Inventory("Mango", 3));

            // Ask the user to purchase stuff
            do
            {
                DisplayPurchaseOptions(inventoryList);
                userInput = GetPurchaseOption();

                // Update subtotal accordingly
                if (userInput > 0)
                {
                    subtotal = GetSubtotal(userInput, subtotal);
                }
            } while (userInput != 4);

            // Display the summary of the transaction
            if (subtotal > 0)
            {
                DisplaySummary(subtotal);
            }

            Console.WriteLine("Press any key to end the program.");
            Console.ReadKey();
        }

        /// <summary>
        /// Display purchase options for user
        /// </summary>
        static void DisplayPurchaseOptions(List<Inventory> inventoryList)
        {
            Console.WriteLine("Please choose from the following menu:");
            Console.WriteLine("1." + inventoryList[0].DisplayName());
            Console.WriteLine("2." + inventoryList[1].DisplayName());
            Console.WriteLine("3." + inventoryList[2].DisplayName());
            Console.WriteLine("4. exit");
            Console.WriteLine("Which one would you like to purchase?");
        }

        /// <summary>
        /// Get the purchasing option from the user
        /// </summary>
        /// <returns>0 if user didn't give the correct option, more than 0 if user gives an int</returns>
        static int GetPurchaseOption()
        {
            int userInput = 0;
            try
            {
                userInput = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number matching the selection!");
            }
            return userInput;
        }

        /// <summary>
        /// Get the subtotal based on user's input
        /// </summary>
        /// <param name="userInput">user's input RE: purchasing option</param>
        /// <returns>Subtotal based on input</returns>
        static int GetSubtotal(int userInput, int subtotal)
        {
            Console.Clear();
            switch (userInput)
            {
                case 1:
                    Console.WriteLine("You purchased an apple for $1.00");
                    subtotal += 1;
                    break;
                case 2:
                    Console.WriteLine("You purchased grapes for $2.00");
                    subtotal += 2;
                    break;
                case 3:
                    Console.WriteLine("You purchased a mango for $3.00");
                    subtotal += 3;
                    break;
                default:
                    Console.WriteLine("Please enter a number matching the selection!");
                    break;
            }
            Console.WriteLine();
            return subtotal;
        }

        /// <summary>
        /// Display summary of the purchase
        /// </summary>
        static void DisplaySummary(int subtotal)
        {
            double tax = (double)(subtotal) * (0.095);
            Console.WriteLine("Subtotal: ${0}", subtotal);
            Console.WriteLine("Tax (9.5%): ${0}", tax);
            Console.WriteLine("Total: ${0}", subtotal + tax);
        }
    }
}
