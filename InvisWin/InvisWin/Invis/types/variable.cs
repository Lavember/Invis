using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisWin.Invis.types
{
    /// <summary>
    /// Contains a type and a value containing information.
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Parent environment of the variable
        /// </summary>
        public Environment parentEnv;

        /// <summary>
        /// Initializes the variable.
        /// </summary>
        public Variable(Environment env)
        {
            env = parentEnv;
        }

    }
}
