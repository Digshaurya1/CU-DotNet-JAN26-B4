using System.Security.Cryptography;

namespace Day15
{


    class Height
    {


        public Height()
        {
            feet = 0;
            inches = 0.0f;
        }
        public Height(int feet, float inches)
        {
            this.feet = feet;
            this.inches = inches;
        }

        private int feet;

        public int Feet
        {
            get { return feet; }
            set { feet = value; }
        }

        private float inches;

        public float Inches
        {
            get { return inches; }
            set { inches = value; }
        }




        public Height AddHeights(Height h2)
        {
            int totalH = h2.feet + feet;

            float totalI = h2.inches + inches;

            if (totalI >= 12)
            {
                totalH += (int)totalI / 12;
                totalI = totalI % 12f;

            }
            Height addedHeight = new Height(totalH, totalI);
            return addedHeight;
            //Console.WriteLine($"{totalH} Feets {totalI} Inches");

        }

        public Height(float inches)
        {
            this.feet = (int)inches / 12;
            this.inches = inches % 12;

        }

        public override string ToString()
        {
            return $"{feet} Feets {Inches:F2} Inches";
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Height h = new Height();
            Height h1 = new Height(5, 5.6f);
            Height h2 = new Height(6, 2.2f);
            Height h3 = new Height(160.57f);

            Console.Write("Default const :");
            Console.WriteLine(h);

            Console.Write("Height 1: ");
            Console.WriteLine(h1);
            Console.Write("Height 2: ");
            Console.WriteLine(h2);
            Console.Write("Height 3: ");
            Console.WriteLine(h3);
            Console.Write("SUm of Height 2 and Height 1: ");
            Height hsum  = h2.AddHeights(h1);
            Console.WriteLine(hsum);
        }
    }
}
