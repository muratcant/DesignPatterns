using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonAfterLoadObject
    {
        private static SingletonAfterLoadObject obj;
        private static int count;
        private readonly String name;

        private SingletonAfterLoadObject()
        {
            count++;
            name = "Singleton" + count;
            PrintName();
        }

        public static SingletonAfterLoadObject GetInstance()
        {
            if (obj == null)
                obj = new SingletonAfterLoadObject();
            return obj;
        }

        public void PrintName()
        {
            Console.WriteLine(name);
        }
    }
}
