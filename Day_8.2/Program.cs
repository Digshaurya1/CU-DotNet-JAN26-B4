using System.Threading.Channels;

namespace Day8projectSecond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<TransactionId>#<AccountHolderName>#<TransactionNarration>");
            string[] arr = Console.ReadLine().Split("#");
            string TransactionId = arr[0]; ;
            string AccountHolderName = arr[1];
            string TransactionNarration = (arr[2].Trim()).ToLower();
            TransactionNarration = string.Join(" ",TransactionNarration.Split(" ",StringSplitOptions.RemoveEmptyEntries));

            if (TransactionNarration == "cash deposit successful")
            {
                Console.WriteLine($"Transaction Id: {TransactionId}");
                Console.WriteLine($"Account Holder: {AccountHolderName}");
                Console.WriteLine($"Narration: {TransactionNarration}");
                Console.WriteLine($"Category : STANDARD TRANSACTION");
            }

            else if (TransactionNarration.Contains("deposit") ||
                TransactionNarration.Contains("withdrawal") ||
                TransactionNarration.Contains("transfer"))
            {
                Console.WriteLine($"Transaction Id: {TransactionId}");
                Console.WriteLine($"Account Holder: {AccountHolderName}");
                Console.WriteLine($"Narration: {TransactionNarration}");
                Console.WriteLine($"Category : CUSTOM TRANSACTION");
            }
            else
            {
                Console.WriteLine($"Transaction Id: {TransactionId}");
                Console.WriteLine($"Account Holder: {AccountHolderName}");
                Console.WriteLine($"Narration: {TransactionNarration}");
                Console.WriteLine($"Category : NON-FINANCIAL TRANSACTION");
            }

        }
    }
}
