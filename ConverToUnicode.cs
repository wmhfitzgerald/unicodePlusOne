using System;
using System.Linq;

public class Program
{
    public const string LAST_LETTER = "z";
    public const string REPLACEMENT_LETTER = "A";

    public static void Main(string[] args)
    {
        Console.WriteLine("This application will take in a string, convert to Unicode add one, and display the string value. ");
        Console.WriteLine("EXAMPLE: a=b, y=z -- since 'z' is at the end of the alphabet it would be represented as an 'a'");
        Console.WriteLine("Spaces remain spaces");
        Console.WriteLine("All vowels will displayed capitalized ");
        Console.WriteLine("All other characters will be displayed as the next character in the unicode table");        
        Console.WriteLine(" ");

        string inputValue = "";
        Console.WriteLine("Enter a String: ");
        inputValue = Console.ReadLine();
        while (inputValue.Length == 0)
        {
            Console.WriteLine("I SAID Enter a String: ");
            inputValue = Console.ReadLine();
        } 
        
        if (inputValue.Length > 0)
        {
            convertChar(inputValue.ToLower());
        }        
    }

    public static void convertChar(string s)
    {
        char[] charArray = s.ToCharArray();
        string finished = "";
        string[] stringVowels = { "a", "e", "i", "o", "u", "y" };

        for (int i = 0; i <= charArray.Length - 1; i++)
        {
            int w = 0;
            if (charArray[i].ToString() == LAST_LETTER)
            {
                w = char.ConvertToUtf32(REPLACEMENT_LETTER, 0);
            }
            else
            {
                if (charArray[i].ToString() == " ")
                {
                    w = char.ConvertToUtf32(s, i);
                }
                else
                {
                    w = char.ConvertToUtf32(s, i);
                    w++;
                }
            }

            if (stringVowels.Contains(char.ConvertFromUtf32(w)))
            {
                finished = finished += char.ConvertFromUtf32(w).ToUpper();
            }
            else
            {
                finished = finished += char.ConvertFromUtf32(w);
            }
        }
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine("Old String: " + s);
        Console.WriteLine("New String: " + finished);
        Console.WriteLine(" ");
        Console.WriteLine("Press any key to stop...");
        Console.ReadKey();
    }
}
