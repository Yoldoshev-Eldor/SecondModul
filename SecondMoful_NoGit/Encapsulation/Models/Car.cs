namespace Encapsulation.Models
{
    public class Car : Vehicle
    {
        public void Refuel(double fuel)
        {
            if (fuel >= 0)
            {
                _fuel += fuel;
            }
            else
            {
                _fuel -= fuel;
            }
        }

        public double Distance(double distance)
        {
            var car = new Car();
            var res = distance / car.Speed;

            return res;
        }
    }
}
