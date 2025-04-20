namespace Encapsulation.Models
{
    public class BankAccount
    {
        private double _balance;

        public double Balance
        {
            get { return _balance; }
        }
        private void Depozit(double amount)
        {
            _balance += amount;            
        }
    }
}
