using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvisWin.Invis.modules
{
    public class CmdPuts : Invis.types.Command
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

        public string init(string[] args)
        {
            try
            {
                if (args.Length < 2) return "Z"; // Return with error of missing arguments

                // Write to the screen

                ConsoleColor textColor = ConsoleColor.White;


                // This section of IFs defines which color is which
                if (args[1].ToLower().Contains("white")) textColor = ConsoleColor.White;
                else if (args[1].ToLower().Contains("black")) textColor = ConsoleColor.Black;
                else if (args[1].ToLower().Contains("red")) textColor = ConsoleColor.Red;
                else if (args[1].ToLower().Contains("magenta")) textColor = ConsoleColor.Magenta;
                else if (args[1].ToLower().Contains("blue")) textColor = ConsoleColor.Blue;
                else if (args[1].ToLower().Contains("yellow")) textColor = ConsoleColor.Yellow;
                else if (args[1].ToLower().Contains("green")) textColor = ConsoleColor.Green;

                Program.ConsoleWrite(args[0], textColor);

                // Return sucess
                return "S";
            }
            catch (Exception)
            {
                return "Y"; // Return the unexpected error
            }
        }


        /// <summary>
        /// Initializes the PUTS module
        /// </summary>
        /// <param name="environment"></param>
        public CmdPuts(Environment environment)
        {
            this.name = "Puts";
            this.cmd = "PUTS";
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
