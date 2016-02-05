using Orth.Core.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonCF.Test.Stubs
{
    public class StorageLogger : ILog
    {
        public StorageLogger()
        {
            Logs = new List<string>();
        }

        public List<string> Logs { get; private set; }

        public void Log(string message)
        {
            Logs.Add(message);
        }
    }
}
