namespace Task
{
    public static class IntExtension
    {
        public static bool CheckEven(this int value)
        {
            if (value % 2 == 0)
            {
                return true;
            }
            return false;
        }
        public static bool CheckToPrimeNumber(this int value)
        {
            var count = 0;
            for (int i = 1; i <= value; ++i)
            {
                if (value % i == 0)
                {
                    count++;
                }
            }
            if (count == 2)
            {
                return true;
            }
            return false;
        }
        public static void AddNumber(this int value, int number)
        {
            value += number;
        }
    }
    
    
}