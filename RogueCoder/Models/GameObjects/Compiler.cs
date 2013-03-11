using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogueCoder.Models.GameObjects
{
    public class Compiler
    {
        public Dictionary<int, string> Compile(string[] sourceCode, out string[] errors)
        {
            errors = new string[5];
            Dictionary<int,string> compiledCode = new Dictionary<int,string>();
            int lineCount = 0;

            foreach (string line in sourceCode)
            {
                if (!line.StartsWith("--"))
                {
                    compiledCode.Add(lineCount++,line);
                }

            }
            return compiledCode;
        }
    }
}