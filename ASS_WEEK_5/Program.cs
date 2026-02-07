
namespace ASS5
{
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message)
        {
        }
    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message)
        {
        }
    }

    interface ILoggable
    {
        void SaveLog(string message);
    }

    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }

        protected Shipment(string id, double weight, string destination)
        {
            TrackingId = id;
            Weight = weight;
            Destination = destination;
        }

        public abstract void ProcessShipment();
    }

    class ExpressShipment : Shipment
    {
        public bool Secure { get; set; }
        public ExpressShipment(string id, double weight, string destination,bool secure)
            : base(id, weight, destination)
        {
            Secure = secure;
        }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight", "Weight must be greater than 0");
            }

            if (Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(
                    "Shipment cannot be sent to restricted destination");
            }

            if (!Secure)
            {
                throw new Exception("Shipment isnt secure");
            }
        }
    }

    class HeavyShipment : Shipment
    {
        public bool Permit { get; set; }
        public bool Reinforce { get; set; }

        public HeavyShipment(string id, double weight, string destination,bool secure, bool perm)
            : base(id, weight, destination)
        {
            Permit = perm;
            Reinforce = secure;
        }


        public override void ProcessShipment()
        {
            if (Weight <= 0)
            {
                throw new ArgumentOutOfRangeException("Weight","Weight must be greater than 0");
            }

            if (Destination == "North Pole" || Destination == "Unknown Island")
            {
                throw new RestrictedDestinationException(
                    "Shipment cannot be sent to restricted destination");
            }

            if (Weight > 1000)
            {
                //bool permit = Permit;
                if (!Permit)
                {
                    throw new Exception("Heavy Lift without permit");
                }
            }

            if (!Reinforce)
            {
                throw new Exception("Shipment is not secure");
            }
        }
    }

    class LogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            try
            {
                using StreamWriter sw =
                    new StreamWriter("../../../shipment_audit.log", true);
                sw.WriteLine(message);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR in file path.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shipment> shipments = new List<Shipment>()
            {
                new ExpressShipment("SHP1", 50, "Delhi",true),
                new ExpressShipment("SHP2", -10, "Mumbai",true),
                new ExpressShipment("SHP3", 80, "North Pole",true),
                new HeavyShipment("SHP4", 1200, "Chennai",false,true),
                new HeavyShipment("SHP5", 0, "Bangalore",true,false),
                new HeavyShipment("SHP6", 1500, "Unknown Island",false,true)
            };

            LogManager log = new LogManager();

            foreach (Shipment s in shipments)
            {
                try
                {
                    s.ProcessShipment();
                    log.SaveLog($"SUCCESSFUL SHIPMENT of {s.TrackingId}");
                }
                catch (RestrictedDestinationException ex)
                {
                    log.SaveLog(ex.Message + " ID:" + s.TrackingId);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    log.SaveLog(ex.Message + " ID:" + s.TrackingId);
                }
                catch (InsecurePackagingException ex) 
                {
                    log.SaveLog(ex.Message + " ID:" + s.TrackingId);
                }
                catch (Exception ex)
                {
                    log.SaveLog(ex.Message + " ID:" + s.TrackingId);
                }
                finally
                {
                    Console.WriteLine($"{s.TrackingId} record UPDATED in file");
                }
            }
        }
    }
}
