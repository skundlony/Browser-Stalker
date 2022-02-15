using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace WebStalker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scanner started.");
            new Stalker(2000)
                .StalkActiveBrowsersTabs();
        }
    }
}