using System;

namespace Task3
{
    class Program
    {
        class Converter
        {
            public Converter(double usd, double eur)
            {
                this.usd = usd;
                this.eur = eur;
            }

            public double Convert(double uah, string currency)
            {
                if (currency == "usd")
                {
                    return uah/usd;
                }
                else if (currency == "eur")
                {
                    return uah/eur;
                }
                else
                {
                    return 0;
                }
            }

            private double usd;
            private double eur;

        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write double values with dot, like: 28.5  but not: 28,5");

            
            Console.WriteLine("Enter value of dollar regards to hryvna");
            double usd = Double.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter value of euro regards to hryvnya");
            double eur = Double.Parse(Console.ReadLine());
            
            Converter converter = new Converter(usd, eur);
            
            Console.WriteLine("Enter amount of money in hryvna");
            double uah = Double.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter currency in what you want to convert hryvnya (available usd and eur)");
            string currency = Console.ReadLine();

            double convertedAmount = converter.Convert(uah, currency);

            if (convertedAmount == 0)
            {
                Console.WriteLine("Unknown currency {0}", currency);
            }
            else
            {
                Console.WriteLine("It will be {0} {1} for {2} hryvnas", convertedAmount, currency, uah);
            }
        }
    }
}