using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = SingletonObject.GetInstance();
            data.PrintName();
            Console.ReadLine();
        }
    }
}
