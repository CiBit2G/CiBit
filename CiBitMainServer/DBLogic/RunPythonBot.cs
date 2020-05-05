using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CiBitMainServer.DBLogic
{
    public class RunPythonBot
    {
        public void run_cmd(string exeFullPath, string pyFullPath, string cibitId)
        {
            var arg = pyFullPath + " " + cibitId;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = exeFullPath;//cmd is full path to python.exe
            start.Arguments = arg;//args is path to .py file and any cmd line args -> C://Python26//test.py 100
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }
    }
}
