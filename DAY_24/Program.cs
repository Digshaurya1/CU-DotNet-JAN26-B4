using System.Collections;

namespace DAY_24._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alic");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            if (employeeTable.ContainsKey(105))
            {
                Console.WriteLine("ID already exists.");
            }
            else
            {
                employeeTable.Add(105, "Edward");
            }
            string name = (string)employeeTable[102];
            Console.WriteLine(name);

            foreach (DictionaryEntry item in employeeTable)
            {
                Console.WriteLine($"Id:{item.Key}  Name:{item.Value}");
            }
            employeeTable.Remove(103);
            int count = employeeTable.Count;
            Console.WriteLine($"Total element after deletion: {count}");
        }

        
    }
}
