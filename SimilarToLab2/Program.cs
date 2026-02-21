using System;
using System.Collections.Generic;

namespace Program;

static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== РЕЄСТРАЦІЯ ===");
        Console.Write("Введіть ім'я власника рахунку: ");
        string ownerName = Console.ReadLine();
        
        Console.Write("Введіть початковий баланс: ");
        int balance = int.Parse(Console.ReadLine());
        
        Console.Write("Встановіть пароль для рахунку: ");
        string password = Console.ReadLine();
       
        BankService.RegisterAccount(balance, ownerName,password);

        Console.WriteLine("\n=== ВХІД ===");
        Console.Write("Введіть ім'я для входу: ");
        string loginName = Console.ReadLine();
        
        Console.Write("Введіть пароль: ");
        string inputPassword = Console.ReadLine();

        BankAccount currentAccount = BankService.Login(loginName, inputPassword);

        if (currentAccount != null)
        {
            Console.WriteLine("Доступ дозволено!\n");
            bool isRunning = true;
            
            while (isRunning)
            {
                Console.WriteLine("Оберіть дію: 1 - Поповнити | 2 - Зняти | 3 - Інфо | 4 - Вихід");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть суму для поповнення: ");
                        int depositAmount = int.Parse(Console.ReadLine());
                        currentAccount.Deposit(depositAmount);
                        BankService.ShowBalance(currentAccount);
                        break;
                    case "2":
                        Console.Write("Введіть суму для зняття: ");
                        int withdrawAmount = int.Parse(Console.ReadLine());
                        if (currentAccount.Withdraw(withdrawAmount))
                        {
                            BankService.ShowBalance(currentAccount);
                        }
                        else
                        {
                            Console.WriteLine("Недостатньо коштів на рахунку.");
                        }
                        break;
                    case "3":
                        Console.WriteLine(currentAccount.GetInfo());
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Невірне ім'я або пароль. Доступ заборонено.");
        }
    }
}