namespace Day_20
{


    class Flight : IComparable<Flight>
    {


        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DurationTime { get; set; }

        public int CompareTo(Flight? other)
        {
            return Price.CompareTo(other.Price);
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.Duration.CompareTo(y.Duration);
        }
    }


    class  DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DurationTime.CompareTo(y.DurationTime);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight()
                {
                    FlightNumber = "1",
                    Price = 15000,
                    Duration = new TimeSpan(4,0,0),
                    DurationTime = new DateTime(2026,7,6,21,35,0)
                },

                new Flight()
                {
                    FlightNumber = "2",
                    Price = 21000,
                    Duration = new TimeSpan(2,0,0),
                    DurationTime = new DateTime(2026,7,6,11,35,0)
                },
                new Flight()
                {
                    FlightNumber = "3",
                    Price = 19500,
                    Duration = new TimeSpan(7,0,0),
                    DurationTime = new DateTime(2026,7,6,21,30,0)
                }

            };

            flights.Sort();
            Console.WriteLine("----------Economy View----------");
            Console.WriteLine();
            foreach (Flight flight in flights) {
                Console.WriteLine($"Flight Number: {flight.FlightNumber}");
                Console.WriteLine($"Flight Price: {flight.Price}");
                Console.WriteLine($"Flight Duration:{flight.Duration}");
                Console.WriteLine($"Flight Departure:{flight.DurationTime}");
                Console.WriteLine();
            
            }

            flights.Sort(new DurationComparer());
            Console.WriteLine("----------Business Runner View----------");
            Console.WriteLine();
            foreach (Flight flight in flights)
            {
                Console.WriteLine($"Flight Number: {flight.FlightNumber}");
                Console.WriteLine($"Flight Price: {flight.Price}");
                Console.WriteLine($"Flight Duration:{flight.Duration}");
                Console.WriteLine($"Flight Departure:{flight.DurationTime}");
                Console.WriteLine();
            }
            Console.WriteLine("----------Early Bird View----------");
            Console.WriteLine();
            flights.Sort(new DepartureComparer());
            foreach (Flight flight in flights)
            {
                Console.WriteLine($"Flight Number: {flight.FlightNumber}");
                Console.WriteLine($"Flight Price: {flight.Price}");
                Console.WriteLine($"Flight Duration:{flight.Duration}");
                Console.WriteLine($"Flight Departure:{flight.DurationTime}");
                Console.WriteLine();
            }

        }
    }
}
