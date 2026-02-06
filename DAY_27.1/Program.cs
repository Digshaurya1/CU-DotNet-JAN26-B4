using System.Collections.Specialized;

namespace Day_27
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"file0.txt";
            string direct = @"..\..\..\";
            using StreamWriter  sw = new StreamWriter(direct + file,true);
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();
            
                sw.WriteLine(name);
            
        }
    }
}
