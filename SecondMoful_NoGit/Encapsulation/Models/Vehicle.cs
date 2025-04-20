namespace Encapsulation.Models
{
    public class Vehicle
    {
        protected double _speed;

        protected double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        protected double _fuel;

        protected double Fuel
        {
            get { return _fuel; }
            set { _fuel = value; }
        }


    }
}
