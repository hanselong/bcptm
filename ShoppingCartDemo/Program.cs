using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDemo
{
    class Program
    {
        static List<Inventory> _inventoryList;

        static Program()
        {
            // Set up the initial inventory to purchase
            InventoryList defaultList = new InventoryList();
            _inventoryList = defaultList.List;
        }

        static void Main(string[] args)
        {
            int userInput;
            int subtotal = 0;

            // Ask the user to purchase stuff
            do
            {
                DisplayMenuOptions();
                userInput = GetPurchaseOption();
                subtotal = RespondToMenu(userInput, subtotal);
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
        /// Display the menu options
        /// </summary>
        static void DisplayMenuOptions()
        {
            Console.WriteLine("Welcome to the shopping cart demo.  Please choose from the following options:");
            Console.WriteLine("1. Purchase items");
            Console.WriteLine("2. Remove items");
            Console.WriteLine("3. Display shopping cart");
            Console.WriteLine("4. Check out");
        }

        /// <summary>
        /// Responds to menu selection
        /// </summary>
        /// <param name="userInput">User selection</param>
        static int RespondToMenu(int userInput, int subtotal)
        {
            switch (userInput)
            {
                case 1:
                    subtotal = AllowPurchasing(subtotal);
                    break;
                case 2:
                    // TODO: Not yet implemented
                    break;
                case 3:
                    // TODO: Not yet implemented
                    break;
                case 4:
                    // User is exiting.  Do nothing.
                    break;
                case 5:
                    Console.WriteLine("Invalid input.  Please try again.");
                    break;
            }
            return subtotal;
        }

        /// <summary>
        /// Allow user to keep purchasing stuff
        /// </summary>
        static int AllowPurchasing(int subtotal)
        {
            int userInput = 0;
            int listSize = _inventoryList.Count;
            do
            {
                DisplayPurchaseOptions();
                userInput = GetPurchaseOption();

                // Update subtotal accordingly
                if (userInput > 0)
                {
                    subtotal = GetSubtotal(userInput, subtotal);
                }
            } while (userInput != listSize);

            return subtotal;
        }

        /// <summary>
        /// Display purchase options for user
        /// </summary>
        static void DisplayPurchaseOptions()
        {
            int listSize = _inventoryList.Count;
            Console.WriteLine("Please choose from the following menu:");

            for (int i = 0; i < listSize; i++)
            {
                Console.WriteLine("{0}. {1}", (i + 1), _inventoryList[i].DisplayName());
            }
            Console.WriteLine("{0}. Finish purchasing", (listSize + 1));
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

            int listSize = _inventoryList.Count;
            userInput = userInput - 1;
            if (userInput < listSize)
            {
                Console.WriteLine("You purchased: {0}", _inventoryList[userInput].DisplayName());
                subtotal += _inventoryList[userInput].Price;
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
