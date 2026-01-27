namespace Day18_2
{

    class Employee {

        public int EmployeeId  { get; set; }
        public string EmployeeName { get; set; }

        public decimal BasicSalary { get; set; }

        public int ExperienceInYears{ get; set; }

        public Employee(int id, string name, decimal sal, int exp = 0 )
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = sal;
            ExperienceInYears = exp;
        }

        public decimal CalculateAnnualSalary()
        {
            return BasicSalary * 12m;
        }
        public string DisplayEmployeeDetails()
        {
            return $"Name: {EmployeeName}";
        }

    }


    class PermanentEmployee : Employee {

        public PermanentEmployee(int id, string name, decimal sal, int exp) : base(id, name, sal, exp) { }

        public new decimal CalculateAnnualSalary()
        {
            decimal HRA = 20 * BasicSalary / 100;
            decimal special = 10 * BasicSalary / 100;
            return  (ExperienceInYears >=5 ) ? HRA + special + 50000 + BasicSalary : HRA + special + BasicSalary;
        }

    }


    class ContractEmployee : Employee {

        public int ContractDurationInMonths { get; set; }

        public ContractEmployee(int id, string name, decimal sal,  int months) : base(id, name, sal) {
        
            ContractDurationInMonths = months;
        }

        public new decimal CalculateAnnualSalary()
        {
            return (ContractDurationInMonths >= 12) ? BasicSalary + 30000 : BasicSalary;
        }

    }

    class InternEmployee: Employee
    {
        public InternEmployee(int id, string name, decimal sal, int exp) : base(id, name, sal, exp) { }

        public new decimal CalculateAnnualSalary()
        {
            return 12m * BasicSalary;
        }
    }






    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee(1,"CJ",12350.5m,5);
            PermanentEmployee emp2 = new PermanentEmployee(2, "Tommy", 12300.03m, 7);
            ContractEmployee emp3 = new ContractEmployee(3, "Franklin", 145636, 36);
            decimal sal1 = emp1.CalculateAnnualSalary();
            decimal sal2 = emp2.CalculateAnnualSalary();
            decimal sal3 = emp3.CalculateAnnualSalary();

            Console.WriteLine($"EMP1 : {sal1}");
            Console.WriteLine($"EMP2 : {sal2}");
            Console.WriteLine($"EMP2 : {sal3}");

        }
    }
}
