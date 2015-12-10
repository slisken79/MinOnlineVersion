using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock myStock = new Stock();
            RunMenu(myStock);
        }
        private static void RunMenu(Stock myStock)
        {
            bool programRunning = true;
            while (programRunning)
            {
                Console.WriteLine("*******Menu*******");
                Console.WriteLine("....................");
                Console.WriteLine("1 – Skapa vara");
                Console.WriteLine("2 – Inventera vara");
                Console.WriteLine("3 – Lista varor");
                Console.WriteLine("4 – Avsluta");
                Console.WriteLine("¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        CreateItemMenu(myStock);
                        break;
                    case 2:
                        InventoryItem(myStock);
                        break;
                    case 3:
                        PrintItems(myStock);
                        break;
                    case 4:
                        Console.WriteLine("Välkommen åter!!!!");
                        programRunning = false;
                        break;
                    default:
                        Console.WriteLine("Inte ett gilltigt val.");
                        break;
                }

            }
        }

        private static void InventoryItem(Stock myStock)
        {
            int plateCount = 0;
            int juiceCount = 0;
            for (int i = 0; i < Stockitem.StockCount; i++)
            {
                if (myStock[i] is Plate)
                    plateCount++;
                else if (myStock[i] is Juice )
                    juiceCount++;
            }
            Console.WriteLine($"Number of plates is : {plateCount}.");
            Console.WriteLine($"Number of Juices is : {juiceCount}.");
        }

        private static void PrintItems(Stock myStock)
        {
            myStock.PrintItems();

        }

        private static void CreateItemMenu(Stock myStock)
        {
            bool inputNotComplete = true;
            bool itemCreated = false;
            int inputId = 0;
            string inputName;
            string inputMarkning;
            string inputType;

            while (inputNotComplete)
            {
                Console.WriteLine("................................");
                Console.WriteLine("Choose what you want to create!");
                Console.WriteLine("''''''''''''''''''''''''''''''''");
                Console.WriteLine("[1] Stock Item");
                Console.WriteLine("[2] Eco stock item");
                Console.WriteLine("[3] Juice");
                Console.WriteLine("[4] Plate");
                Console.WriteLine("[5] Go back");
                Console.WriteLine("................................");

                int userSelection = int.Parse(Console.ReadLine());


                switch (userSelection)
                {
                    case 1:
                        Console.WriteLine(" Create stock item:");
                        inputId = validateIdInput(inputId);

                        Console.WriteLine("Enter the name of yor item:");
                        inputName = Console.ReadLine();
                        try
                        {
                            Stockitem newStockItem = new Stockitem(inputId, inputName);
                            myStock.AddItem(newStockItem);

                        }
                        catch (System.FormatException e)
                        {
                            Console.WriteLine("Please enter if product is 'EG' or 'Krav'");
                            Stockitem.stockCount--;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Create a Eco stock item.");
                        inputId = validateIdInput(inputId);

                        Console.WriteLine("Enter the name of yor item:");
                        inputName = Console.ReadLine();

                        validateEcoMarking(myStock, itemCreated, inputId, inputName);
                        break;
                    case 3:
                        Console.WriteLine("You choose Juice,");
                        inputId = validateIdInput(inputId);

                        Console.WriteLine("Enter the name of your Juice:");
                        inputName = Console.ReadLine();

                        Console.WriteLine("Enter eco-marking:/Krav or EG?");
                        inputMarkning = Console.ReadLine();

                        Console.WriteLine("Enter type: Orange or Apple");
                        inputType = Console.ReadLine();
                        try
                        {
                            Juice newJuiceItem = new Juice(inputMarkning, inputId, inputName, inputType);
                            myStock.AddItem(newJuiceItem);
                        }
                        catch
                        {
                            Console.WriteLine("Please enter if you want 'Orange' or 'Apple");
                            Stockitem.stockCount--;
                        }
                        break;
                    case 4:
                        Console.WriteLine("You choose Plate,");
                        inputId = validateIdInput(inputId);

                        Console.WriteLine("Enter name of plate");
                        string plateName = Console.ReadLine();

                        Console.WriteLine("Enter type: Flat or Deep");
                        string plateType = Console.ReadLine();
                        try
                        {
                            Plate newPlate = new Plate(plateType, inputId, plateName);
                            myStock.AddItem(newPlate);
                        }
                        catch
                        {
                            Console.WriteLine("Please enter if you want Flat or Deep");
                            Stockitem.stockCount--;
                        }
                        break;
                    case 5:

                        break;

                    default:
                        Console.WriteLine("Please select a valid option.");
                        inputNotComplete = false;
                        break;
                }
                break;
            }
           
        }

        

            //inputName = Console.ReadLine();

            //Console.WriteLine("Enter a eco-marking: /Krav or Eg ?");
            //inputMarkning = Console.ReadLine();

            //Console.WriteLine("Enter a type: /Flat or Deep?");
            //inputType = Console.ReadLine();

            //Plate newPlateItem = new Plate(inputType, inputId, inputName);
            //myStock.AddItem(newPlateItem);
        

        private static void validateEcoMarking(Stock myStock, bool itemCreated, int inputId, string inputName)
        {
            while (itemCreated == false)
            {
                Console.WriteLine("Enter eco-marking: EG or Krav?");
                string inputMarkning = Console.ReadLine();

                try
                {
                    EcoStockitem newEcoStockItem = new EcoStockitem(inputMarkning, inputId, inputName);
                    myStock.AddItem(newEcoStockItem);
                    itemCreated = true;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Något är fel!");
                    EcoStockitem.stockCount--; //Gör en metod av det här!
                }
            }
        }
        

        private static int validateIdInput(int inputId)
        {
            Console.WriteLine("Enter id of your item (Only Numbers!)");
            bool isIdValid = false;
            while (isIdValid == false)
            {
                bool isInputIdValid = Int32.TryParse(Console.ReadLine(), out inputId);
                if (isInputIdValid == false)
                {
                    Console.WriteLine("Not a number try again!");
                }
                else
                {
                    isIdValid = true;
                }
            }
            return inputId;
        }
    }
}



            
                       


                 
             
      

