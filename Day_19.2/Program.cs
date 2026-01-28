namespace Day_19._2
{

    abstract class UtilityBill {

        public UtilityBill(int id, string name, decimal units, decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = units;
            RatePerUnit = rate;
        }
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }
        public void PrintBill()
        {
            Console.WriteLine($"ID: {ConsumerId}");
            Console.WriteLine($"Name:{ConsumerName}");
            Console.WriteLine($"Total units: {UnitsConsumed}");

            decimal total = CalculateBillAmount();
            Console.WriteLine($"Total amount: {total}");

            decimal tax = CalculateTax(total);
            Console.WriteLine($"Tax amount : {tax}");

        }
    }


    class ElectricityBill : UtilityBill
    {
       public ElectricityBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate) { 
        }

      public override decimal CalculateBillAmount()
        {
            if(UnitsConsumed > 300)
            {
                return UnitsConsumed * RatePerUnit + (UnitsConsumed * RatePerUnit) * 0.1m;
            }
            else
            {
                return UnitsConsumed * RatePerUnit;
            }
        }

    }

    class WaterBill : UtilityBill {

        public WaterBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate)
        {
        }
        public override decimal CalculateBillAmount() { return UnitsConsumed * RatePerUnit; }

        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.2m;
        }

    }
    class GasBill : UtilityBill {
        public GasBill(int id, string name, decimal units, decimal rate) : base(id, name, units, rate)
        {
        }
        public override decimal CalculateBillAmount() {return (UnitsConsumed * RatePerUnit) + 150; }

        public override decimal CalculateTax(decimal billAmount)
        {
            return 0;
        }

    }






    internal class Program
    {
        static void Main(string[] args)
        {
            List<UtilityBill> bills = new List<UtilityBill>{
                new ElectricityBill(1,"ABC",1234,2.5m),
                new GasBill(2,"XYZ",5678,4.5m),
                new WaterBill(3,"IJK",9876,1.2m)
            };

            foreach (UtilityBill bill in bills)
            {
                bill.PrintBill();
                Console.WriteLine();
            }

        }
    }
}
