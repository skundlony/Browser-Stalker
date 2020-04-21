using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebStalker.Types;

namespace WebStalker
{
    public class Scanner
    {
        private List<Browser> Browsers = new List<Browser>();
        private Object _lock = new Object();

        public List<Browser> GetActiveBrowsers()
        {
            lock (_lock)
            {
                return Browsers;
            }
        }

        public async void Scan()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    // uruchomic instancje firefox / chrome
                    // kazda instancja typu browser ma zwracac liste processow
                    Task.Run(() =>
                    {
                        var firefox = new Firefox();
                        // dodac firefoxy
                        var firefoxProc = firefox.LookForProcess();
                        foreach(var proc in firefoxProc)
                        {
                            Browsers.Add(new Firefox() { Spid = proc.Id });
                        }

                        Console.WriteLine($"Updated pool with {firefox.ProcessName}");
                    });

                    Console.WriteLine("Skaner sobie chodzi");
                    Thread.Sleep(1000);
                }
            });
        }

        private void UpdateProcPool<T>(T brow)
        {
            lock (_lock)
            {
                // add new one 
                Browsers.Add(T.GetType());
            }
        }

    }
}
