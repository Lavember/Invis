using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisWin.Invis.types
{
    /// <summary>
    /// Contains a type and a value containing information.
    /// Used only for system variables. For creating variables there are different types.
    /// </summary>
    public interface Variable
    {
        /// <summary>
        /// The value that this variable holds. May be a string (text), int (number) or a bool.
        /// </summary>
        object value { get; set; }

        /// <summary>
        /// Parent environment of the variable
        /// </summary>
        Environment parentEnv { get; set; }

       
    }
}
