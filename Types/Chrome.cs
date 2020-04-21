using System;
using System.Collections.Generic;
using System.Text;

namespace WebStalker.Types
{
    public class Chrome : Browser
    {
        private const string procName = "chrome";
        public Chrome()
        {
            base.ProcessName = procName;
        }

        public Chrome(int spid)
        {
            base.ProcessName = procName;
            base.Spid = spid;
        }
    }
}