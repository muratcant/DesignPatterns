using System;

namespace Singleton
{
    public class SingletonObject
    {
        private static SingletonObject obj = new SingletonObject();
        private static int count;
        private readonly String name;

        private SingletonObject()
        {
            count++;
            name = "Singleton"+count;
        }

        public static SingletonObject GetInstance()
        {
            return obj;
        }

        public void PrintName()
        {
            Console.WriteLine(name);
        }

    }
}
