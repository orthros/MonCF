using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonCF.Core
{
    /// <summary>
    /// Interface for Logging
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Logs the passed string. 
        /// </summary>
        /// <param name="message">The Message to Log</param>
        void Log(string message);
    }
}
