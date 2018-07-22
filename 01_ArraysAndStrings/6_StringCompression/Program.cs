using System;
using System.Text;

namespace _6_StringCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Implement a method to perform basic string compression using the counts 
                of repeated characters. For example, the string aabcccccaaa would become a2b1c5a3.
                If the "compressed" string would not become smaller than the original string, 
                your method should return the original string. You can assume the string only has
                uppercase and lowecase letters (a-z).
            */

            Console.WriteLine("Enter string to compress:");
            string uncompressed = Console.ReadLine();

            Console.WriteLine($"Compressed: {CompressString(uncompressed)}");

            Console.ReadKey();
        }

        static string CompressString(string uncompressed)
        {
            if (String.IsNullOrWhiteSpace(uncompressed) || uncompressed.Length == 1)
            {
                return uncompressed;
            }

            char c = uncompressed[0];
            StringBuilder compressed = new StringBuilder(c.ToString());
            int length = uncompressed.Length;
            byte count = 1;
            int index = 1;

            while (index < length)
            {
                if (c == uncompressed[index])
                {
                    count++;
                }
                else
                {
                    compressed.Append(count);
                    compressed.Append(uncompressed[index]);
                    c = uncompressed[index];
                    count = 1;
                }

                index++;
            }
            compressed.Append(count);

            if (length < compressed.Length)
            {
                return uncompressed;
            }
            
            return compressed.ToString();   
        }
    }
}
