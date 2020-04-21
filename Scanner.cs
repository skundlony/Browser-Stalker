using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebStalker
{
    public class Scanner
    {
        public async void Scan()
        {
            Console.WriteLine("Scanner started.");
            
            await Task.Run(() =>
            {
                var browser = new Browser();
                while (true)
                {
                    Task.Run(() =>
                    {
                        browser.StalkBrowser();
                    });
                    
                    Thread.Sleep(2000); // check every 5s
                }
            });
        }
    }
}
