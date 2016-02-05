using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonCF.Core
{
    public class ConsoleLogger : ILog
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
