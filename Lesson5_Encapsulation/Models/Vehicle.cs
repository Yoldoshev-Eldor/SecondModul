namespace Lesson5_Encapsulation.Models
{
    public class Vehicle
    {
        protected int Speed { get; set; }

        private double _fuel;

        public double Fuel
        {
            get { return _fuel; }
            set
            {
                if (value <= 50 + _fuel)
                {
                    _fuel += value;
                }

            }
        }
    }
}
