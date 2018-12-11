using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using InvisWin.Invis;
using InvisWin.Invis.types;


namespace InvisWin
{
    class Program
    {

        /// <summary>
        /// If debug mode is active or not. 
        /// </summary>
        public static bool debug = true;

        /// <summary>
        /// The entry point for the Invis interpreter.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            #region Basic pre-init tasks

            // Enable if you want to take a look into a "behind the scenes" of the application


            if (debug) ConsoleWrite("The program args[] are: ", ConsoleColor.White);
            if (debug) ConsoleWrite(String.Join("", args) + "\n", ConsoleColor.Green);

            // Find out what the args mean

            InitOptions initOptions = InitOptions.ExecCmd; // It must be ExecCmd by default.
            string execScriptPath = null;

            try
            {
                if (args.Length < 1) initOptions = InitOptions.ExecCmd;
                else if (args[0].ToLower() == "PATH" && args.Length >= 2) if (File.Exists(args[1])) execScriptPath = args[1]; initOptions = InitOptions.ExecScript;


                try { execScriptPath = args[1]; } catch(Exception exc) { }



            }
            catch (Exception exception)
            {
                if (debug) ConsoleWrite(exception.Message + "\n", ConsoleColor.Red);
                else ConsoleWrite("Error :(", ConsoleColor.Red);
            }


            if (debug) ConsoleWrite("initOptions: ", ConsoleColor.White);
            if (debug) ConsoleWrite(initOptions.ToString() + "\n", ConsoleColor.Green);
            if (debug) ConsoleWrite("execScriptPath: ", ConsoleColor.White);
            if (debug) ConsoleWrite(execScriptPath + " | File exists: " + File.Exists(execScriptPath) + "\n", ConsoleColor.Green);

            // Convert pseudo-path (not readable to windows) to a real path

            if (execScriptPath != null) execScriptPath = Path.GetFullPath(execScriptPath);



            #endregion

            #region Time to execute the code!

            if(initOptions == InitOptions.ExecScript)
            {
                ReturnCode result = InvInterpret.LoadScript(execScriptPath);

                if(result.code < 0)
                {
                    ConsoleWrite("Something went wrong when executing the script. ", ConsoleColor.Yellow);
                    ConsoleWrite(result.message + "\n", ConsoleColor.White);
                }
                else
                {
                    ConsoleWrite("The script executed mostly (or fully) correctly. ", ConsoleColor.Green);
                    ConsoleWrite(result.message + "\n", ConsoleColor.White);
                }

            }

            #endregion

            // For having time to read when building
            if (debug) Console.ReadLine();
        }


        /// <summary>
        /// Writes into the console with the desired color
        /// </summary>
        /// <param name="message">The message that the console will output</param>
        /// <param name="color">The desired color showed by the console</param>
        public static void ConsoleWrite(string message, ConsoleColor color)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        /// Changes the windoww title. Built for module "title"
        /// </summary>
        /// <param name="newTitle"></param>
        public static void TitleChange(string newTitle)
        {
            Console.Title = newTitle;
        }
        
        /// <summary>
        /// The program initalization options
        /// ExecScript = It will execute a choosen script
        /// ExecCmd = The user will be free to execute any sort of commands for a "sandbox" aproach
        /// </summary>
        public enum InitOptions
        {
            ExecScript,
            ExecCmd
        }


    }
}
