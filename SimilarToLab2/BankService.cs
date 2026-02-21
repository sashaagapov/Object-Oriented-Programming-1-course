using System;
using System.IO;
using System.Runtime.Intrinsics.Arm;
namespace Program;

public static class BankService
{
      private static List<BankAccount> _allAccounts = new List<BankAccount>();
    static BankService() 
{
    if (File.Exists("accounts.txt")) 
    {
        string[] lines = File.ReadAllLines("accounts.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            BankAccount account = new BankAccount(int.Parse(parts[1]),parts[0],parts[2]);
            _allAccounts.Add(account);
        }
    }
}
  
    
    public static void RegisterAccount(int balance, string ownerName, string password)
    {
        BankAccount account = new BankAccount(balance,ownerName,password);
        _allAccounts.Add(account);
        string resultLine = $"{account.GetName()};{account.GetBalance()};{account.GetPassword()}";
        File.AppendAllText("accounts.txt", resultLine + Environment.NewLine); 
        
    }

    public static BankAccount Login(string name, string password)
    {
    foreach(BankAccount account in _allAccounts)
        {
            if(account.GetName() == name)
            {
                if(account.CheckPassword(password))
                {
                    return account;
                }
               
            }
            
        }
        return null;
    }
        public static void ShowBalance(BankAccount account)
    {
        Console.WriteLine($"Ваш поточний баланс: {account.GetBalance()} грн");
    }
  
    
}