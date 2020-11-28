using CiBitUtil.Message.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CiBitMainServer.DBLogic
{
    public class RunPythonBot
    {
        public void RunPyCmd(string pyFullPath, string cibitId)
        {
            var arg = pyFullPath + " " + cibitId;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = $"C:\\Users\\{Environment.UserName}\\OneDrive\\Documents\\GitHub\\CiBit\\PythonFiles\\venv\\Scripts\\python.exe";//cmd is full path to python.exe
            start.Arguments = arg;//args is path to .py file and any cmd line args -> C://Python26//test.py 100
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write("Python result: " + result);
                }
            }
        }
        public void RunPyCmd(string pyFullPath, string cibitId, NewTransactionRequest request)
        {
            var param = cibitId + " " + request.Amount + " " + request.ReceiverId + " " + int.Parse(request.ResearchId);
            var arg = pyFullPath + " " + param;

            try
            { 
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = $"C:\\Users\\{Environment.UserName}\\OneDrive\\Documents\\GitHub\\CiBit\\PythonFiles\\venv\\Scripts\\python.exe";//cmd is full path to python.exe
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

                    while (!process.HasExited)
                    {
                        //wait for prosses tp finish
                    }

                    if (process.ExitCode != 0)
                        Console.WriteLine("Pythone failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Pythone success");
        }
    }
}
