using System;

public class BankAccount
{
    private int balance;

    public BankAccount()
    {
        balance = 0;
    }

    public void Deposit(int amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited Rs{amount}. New balance: Rs{balance}");
    }

    public void Withdraw(int amount)
    {
        
        if (balance >= amount)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn Rs{amount}. New balance: Rs{balance}");
        }
        else
        {
            Console.WriteLine("Error: Insufficient balance.");
        }
    }
    public int GetBalance()
    {
        return balance;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        account.Deposit(1000); 
        account.Withdraw(500); 
        account.Withdraw(800); 
    }
}
