using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class ThreadSafeLazySingletonObject
    {
        private static Lazy<ThreadSafeLazySingletonObject> obj = new Lazy<ThreadSafeLazySingletonObject>(() => new ThreadSafeLazySingletonObject());
        private static object lockObject = new object();

        private static int count;
        private readonly string name;

        private ThreadSafeLazySingletonObject()
        {
            count++;
            name = $"Singleton{count}";
            PrintName();
        }

        public static ThreadSafeLazySingletonObject GetInstance()
        {
            return obj.Value;
        }

        private void PrintName()
        {
            Console.WriteLine(name);
        }
    }
}
