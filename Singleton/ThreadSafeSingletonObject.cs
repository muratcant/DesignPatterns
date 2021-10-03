using System;

namespace Singleton
{
    class ThreadSafeSingletonObject
    {
        private static ThreadSafeSingletonObject obj;
        private static object lockObject = new object();

        private static int count;
        private readonly string name;

        private ThreadSafeSingletonObject()
        {
            count++;
            name = $"Singleton{count}";
            PrintName();
        }

        public static ThreadSafeSingletonObject GetInstance()
        {
            lock (lockObject)
                if (obj == null)
                    obj = new ThreadSafeSingletonObject();

            return obj;
        }

        private void PrintName()
        {
            Console.WriteLine(name);
        }
    }
}
