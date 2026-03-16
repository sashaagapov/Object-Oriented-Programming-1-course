using System;
using System.IO;
using System.Runtime.Intrinsics.Arm;
namespace Program;

public class Bankservice
{
    private List<BankAccount> _allAccounts = new List<BankAccount>();
    Bankservice()
    {
        if (File.Exists("accounts.txt"))
        {
            string[] lines = File.ReadAllLines("accounts.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                BankAccount account = new BankAccount(int.Parse(parts[1]), parts[0], parts[2]);
                _allAccounts.Add(account);
            }
        }
    }


    public void RegisterAccount(int balance, string ownerName, string password)
    {
        BankAccount account = new BankAccount(balance, ownerName, password);
        _allAccounts.Add(account);
        string resultLine = $"{account.GetName()};{account.GetBalance()};{account.GetPassword()}";
        File.AppendAllText("accounts.txt", resultLine + Environment.NewLine);

    }

    public BankAccount Login(string name, string password)
    {
        foreach (BankAccount account in _allAccounts)
        {
            if (account.GetName() == name)
            {
                if (account.CheckPassword(password))
                {
                    return account;
                }

            }

        }
        return null;
    }
    public void ShowBalance(BankAccount account)
    {
        Console.WriteLine($"Ваш поточний баланс: {account.GetBalance()} грн");
    }
    public void ExistingAccount(BankAccount currentAccount)
    {
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
                        Bankservice.ShowBalance(currentAccount);
                        break;
                    case "2":
                        Console.Write("Введіть суму для зняття: ");
                        int withdrawAmount = int.Parse(Console.ReadLine());
                        if (currentAccount.Withdraw(withdrawAmount))
                        {
                            Bankservice.ShowBalance(currentAccount);
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



