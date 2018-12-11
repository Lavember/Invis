using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvisWin.Invis.types;
using System.IO;

namespace InvisWin.Invis
{
    /// <summary>
    /// The Invis interpreter for .NET Windows
    /// </summary>
    public static class InvInterpret
    {
        /// <summary>
        /// The interpreter environment. (list of variables and more)
        /// </summary>
        public static Environment environment = new Environment();


        /// <summary>
        /// Loads script into the interpreter
        /// </summary>
        /// <param name="path">Path for the script file</param>
        /// <returns>A custom error code warning if the code was sucessful or not.</returns>
        public static ReturnCode LoadScript(string path)
        {

            try
            {
                // Try reading file
                string[] scriptLines = File.ReadAllLines(path);

                try
                {
                    bool isInvis = false; // Test if the script is an INVIS one by detecting if there is "invis" at the first line

                    if (scriptLines.Length > 0 && scriptLines[0].ToLower().Contains("invis")) isInvis = true;

                    if (!isInvis) return new ReturnCode("Not Invis script", -3, "LoadScript"); // Return the error code of absence of script declaration


                    // This section sums up all cmd abbreviations to analyze if there is any on the code.
                    List<string> cmdList = new List<string>();

                    
                    try
                    {
                        foreach(Command c in environment.envCommands) cmdList.Add(c.cmd); // Add to the command list environment commands (not external)
                        foreach (Command c in environment.loadedCommands) cmdList.Add(c.cmd); // Add all external commands/modules

                    }
                    catch (Exception)
                    {
                        return new ReturnCode("Unexpected error on command list loading", -2, "LoadScript");
                    }


                    // Go through all lines scanning and interpreting
                    for(int line_index = 0; line_index < scriptLines.Length; line_index++)
                    {
                        // If the current line is the declaration of the script, skip it.
                        if (scriptLines[line_index].ToLower() == "invis")
                        {
                            if (Program.debug) Program.ConsoleWrite("The line " + (line_index + 1).ToString() + " was skipped for being script declaration (Invis)" + "\n", ConsoleColor.Yellow);
                            continue;
                        }

                        // If the current line is empty
                        if (scriptLines[line_index].Replace(" ", "").Replace('\u0009', '\0') == "")
                        {
                            if (Program.debug) Program.ConsoleWrite("The line " + (line_index + 1).ToString() + " was skipped for being empty" + "\n", ConsoleColor.Yellow);
                            continue;
                        }

                        try
                        {
                            // Try to separate the first argument from the rest
                            string fArgument = scriptLines[line_index].Split(new string[] { "[]" }, StringSplitOptions.RemoveEmptyEntries)[0];

                            bool cmdDefinitionFound = false; // Determines if any command like fArgument was found.
                            foreach(string cmd_ in cmdList)
                            {
                                if(cmd_.ToLower() == fArgument.ToLower())
                                {
                                    cmdDefinitionFound = true;
                                }
                            }

                            if (!cmdDefinitionFound) throw new Exception(); // Generate error if there is no object with the same name

                            // Go on executing the command

                            // Now get the command from the environment.
                            Command execCmd = environment.envCommands.Find(item => item.cmd.ToLower() == fArgument.ToLower());

                            string[] arguments = scriptLines[line_index].Substring(execCmd.cmd.Length).Split(new string[] { "[]" }, StringSplitOptions.RemoveEmptyEntries);
                            string result = execCmd.init(arguments);

                            if(result == "A" || result == "Y" || result == "Z") // If any of these ocurr will cause an error
                            {
                                throw new Exception(result);
                            }
                            

                        }
                        catch (Exception ex)
                        {
                            // Add error to the environment to document to the user later on.
                            environment.errors.Add(new Error("Error at line" + (line_index + 1).ToString()));

                            Program.ConsoleWrite("ERROR \\/\\/\\/ At line " + (line_index + 1).ToString() + "\n", ConsoleColor.Red);
                            Program.ConsoleWrite(ex.Message + "\n" + " is the message", ConsoleColor.DarkRed);
                        }

                    }

                    // Return that all did good
                    return new ReturnCode("All good", 1, "LoadScript");


                }
                catch (Exception unexpected)
                {
                    return new ReturnCode(unexpected.Message, -2, "LoadScript");
                }

            }catch(Exception)
            {
                return new ReturnCode("Couldn't find file", -1, "LoadScript");
            }

            return new ReturnCode("SOMETHING REALLY WENT WRONG", -1, "LoadScript");
        }


    }

}

/*
 * ReturnCode custom codes for Invis
 * NEGATIVE = BAD/ERROR
 * POSITIVE = GOOD/SUCCEED (sometimes)
 * -3 = Not Invis script
 * -2 = Unexpected error
 * -1 = No result error
 * 0 = Neutral (minor errors maybe or complete sucess)
 * 1 = Complete sucess
 * 509 = Exploited 
 */