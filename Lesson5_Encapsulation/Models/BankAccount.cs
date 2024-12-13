namespace Lesson5_Encapsulation.Models;

public class BankAccount
{
    private string _accountNumber;

    public string AccountNumber
    {
        get { return _accountNumber; }
        set { _accountNumber = value; }
    }
    private double _balance;

    public double Balance
    {
        get { return _balance; }

    }
    public void Deposit(double amount)
    {
        _balance += amount;
    }
}
