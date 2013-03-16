using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RogueCoder.Models
{

    public class Computer
    {
        private Dictionary<string,object> variables;
        int loopCount = 0;
        int loopLine = 0;
        int loopMax = 0;

        public Computer()
        {
            variables = new Dictionary<string, object>();
        }
        /// <summary>
        /// Compile the program
        /// </summary>
        /// <param name="program"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public bool Compile(System.Collections.Generic.Dictionary<int,string> program,out List<string> messages)
        {
            messages = new List<string>();
            return true;
        }

        /// <summary>
        /// Run the program
        /// </summary>
        /// <param name="program">lines of the program</param>
        /// <param name="gameObjects">list of objects accessible by the program</param>
        /// <param name="commands">List of all commands that are generated as a result of running the program</param>
        /// <returns>/// <param name="program">lines of the program</param></returns>
        public string Run(System.Collections.Generic.Dictionary<int, string> program,ref List<ComputerAccessibleObject> gameObjects,out List<string> errors)
        {
            errors = new List<string>();
            List<string> messages = new List<string>();
            StringBuilder output = new StringBuilder();


            int lineNumber = 0;
            while (lineNumber< program.Count)
            {
                var li = program.FirstOrDefault(k => k.Key == lineNumber);
                if (!li.Equals(null) && !String.IsNullOrWhiteSpace(li.Value))
                {
                    string[] lineCommands = li.Value.Split(' ');
                    lineNumber = li.Key;
                    string command = lineCommands[0].ToUpper();
                    List<string> parameters = lineCommands.Skip(1).ToList();
                    string error;
                    output.Append(ProcessCommand(ref lineNumber, command, parameters,ref gameObjects,out error));
                    if (error != string.Empty)
                        errors.Add(error);
                }
                else
                {
                    errors.Add("Error line number can not be null");
                }

                lineNumber++;
            }
           
            return output.ToString();
        }

        public string ProcessCommand(ref int line,string command,List<string> parameters,ref List<ComputerAccessibleObject> gameObjects,out string Error )
        {
            Error = string.Empty;
            string output = string.Empty;
            StringBuilder outputBuffer = new StringBuilder();
            
            
            switch (command.ToUpper())
            {
                case "DISPLAY":
                   
                    output = parameters[0];
                    break;
                case "DISPLAYVAR":
                    //todo check that the variable exists
                    string key = parameters[0];
                    output = "DisplayVar = " + key + "=" + variables[key].ToString();
                    break; 
                case "--":
                    //skip
                    break;
                case "VARINT":
                    int val;
                    //todo check that the variable exists
                    if (int.TryParse(parameters[1], out val))
                    {
                        variables.Add(parameters[0], val);
                    }
                    else
                        Error = "Integer variable is not assigned correctly";
                    break;
                case "VARSTRING":
                    //todo check that the variable exists
                    string stringVal = parameters[1];
                    variables.Add(parameters[0], stringVal);
                    break;
                case "VARBOOL":
                    //todo check that the variable exists
                    bool boolVal;
                    if (bool.TryParse(parameters[1],out boolVal))
                    {
                         variables.Add(parameters[0], boolVal);
                    }
                    else
                        Error = "Bool variable is not assigned correctly";
                    break;
                case "LOOP":
                    //todo make sure there is a loopend
                    loopLine = line;
                    loopMax = int.Parse(parameters[0]);
                    loopCount = 0;
                    //Handle the loop
                    break;
                case "LOOPEND":
                    //todo make sure there is a loopend
                    loopCount++;
                    if (loopCount < loopMax)
                    {
                        line = loopLine;
                    }
                    break;
                case "IFCONNECTDISPLAY":
                    {
                        if (ConnectCommand(parameters, gameObjects, output) == "Connected")
                        {
                            if (parameters[1].ToUpper() == "LOOPCOUNT")
                                output = loopCount.ToString();
                            else
                                output = parameters[1];
                        }
                    }
                    break;
                case "EXECUTE":
                    if (gameObjects == null)
                    {
                        output = "No game objects";
                    }
                    else
                    {
                        string gameObject = parameters[0];
                        string param = string.Empty;
                        string commandParam = string.Empty;
                        if (parameters.Count >= 2)
                        {
                            param = parameters[1];
                        }

                        ComputerAccessibleObject gameObjectFound = gameObjects.FirstOrDefault(g => g.name == gameObject);
                        if (gameObjectFound == null)
                        {
                            output = String.Format("No object called  {0} can be found", gameObject);
                        }
                        else
                        {
                            string gameObjectResult = gameObjectFound.Execute(param);
                            gameObjects.ToList().ForEach(go => outputBuffer.Append(gameObjectResult));
                            output = outputBuffer.ToString();
                        }
                    }

                    break;
                case "CONNECT":
                    output = ConnectCommand(parameters, gameObjects, output);
                    break;
                case "LISTOBJECTS":
                    StringBuilder objects = new StringBuilder();
                    gameObjects.ToList().ForEach(g => objects.Append(g.name+ ";"));
                    output = "objects available:" + objects.ToString();

                    break;
                case "HELP":
                    output = "HELP FOR DOMINICSCRIPT: DISPLAY [TEXT]; DISPLAYVAR [VAR];, -- {COMMENT},VARINT ,VARBOOL [VAR]; " +
                        "CONNECT [OBJECT], IFCONNECTDISPLAY [VAR/LOOPCOUNT], LOOP [TIMES TO LOOP], LOOPEND, EXECUTE [OBJECT] [PARAMS] HELP";
                    break;
                default:
                    Error = "Not a valid command" + command.ToUpper();
                    break;
            }

            return output; 
        }

        private string ConnectCommand(List<string> parameters, List<ComputerAccessibleObject> gameObjects, string output)
        {
            if (gameObjects == null)
            {
                output = "No game objects";
            }
            else
            {
                string gameObject = parameters[0];
                string param = string.Empty;
                string pwd = string.Empty;
                if (parameters.Count >= 2)
                {
                    param = parameters[0];
                    if (parameters[1].ToUpper() == "LOOPCOUNT")
                        pwd = loopCount.ToString();
                    else
                        pwd = parameters[1];
                }

                ComputerAccessibleObject gameObjectFound = gameObjects.FirstOrDefault(g => g.name == gameObject);
                if (gameObjectFound == null)
                    output = String.Format("No object called  {0} can be found", gameObject);
                else
                    output = (gameObjectFound.Connect(pwd)) ? "Connected" : "No Connected";
            }
            return output;
        }

    }
}
