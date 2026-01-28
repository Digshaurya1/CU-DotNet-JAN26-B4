namespace Day_19._1
{

    abstract class Vehicle
    {
        public Vehicle(string name)
        {
            ModelName = name;
        }
        public string ModelName { get; set; }
        public abstract void Move();
        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable";
        }

    }

    class ElectricCar : Vehicle {

        public ElectricCar(string name):base(name)
        {
            
        }
        public override void Move() {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }
        public override string GetFuelStatus() {
            return $"{ModelName} battery is at 80%.";

        }

    }

    class HeavyTruck : Vehicle {

        public HeavyTruck(string name): base(name) 
        {
            
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque diesel power.");
        }
       
    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string name) : base(name)
        {

        }

        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + " Checking jet fuel reserves...";

        }

    }






    internal class Program
    {
        static void Main(string[] args)
        {

            Vehicle[] vehicles = {
                
                new CargoPlane("Plane"),
                new HeavyTruck("Heavy"),
                new ElectricCar("Electro"),
            };

            foreach (var item in vehicles)
            {
                item.Move();
                Console.WriteLine(item.GetFuelStatus());
                Console.WriteLine();
            }
        }
    }
}
