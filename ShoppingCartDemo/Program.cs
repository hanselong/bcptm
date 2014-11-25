using System;
using System.Collections.Generic;

namespace ShoppingCartDemo
{
    class Program
    {
        static List<Inventory> _inventoryList;
        static List<Inventory> _cart;

        static Program()
        {
            // Set up the initial inventory to purchase
            InventoryList defaultList = new InventoryList();
            _inventoryList = defaultList.List;

            // Initialize empty shopping cart
            _cart = new List<Inventory>();
        }

        static void Main(string[] args)
        {
            int userInput;

            // Display shopping cart
            do
            {
                DisplayMenuOptions();
                userInput = GetPurchaseOption();
                RespondToMenu(userInput);
            } while (userInput != 4);

            // Display the summary of the transaction
            DisplaySummary();

            Console.WriteLine("Press any key to end the program.");
            Console.ReadKey();
        }

        /// <summary>
        /// Display the menu options
        /// </summary>
        static void DisplayMenuOptions()
        {
            Console.Clear();
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
        static void RespondToMenu(int userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case 1:
                    AllowPurchasing();
                    break;
                case 2:
                    // TODO: Not yet implemented
                    Console.WriteLine("Sorry this feature is not yet implemented.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    break;
                case 3:
                    DisplayCart();
                    break;
                case 4:
                    // User is exiting.  Do nothing.
                    break;
                default:
                    Console.WriteLine("Invalid input.  Please try again.");
                    break;
            }
        }

        /// <summary>
        /// Display everything currently in the shopping cart.
        /// </summary>
        static void DisplayCart()
        {
            int cartSize = _cart.Count;
            Console.WriteLine("There are {0} items in your cart.", cartSize);
            Console.WriteLine("Your cart has the following items:");
            foreach(Inventory item in _cart)
            {
                Console.WriteLine(item.DisplayName());
            }

            // Display summary
            Console.WriteLine();
            Console.WriteLine("If you were to check out now:");
            DisplaySummary();

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Allow user to keep purchasing stuff
        /// </summary>
        static void AllowPurchasing()
        {
            int userInput = 0;
            int listSize = _inventoryList.Count;
            do
            {
                // Display purchase options
                DisplayPurchaseOptions();
                userInput = GetPurchaseOption();

                if (userInput > 0 && userInput <= listSize)
                {
                    //Update shopping cart
                    _cart.Add(_inventoryList[(userInput - 1)]);

                    // Show the user what they purchased
                    Console.Clear();
                    Console.WriteLine("You purchased: {0}", _inventoryList[(userInput - 1)].DisplayName());
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid user input!");
                    break;
                }
            } while (true);
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
                Console.WriteLine("Please enter a whole number!");
            }
            return userInput;
        }

        /// <summary>
        /// Get the subtotal from the shopping cart
        /// </summary>
        static int GetSubtotal()
        {
            int subtotal = 0;
            foreach (Inventory item in _cart)
            {
                subtotal += item.Price;
            }
            return subtotal;
        }

        /// <summary>
        /// Display summary of the purchase
        /// </summary>
        static void DisplaySummary()
        {
            int subtotal = GetSubtotal();
            double tax = (double)(subtotal) * (0.095);
            Console.WriteLine("Subtotal: ${0}", subtotal);
            Console.WriteLine("Tax (9.5%): ${0}", tax);
            Console.WriteLine("Total: ${0}", subtotal + tax);
        }
    }
}
