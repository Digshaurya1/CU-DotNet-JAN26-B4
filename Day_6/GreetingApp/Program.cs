using ClassLibraryA;

namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string S = Console.ReadLine();
            Console.WriteLine(GreetingHelper.GetGreet(S));
        }
    }
}
