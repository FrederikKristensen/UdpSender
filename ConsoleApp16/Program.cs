using System;

namespace ConsoleApp16
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeWorker worker = new FakeWorker();
            worker.Start();


            Console.WriteLine("Hello World!");
        }
    }
}
