using System;

namespace CheckTests
{

    class ClassA : ClassB
    {
        public void Method1()
        {
            System.Console.WriteLine("ClassA Method1");
        }
    }

    class ClassB
    {
        public string str = "aaa";

        public void Method2()
        {
            System.Console.WriteLine("ClassB Method2");
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            
            ClassA classA = new ClassA();
            ClassB classB = new ClassB();
            classB = classA;
            classA = classB;
            
            classA.Method1();
            Console.ReadKey();
        }
    }
}