using System.Runtime.CompilerServices;
using System.Text;

namespace Task;

public static class StringBuilderExtension
{
    public static int CounterIsUpper(this StringBuilder text)
    {
        var count = 0;
        for (var i = 0; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]))
            {
                count++;
            }
        }
        return count;
    }

}
