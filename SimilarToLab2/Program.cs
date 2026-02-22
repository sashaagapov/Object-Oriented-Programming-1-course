using System;
using System.Collections.Generic;

namespace Program;

static class Program
{
    static void Main(string[] args)
    {
        bool runningMenu = true;
        while(runningMenu)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Вітаємо у банківській системі!");
            Console.WriteLine("Оберіть дію: 1 - Зареєструватися | 2 - Увійти | 3 - Вихід");
            if(!int.TryParse(Console.ReadLine(),out int choice))
            {
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                continue;
            }
            else
            {
                switch(choice)
            {
                case 1:
                RegisterAccount();
                break;
                
                case 2:
                LoginAccount();
                break;

                case 3:
                runningMenu = false;
                break;

                default:
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                break;

            }

            

            }
        }
    }
        

        

        
    static void RegisterAccount()
    {
        Console.WriteLine("=== РЕЄСТРАЦІЯ ===");
        Console.Write("Введіть ім'я власника рахунку: ");
        string ownerName = Console.ReadLine();
        
        Console.Write("Введіть початковий баланс: ");
        int balance = int.Parse(Console.ReadLine());
        
        Console.Write("Встановіть пароль для рахунку: ");
        string password = Console.ReadLine();
       
        BankService.RegisterAccount(balance, ownerName,password);
    }
    static void LoginAccount()
    {
        Console.WriteLine("\n=== ВХІД ===");
        Console.Write("Введіть ім'я для входу: ");
        string loginName = Console.ReadLine();
        
        Console.Write("Введіть пароль: ");
        string inputPassword = Console.ReadLine();

        BankAccount currentAccount = BankService.Login(loginName, inputPassword);
        BankService.ExistingAccount(currentAccount);
    }
   
    

}