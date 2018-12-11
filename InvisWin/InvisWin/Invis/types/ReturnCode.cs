using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisWin.Invis.types
{
    /// <summary>
    /// Used in functions to indicate wheter it succedeed or not.
    /// </summary>
    public class ReturnCode
    {

        /// <summary>
        /// Attached message from the caller function
        /// </summary>
        public string message = "";


        /// <summary>
        /// Used for custom return codes in different methods.
        /// </summary>
        public int code = 0;


        /// <summary>
        /// Used generally for naming its caller function
        /// </summary>
        public string name = "";

        /// <summary>
        /// Initializes a Return Code class.
        /// </summary>
        /// <param name="message">Attached message about the method completion</param>
        /// <param name="code">Custom numeric code (Leave at 0 if there is none)</param>
        /// <param name="functionName">Caller function's name</param>
        public ReturnCode(string message, int code, string functionName)
        {
            this.message = message;
            this.code = code;
            this.name = functionName;
        }

    }
}
