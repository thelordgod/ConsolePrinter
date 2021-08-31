using System;

namespace ConsolePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            FramePrinter framePrinter = new FramePrinter("ass", 10, 5);
            Console.WriteLine(framePrinter.GetFrame());
            var nicePrinter = new NicePrinter();
            Console.WriteLine(nicePrinter.GetNice());
        }
    }
}