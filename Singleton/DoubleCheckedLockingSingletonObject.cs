using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class DoubleCheckedLockingSingletonObject
    {
        private static volatile DoubleCheckedLockingSingletonObject obj;
        private static object lockObject = new object();

        private static int count;
        private readonly string name;

        private DoubleCheckedLockingSingletonObject()
        {
            count++;
            name = $"Singleton{count}";
            PrintName();
        }

        public static DoubleCheckedLockingSingletonObject GetInstance()
        {
            if (obj == null)
            {
                lock (lockObject)
                    if (obj == null)
                        obj = new DoubleCheckedLockingSingletonObject();

            }
            return obj;
        }

        private void PrintName()
        {
            Console.WriteLine(name);
        }
    }
}
