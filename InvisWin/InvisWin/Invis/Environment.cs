using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using InvisWin.Invis.types;

namespace InvisWin.Invis
{
    /// <summary>
    /// The class that stores within all functions, commands, variables and others.
    /// </summary>
    public class Environment
    {
        /// <summary>
        /// Variable collection 
        /// </summary>
        public List<Variable> variables = new List<Variable>();

        /// <summary>
        /// List of errors found by the interpreter
        /// </summary>
        public List<Error> errors = new List<Error>();

        /// <summary>
        /// All loaded commands/modules by the Invis interpreter.
        /// </summary>
        public List<Command> loadedCommands = new List<Command>();


        /// <summary>
        /// All Invis pre-loaded modules.
        /// </summary>
        public List<Command> envCommands = new List<Command>();

        /// <summary>
        /// Initializes the Invis Environment
        /// </summary>
        public Environment()
        {
            #region Load basic modules

            envCommands.Add(new modules.CmdTitle(this));
            envCommands.Add(new modules.CmdPuts(this));

            #endregion

        }


        /// <summary>
        /// Loads into the environment a brand new module.
        /// </summary>
        /// <param name="module">The new module variable that is going to hopefully loaded.</param>
        /// <returns>Custom error code to see if the module loading was sucessful or not.</returns>
        public ReturnCode LoadModule(Command module)
        {
            try
            {
                loadedCommands.Add(module);
            }
            catch (Exception)
            {
                return new ReturnCode("Unexpected error on module load", -2, "LoadScript");
            }


            //
            return new ReturnCode("SOMETHING REALLY WENT WRONG", -1, "LoadScript");
        }

    }
}
