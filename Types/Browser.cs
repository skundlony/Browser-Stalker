using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WebStalker
{
    public abstract class Browser
    {
        public string ProcessName;
        public int Spid;

        public virtual Process[] LookForProcess() 
        {
            if (string.IsNullOrEmpty(ProcessName))
                throw null;

            var processes = Process.GetProcessesByName(ProcessName);
            return processes;
        }

        public virtual void Stalk()
        {
            if (Spid == 0)
                throw null;

            Console.WriteLine("Staling processes with spid: " + Spid);
        }
    }
}