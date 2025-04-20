namespace Lesson5_Encapsulation.Models;

public class Matiz : Vehicle
{



    public void Refuel(int amount)
    {
        Fuel += amount;
    }

    public void Drive(double dictance)
    {
        Console.WriteLine(dictance / Speed);
    }
}