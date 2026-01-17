namespace week2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];
            decimal total = 0;
            for ( int i = 0; i < 5; i++)
            {
                int flag = 1;
                Console.WriteLine("Enter the name");
                string n1 = Console.ReadLine();
                
                if (n1 != "" && n1 != null )
                {
                    policyHolderNames [i] = n1.ToUpper();
                }
                else
                {
                    flag = 0;
                }
                Console.WriteLine("Enter Annual Premiums");
                decimal pri = decimal.Parse(Console.ReadLine());
                if (pri > 0)
                {
                    annualPremiums [i] = pri;
                    total += pri;
                }
                else
                {
                    flag = 0;
                }

                if(flag == 0)
                {
                    Console.WriteLine("Invalid Input, Re-enter it");
                    i--;
                }

            }

            decimal High = annualPremiums.Max();
            decimal Low = annualPremiums.Min();
            decimal avg = total / 5;


            Console.WriteLine("Insurance Premium Summary");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Name      Premium      Category");

            for (int i = 0; i < 5; i++)
            {
                if (annualPremiums[i] < 10000)
                {
                    Console.WriteLine($"{policyHolderNames[i],-10}{annualPremiums[i],-12} LOW");
                }
                else if (annualPremiums[i] >10000 && annualPremiums[i] < 25000)
                {
                    Console.WriteLine($"{policyHolderNames[i],-10}{annualPremiums[i],-12} MEDIUM");
                }
                else
                {
                    Console.WriteLine($"{policyHolderNames[i],-10}{annualPremiums[i],-12} HIGH");
                }
            }

            Console.WriteLine("----------------------------");
            
            Console.WriteLine($"Total Premiun  : {total,2}");
            Console.WriteLine($"Average Premiun: {avg,2}");
            Console.WriteLine($"Highest Premiun: {High,2}");
            Console.WriteLine($"Lowest Premiun : {Low,2}");

        }
    }
}
