namespace InhtDemo
{

    class Loan
    {

        public string LoanNumbers { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }

        public Loan()
        {
            LoanNumbers = string.Empty; ;
            CustomerName = string.Empty;
            PrincipalAmount = 0 ;
            TenureInYears = 0;  
        }
        public Loan(string num, string name, decimal pri, int years)
        {
            LoanNumbers = num;
            CustomerName = name;
            PrincipalAmount = pri;
            TenureInYears = years;

        }

        public  new decimal CalculateEMI()
        {
            Console.WriteLine("Loan");
            return  (PrincipalAmount  + ( (PrincipalAmount * 10 * TenureInYears) / 100) / 12) * TenureInYears;
        }

    }



    class HomeLoan : Loan
    {
        public HomeLoan() { }
        public HomeLoan(string num, string name, decimal pri, int years) : base(num, name, pri, years) { }


        public new decimal CalculateEMI()
        {
            decimal si = (PrincipalAmount * 8 * TenureInYears) / 100;
            decimal processingfee = 1 * PrincipalAmount / 100;
            decimal toPayAnnual = si + PrincipalAmount + processingfee;
            Console.WriteLine("HomeLoan");
            return toPayAnnual / (12 * TenureInYears);
        }



        
    }
    class CarLoan : Loan
    {
        public CarLoan() 
        {

        }
        public CarLoan(string num, string name, decimal pri, int years) : base(num, name, pri, years)
        {

        }
        public new decimal CalculateEMI()
        {
            decimal si = (PrincipalAmount * 9 * TenureInYears) / 100;
            decimal toPayAnnual = si + PrincipalAmount + 15000;
            Console.WriteLine("CarLoan");
            return toPayAnnual / (12 * TenureInYears);
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Loan[] loans = new Loan[2] {  
            new CarLoan("abc", "AAA", 1500, 4),                           // we make the array of the base class bczz we are storing 2 child classes
                                                        // and child classes can be stored in there parent classes bcs it have all the common properties
            new HomeLoan("abc", "AAA", 1600, 4)};                            //these are the anonymous objects -> we use it when we dont need names of the objects 

            for (int i = 0; i < loans.Length; i++) {
                Console.WriteLine(loans[i].CalculateEMI());
            }
        }

    }
}
