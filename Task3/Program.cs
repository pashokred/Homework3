using System;

namespace Task3
{
    class Program
    {

        class Converter
        {
            public Converter(double currencyCourse)
            {
                CurrencyCourse = currencyCourse;
            }

            public double ToUah(double currency)
            {
                return currency * CurrencyCourse;
            }
            public double UahTo(double uah)
            {
                return uah / CurrencyCourse;
            }

            private double CurrencyCourse { get; }
        }
        enum Exchange
        {
            USDtoUAH,
            EURtoUAH,
            UAHtoEUR,
            UAHtoUSD,
        }
        
        private static int ParseInt(string value)
        {
            if (!int.TryParse(value, out int parsedInt) || int.Parse(value) >3 || int.Parse(value) < 0)
            {
                throw new ArgumentException("Invalid operation number", value);
            }

            return parsedInt;
        }

        private static double ParseDouble(string value)
        {
            if (!double.TryParse(value, out double parsedDouble))
            {
                throw new ArgumentException("Invalid currency value", value);
            }
            
            return parsedDouble;
        }


        static void Main()
        {
            Console.WriteLine("Please, write double values with dot, like: 28.5  but not: 28,5");
            Console.WriteLine("Enter number that define operation you want to do:\n" +
                              "0: USD - UAH\n" +
                              "1: EUR - UAH\n" +
                              "2: UAH - EUR\n" +
                              "3: UAH - USD");

            try
            {
                var operation = (Exchange) ParseInt(Console.ReadLine());
                Console.WriteLine("Enter value of your currency regards to hryvna");
                
                Converter converter = new Converter(ParseDouble(Console.ReadLine()));
                Console.WriteLine("Enter amount of currency you want to convert");
                
                double amount = ParseDouble(Console.ReadLine());
                
                switch (operation)
                {
                    case Exchange.USDtoUAH:
                        Console.WriteLine("This will be {0} UAH for {1} USD",
                            Convert.ToDouble($"{converter.ToUah(amount):0.00}"), amount);
                        break;
                    case Exchange.EURtoUAH:
                        Console.WriteLine("This will be {0} UAH for {1} EUR",
                            Convert.ToDouble($"{converter.ToUah(amount):0.00}"), amount);
                        break;
                    case Exchange.UAHtoEUR:
                        Console.WriteLine("This will be {0} EUR for {1} UAH",
                            Convert.ToDouble($"{converter.UahTo(amount):0.00}"), amount);
                        break;
                    case Exchange.UAHtoUSD:
                        Console.WriteLine("This will be {0} USD for {1} UAH",
                            Convert.ToDouble($"{converter.UahTo(amount):0.00}"), amount);
                        break;
                    default:
                        Console.WriteLine("Operation {0} doesn't exist", operation);
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                throw;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                throw;
            }
        }
    }
}