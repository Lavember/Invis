using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisWin.Invis.types
{
    /// <summary>
    /// A sort of module that can be added into the Invis Environment
    /// </summary>
    public interface Command
    {
        /// <summary>
        /// Official name of said command
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// Invis command for using the module
        /// </summary>
        string cmd { get; set; }

        /// <summary>
        /// Initialization/Calling method.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        string init(string[] args);

        /// <summary>
        /// Parent environment of command
        /// </summary>
        Environment parentEnv { get; set; }


    }
}
