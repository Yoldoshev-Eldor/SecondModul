using System.Security.Cryptography.X509Certificates;

namespace Lesson1;

public class String_Builder
{
    private char[] chars;
    private int length = 16;
    private int index = 0;
    public String_Builder()
    {
        chars = new char[length];
    }
    public String_Builder(int copacity)
    {
        chars = new char[copacity];
    }
    public void AppendValue(string value)
    {
        if (index + value.Length <= chars.Count())
        {
            foreach (char c in value)
            {
                chars[index] = c;
                index++;
            }
        }
        else
        {
            var newChars = new char[chars.Length*2];
            index = 0;
            foreach (char c in chars)
            {
                newChars[index] = c;
                index++;
            }
            foreach (char c in value)
            {
                newChars[index] = c;
                index++;
            }
            chars = newChars;
        }
        
    }
    public string GetValue()
    {
        return string.Join("",chars);
    }
}
