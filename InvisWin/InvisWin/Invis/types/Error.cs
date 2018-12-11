using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisWin.Invis.types
{
    /// <summary>
    /// Error defined in Invis
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Error message/ What it is
        /// </summary>
        public string message;
        
        /// <summary>
        /// Error initialization
        /// </summary>
        /// <param name="message">What the error is</param>
        public Error(string message)
        {
            this.message = message;
        }
    }
}
