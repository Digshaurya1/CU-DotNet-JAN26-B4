namespace DAY_16
{
    class ApplicationConfig {

        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static  int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;

            Console.WriteLine("Static constructor executed");

        }

        public static  void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }

        public static void GetConfigurationSummary() {
            Console.WriteLine($"Application Name: {ApplicationName}");
            Console.WriteLine($"Environment: {Environment}");
            Console.WriteLine($"Access Count: {AccessCount}");
            Console.WriteLine($"Initialization Status {IsInitialized}");
        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
        }

        public override string ToString()
        {
            return $"{ApplicationName}  {Environment}  {AccessCount}  {IsInitialized} ";
        }


     }



    internal class Program
    {
        static void Main(string[] args)
        {
            

            ApplicationConfig.Initialize("GPT", "LLM");
            ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine();
            ApplicationConfig.Initialize("Claud", "LLM");
            ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine();
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine("After Resetting");
            ApplicationConfig.GetConfigurationSummary();
        }
    }
}
