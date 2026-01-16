namespace Day9project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] weeklySales = new decimal[7];
            decimal total = 0;
            decimal mini = decimal.MaxValue;
            decimal maxi = decimal.MinValue;

            Console.WriteLine("Enter the daily sale");

            for (int i = 0; i < 7; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num <= 0)
                {
                    Console.WriteLine("Invalid Input");
                    i--;
                }
                else
                {
                    weeklySales[i] = num;
                    total += num;

                    if (num > maxi) maxi = num;
                    if (num < mini) mini = num;
                }
            }

            decimal avg = total / 7;
            int countHigh = 0;

            for (int i = 0; i < 7; i++)
            {
                if (weeklySales[i] > avg)
                    countHigh++;
            }

            string[] Categorization = new string[7];

            for (int i = 0; i < 7; i++)
            {
                if (weeklySales[i] > 15000)
                    Categorization[i] = "HIGH";
                else if (weeklySales[i] >= 5000)
                    Categorization[i] = "MEDIUM";
                else
                    Categorization[i] = "LOW";
            }

            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("-------------------");
            Console.WriteLine($"Total Sale: {total}");
            Console.WriteLine($"Average Daily Sale: {avg}");
            Console.WriteLine($"Highest Sale: {maxi}");
            Console.WriteLine($"Lowest Sale: {mini}");
            Console.WriteLine($"Days above avg: {countHigh}");

            Console.WriteLine("\nDay-wise sales category summary");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Day {i + 1}: {Categorization[i]}");
            }
        }
    }
}
