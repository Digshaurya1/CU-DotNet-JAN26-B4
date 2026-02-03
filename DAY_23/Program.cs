using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace DAY23
{
    internal class Program
    {
        class MyCustomException : Exception
        {
            public MyCustomException(string message) : base(message) { }
        }
        class invalidStudentAgeException : Exception {

            public invalidStudentAgeException(string s):base(s)
            {
                
            }


        }

        class InvalidStudentNameException : Exception
        {
            public InvalidStudentNameException(string s) : base(s)
            {
                
            }
        }

        static void Main(string[] args)
        {
            try
            {
                int x;
                int y;
                Console.WriteLine("enter the first number");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the second number");
                y = int.Parse(Console.ReadLine());
                int c = x / y;
                Console.WriteLine(c);
            }
            catch (DivideByZeroException ex1) { Console.WriteLine(ex1.Message); }

            try
            {
                int x1;
                Console.WriteLine("Enter number");
                x1 = int.Parse(Console.ReadLine()); // user enter string here
                int num = x1;

            }
            catch (FormatException ex2) { Console.WriteLine(ex2.Message); }

            try
            {
                int[] arr = { 1, 2, 3 };
                Console.WriteLine(arr[4]);
            }
            catch (IndexOutOfRangeException ex3) { Console.WriteLine(ex3.Message); }

            finally { Console.WriteLine("Operation Completed"); }


            int age = 0;
            while (age < 18 || age > 60)
            {
                Console.WriteLine("Enter the age of student");
                age = int.Parse(Console.ReadLine());
                try
                {
                    if (age < 18 || age > 60)
                    {
                        throw new invalidStudentAgeException("Invalid age");

                    }
                }
                catch (invalidStudentAgeException studentex) { Console.WriteLine(studentex.Message); }
            }

            string name = "";
            while(!Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,}[ ] [A-Z]{1}[a-z]{2,}$"))
            {
                Console.WriteLine("Enter the name");
                name = Console.ReadLine();
                try
                {
                    if (!Regex.IsMatch(name, @"^[A-Z]{1}[a-z]{2,}[ ] [A-Z]{1}[a-z]{2,}$"))
                    {
                        throw new InvalidStudentNameException("Invalid name");
                    }
                }
                catch (InvalidStudentNameException studentexN) { Console.WriteLine(studentexN.Message); }
            }
            try
            {
                try
                {
                    
                    throw new MyCustomException("This is the custom exception message");
                }
                catch (MyCustomException ex)
                {
                    
                    throw new Exception("This is the outer exception message", ex);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Message: " + e.Message);
                Console.WriteLine("InnerException Message: " + e.InnerException.StackTrace);
            }


        }
    }
}
