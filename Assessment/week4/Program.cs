using System.Text;

namespace ASS4
{


    class HospitalBilling
    {
        public List<Patient> pList { get; set; } = new List<Patient>();

        public void AddPatient(Patient p)
        {
            pList.Add(p);
        }
        public void GenerateDailyReport()
        {
            foreach (Patient patient in pList)
            {
                Console.WriteLine($"Name: {patient.name}");
                decimal total = patient.CalculateFinalBill() ;
                Console.WriteLine($"Bill: {total:C2}");
            }
        }

        public decimal CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;
            foreach (Patient patient in pList)
            {
                totalRevenue += patient.CalculateFinalBill();
            }
            return totalRevenue;
        }

        public int GetInpatientCount()
        {
            int count = 0;
            foreach (Patient patient in pList)
            {
                if (patient is Inpatient) count++;
            }
            return count;
        }
    }

    class Patient
    {
        public string name { get; set; }
        public decimal BaseFee { get; set; }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }

    }

     class Inpatient : Patient
    {
        public int DayStays { get; set; }
        public decimal DailyRate { get; set; }

        public override decimal CalculateFinalBill()
        {
            return BaseFee +  (DayStays * DailyRate);
        }
    }


    class Outpatient : Patient {

        public decimal ProcedureFee { get; set; }


        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }

    class EmergencyPatient : Patient
    {

        private int severityLevel;

        public int SeverityLevel
        {
            get { return severityLevel; }
            set { 
                if(severityLevel <=1 && severityLevel <=5)
                severityLevel = value; }
        }



        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalBilling bill = new HospitalBilling();

            Inpatient inpatient1 = new Inpatient()
            {
                name = "yo",
                BaseFee = 100,
                DayStays = 5,
                DailyRate = 50
            };

            Inpatient inpatient2 = new Inpatient()
            {
                name = "yoyo",
                BaseFee = 100,
                DayStays = 6,
                DailyRate = 100
            };
            Outpatient outpatient1 = new Outpatient() { 
                name = "no",
                BaseFee = 200,
                ProcedureFee = 400
            };

            Outpatient outpatient2 = new Outpatient()
            {
                name = "nono",
                BaseFee = 200,
                ProcedureFee = 600
            };
            EmergencyPatient emergencyPatient1 = new EmergencyPatient()
            {
                name = "po",
                BaseFee = 300,
                SeverityLevel = 5,
            };
            EmergencyPatient emergencyPatient2 = new EmergencyPatient()
            {
                name = "popo",
                BaseFee = 300,
                SeverityLevel = 4,
            };
            Console.OutputEncoding = Encoding.UTF8;
            bill.AddPatient(inpatient1);
            bill.AddPatient(inpatient2);
            bill.AddPatient(outpatient1);
            bill.AddPatient(outpatient2);
            bill.AddPatient(emergencyPatient1);
            bill.AddPatient(emergencyPatient2);
            Console.WriteLine($"Daily Report of each driver:");
            bill.GenerateDailyReport();
            decimal totalRev = bill.CalculateTotalRevenue();
            Console.WriteLine($"Total Revenue {totalRev:C2}");
            int count  = bill.GetInpatientCount();
            Console.WriteLine($"Count of Inpatient : {count}");

        }
    }
}
