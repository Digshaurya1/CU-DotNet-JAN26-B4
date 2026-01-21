namespace oopsPractice
{
    public enum Dept { 
      CSE,
      AI,
      IOT,
    }

    class Employee
    {

        int id;

        private int sal;

        public int Sal
        {
            get { return sal; }

            set
            {
                if (value > 50000 && value < 90000)
                    sal = value;
            }
        }

        public string Dept { get; set; }

        public void getId(int id)
        {
            this.id = id;
        }

        public void SetId()
        {
            Console.WriteLine(id);
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Sal = 10;
            Console.WriteLine(emp.Sal);
            emp.getId(11);
            emp.SetId();
            emp.Dept = "OS";
            Console.WriteLine(emp.Dept);

        }
    }
}
