using System;
namespace Program;

public class BankAccount
{
    private int _balance = 0;
    private string _ownerName;
    private string _password; // Нове приватне поле для пароля

    // Конструктор тепер вимагає ще й пароль при реєстрації
    public BankAccount(int balance, string ownerName, string password)
    {
        _balance = balance;
        _ownerName = ownerName;
        _password = password;
    }

    // НОВИЙ МЕТОД: Перевірка пароля
    public bool CheckPassword(string inputPassword)
    {
       if(inputPassword == _password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Твої старі методи (вони ідеальні, я їх просто згорнув для зручності)
    public void Deposit(int amount) { _balance = _balance + amount; }
    public int GetBalance() { return _balance; }
    public bool Withdraw(int amount) 
    { 
        if( _balance>= amount)
        {
            _balance -= amount;
            return true;
        }
        else
        {
            return false;
        }

     }
    public string GetInfo() 
    {
         return $"Рахунок клієнта: {_ownerName}, баланс: {_balance} грн"; 
    }
    public string GetName()
    {
        return _ownerName;
    }
    public string GetPassword()
    {
        return _password;
    }
}