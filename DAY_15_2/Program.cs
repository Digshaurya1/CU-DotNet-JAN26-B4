using System.Net.NetworkInformation;

namespace DAY_15_2
{   

    class Order
    {

        bool discount = false;
        public int OrderId { get; }


        private string customerName;

        public decimal Total { get; set; }
        public string CustomerName
        {
            get { return customerName; }

            set { if(value != null || value !="")
                customerName = value; }
        }


        private decimal totalAmount;

        public decimal TotalAmount
        {
            get { return totalAmount; }
            
        }


        string status;
        public Order()
        {
            DateTime date = DateTime.Today;
            status = "NEW";
            
        }

        public Order(int orderId, string customerName)
        {
            this.OrderId = orderId;
            this.customerName = customerName;
            status = "NEW";
        }

         public void addItem(int cost)
        {
            if (cost > 0)
            {
                totalAmount += cost;
            }
            
        }

        public void ApplyDiscount(decimal precentage)
        {
            if (!discount && (precentage > 1 && precentage < 30) )
            {
                totalAmount = totalAmount - totalAmount * (precentage / 100);
                discount = true;
            }
            
        }

         public void GetOrderSummary()
        {
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Customer: {customerName}");
            Console.WriteLine($"Total Amount: {totalAmount}");
            Console.WriteLine($"Status: {status}");
        }




    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Order o1 = new Order(101,"CJ");
            o1.addItem(500);
            o1.addItem(600);
            o1.ApplyDiscount(10);
            o1.ApplyDiscount(10);
            o1.GetOrderSummary();

        }
    }
}
