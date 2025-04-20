namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String_Builder str = new String_Builder();
            str.AppendValue("eldor");
            str.AppendValue("nurulloh");
            str.AppendValue("Akobir");
            var result = str.GetValue();
            Console.WriteLine(result);
            result = result.Remove(0, 2);
            Console.WriteLine(result);
       
        }
    }
}
