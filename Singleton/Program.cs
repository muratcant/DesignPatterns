using System;
using System.Diagnostics;
using System.Threading;

namespace Singleton
{
    class Program
    {
        public static Stopwatch sw;
        static void Main(string[] args)
        {
            sw = new Stopwatch();
            NormallySingleton();
            Console.WriteLine($"Normally Singleton->{sw.Elapsed}");
            AfterLoadSingleton();
            Console.WriteLine($"After Load Singleton->{sw.Elapsed}");
            NonThreadSafeSingleton();
            Console.WriteLine($"Non-Thread Safe Singleton->{sw.Elapsed}");
            ThreadSafeSingleton();
            Console.WriteLine($"Thread Safe Singleton->{sw.Elapsed}");
            DoubleCheckedLockingSingleton();
            Console.WriteLine($"Double Checked Locking Singleton->{sw.Elapsed}");
            ThreadSafeLazySingleton();
            Console.WriteLine($"Thread Safe Lazy Singleton->{sw.Elapsed}");
            Console.ReadLine();
        }


        static void NormallySingleton()
        {
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                SingletonObject.GetInstance();
            }
            sw.Stop();
        }
        static void AfterLoadSingleton()
        {
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                SingletonAfterLoadObject.GetInstance();
            }
            sw.Stop();
        }
        static void NonThreadSafeSingleton()
        {
            Program client = new Program();
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                Thread thread = new Thread(new ThreadStart(client.Run));
                thread.Start();
            }
            sw.Stop();
        }
        static void ThreadSafeSingleton()
        {
            Program client = new Program();
            sw.Restart();
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                Thread thread = new Thread(new ThreadStart(client.Run2));
                thread.Start();
            }
            sw.Stop();
        }
        static void ThreadSafeLazySingleton()
        {
            Program client = new Program();
            sw.Restart();
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                Thread thread = new Thread(new ThreadStart(client.Run4));
                thread.Start();
            }
            sw.Stop();
        }
        static void DoubleCheckedLockingSingleton()
        {
            Program client = new Program();
            sw.Restart();
            sw.Start();
            for (int i = 0; i < 200; i++)
            {
                Thread thread = new Thread(new ThreadStart(client.Run3));
                thread.Start();
            }
            sw.Stop();
        }


        public void Run()
        {
            NonThreadSafeSingletonObject.GetInstance();
        }

        public void Run2()
        {
            ThreadSafeSingletonObject.GetInstance();
        }

        public void Run3()
        {
            DoubleCheckedLockingSingletonObject.GetInstance();
        }
        public void Run4()
        {
            ThreadSafeLazySingletonObject.GetInstance();
        }
    }
}
