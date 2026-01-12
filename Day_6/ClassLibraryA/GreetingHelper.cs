namespace ClassLibraryA
{
    public class GreetingHelper
    {
        public static string GetGreet(string name){

            if(name == null || name == " "){
             return "Hello Guest";     
        }
            else{
        return $"Hello {name}";

        }
            }
    }
}
