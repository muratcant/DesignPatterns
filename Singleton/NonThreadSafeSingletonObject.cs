using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class NonThreadSafeSingletonObject
    {
        private static NonThreadSafeSingletonObject obj;
        private static int count;
        private readonly String name;

        private NonThreadSafeSingletonObject()
        {
            count++;
            name = "Singleton" + count;
            PrintName();
        }

        public static NonThreadSafeSingletonObject GetInstance()
        {
            if (obj == null)
                obj = new NonThreadSafeSingletonObject();
            return obj;
        }

        public void PrintName()
        {
            Console.WriteLine(name);
        }
    }
}
