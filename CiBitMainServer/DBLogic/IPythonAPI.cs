using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiBitMainServer.DBLogic
{
    public interface IPythonAPI
    { 
         string CSharpPythonRestfulApiSimpleTest(string uirWebAPI, string cibitId, out string exceptionMessage);
    }
}

