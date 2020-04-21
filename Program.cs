using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using WebStalker.Types;

namespace WebStalker
{
    class Program
    {
        static void Main(string[] args)
        {
            var scan = new Scanner();
            scan.Scan();

            while(true)
            {
                Console.WriteLine(scan.GetActiveBrowsers().Count);
                Console.WriteLine("Główny watek");
                Thread.Sleep(2000);
            }
        }
    }
}
