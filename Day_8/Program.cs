using System;

namespace Day8project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter <UserName>|<LoginMessage>");
            string[] s = Console.ReadLine().Split('|');
            string name = s[0];
            string msg = (s[1].Trim()).ToLower();

            if (msg.Equals("login successful")) Console.WriteLine("LOGIN SUCCESS");

            else if (msg.Contains("successful")) Console.WriteLine("LOGIN SUCCESS (CUSTOM MESSAGE)");

            else Console.WriteLine("LOGIN FAILD");
        }
    }
}
