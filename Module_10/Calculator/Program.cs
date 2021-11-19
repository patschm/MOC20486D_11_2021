using CalcLib;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            RekenMachine mach = new RekenMachine();

            int actual = mach.Trekaf(3, 4);

            Console.WriteLine(actual == 7 ? "Gslaagd":"Fout");
        }
    }
}
