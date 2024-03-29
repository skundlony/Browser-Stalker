﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebStalker
{
    public class Stalker
    {
        [DllImport("user32.dll")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        private int sleepTimeMs;

        public Stalker(int checkIntervalMs)
        {
            sleepTimeMs = checkIntervalMs;
        }

        readonly List<string> browserNames = new List<string>
        {
            "chrome",
            "firefox",
            "iexplore",
            "safari",
            "opera",
            "msedge"
        };


        private IEnumerable<int> GetBrowserProcessIds(string procName)
        {
            if (string.IsNullOrEmpty(procName))
                throw null;

            return Process.GetProcessesByName(procName).Select(x => x.Id);
        }

        public void StalkActiveBrowsersTabs()
        {
            while (true)
            {
                Parallel.ForEach(browserNames, (browser) =>
                {
                    StalkEach(browser);
                });

                Thread.Sleep(sleepTimeMs);
            }
        }

        private async void StalkEach(string procName)
        {
            await Task.Run(() =>
            {
                var processes = Process.GetProcessesByName(procName);
                foreach (var proc in processes)
                {
                    if (!string.IsNullOrEmpty(proc.MainWindowTitle))
                    {
                        IntPtr hWnd = proc.MainWindowHandle;
                        int length = GetWindowTextLength(hWnd);

                        StringBuilder text = new StringBuilder(length + 1);
                        GetWindowText(hWnd, text, text.Capacity);
                        Console.WriteLine($"{DateTime.Now} - {text} ({procName})");
                    }
                }
            });
        }
    }
}