using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiBitMainServer.DBLogic
{
    public class SpObject
    {
        public string Name { get; set; }
        public string value { get; set; }
        public MySqlDbType ParamType { get; set; }
    }
}
