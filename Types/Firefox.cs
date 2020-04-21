using System;
using System.Collections.Generic;
using System.Text;

namespace WebStalker.Types
{
    public class Firefox : Browser
    {
        private const string procName = "firefox";
        public Firefox()
        {
            base.ProcessName = procName;
        }

        public Firefox(int spid)
        {
            base.ProcessName = procName;
            base.Spid = spid;
        }
    }
}