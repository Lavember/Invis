using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisWin.Invis.modules
{
    /// <summary>
    /// COMMAND: Changes the title of the window.
    /// </summary>
    public class CmdTitle : Invis.types.Command
    {
        
        /// <summary>
        /// Command name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Command abbreviation for the Invis 
        /// </summary>
        public string cmd { get; set; }

        /// <summary>
        /// Parent environment.
        /// </summary>
        public Environment parentEnv { get; set; }

        /// <summary>
        /// Execute command 
        /// </summary>
        /// <param name="args">All the needed arguments for said command. In this case is one: the new window title</param>
        /// <returns></returns>
        public string init(string[] args)
        {
            try
            {
                if (args.Length < 1) return "Z"; // Return with error of missing arguments

                // Change the title by the functionality added back in Program.cs
                Program.TitleChange(args[0]);
                
                // Return sucess
                return "S";
            }
            catch (Exception)
            {
                return "Y"; // Return the unexpected error
            }
        }

        /// <summary>
        /// Initializes the module "Window Title Changer"
        /// </summary>
        /// <param name="environment"></param>
        public CmdTitle(Environment environment)
        {
            this.name = "Window Title Changer";
            this.cmd = "TITLE";
            this.parentEnv = environment;
        }
    }
}


/*
 * QUICK DOCS ON THE LETTER ERROR CODES
 * 
 * A = UNDEFINED
 * S = SUCESS
 * Y = EXECUTION ERROR
 * Z = ERROR OF ARGUMENTS
 */