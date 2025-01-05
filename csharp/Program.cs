using System;
using System.IO;

class BudgetTracker
{
    static double ReadBalance()
    {
        if (File.Exists("balance.txt"))
        {
            try
            {
                return double.Parse(File.ReadAllText("balance.txt"));
            }
            catch (FormatException)
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    static void SaveBalance(double balance)
    {
        File.WriteAllText("balance.txt", balance.ToString("F2"));
    }

    static void ClearScreen()
    {
        Console.Clear();
    }

    static void Main()
    {
        double balance = ReadBalance();

        while (true)
        {
            ClearScreen();
            Console.WriteLine("\n--- Budget Tracker ---");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expenses");
            Console.WriteLine("3. View Balance");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an option (1-4): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                try
                {
                    Console.Write("Enter income amount: $");
                    double income = double.Parse(Console.ReadLine());
                    balance += income;
                    Console.WriteLine($"Income added: ${income:F2}");
                    SaveBalance(balance);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Console.WriteLine("Press Enter to continue...");  
                Console.ReadLine();
            }
            else if (choice == "2")
            {
                try
                {
                    Console.Write("Enter expense amount: $");
                    double expenses = double.Parse(Console.ReadLine());
                    balance -= expenses;
                    Console.WriteLine($"Expense added: ${expenses:F2}");
                    SaveBalance(balance);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                Console.WriteLine("Press Enter to continue...");  
                Console.ReadLine();
            }
            else if (choice == "3")
            {
                Console.WriteLine($"Your current balance is: ${balance:F2}");
                Console.WriteLine("Press Enter to continue...");  
                Console.ReadLine();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Exiting the program. Goodbye!");
                SaveBalance(balance);  
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option (1-4).");
                Console.WriteLine("Press Enter to continue...");  
                Console.ReadLine();
            }
        }
    }
}

