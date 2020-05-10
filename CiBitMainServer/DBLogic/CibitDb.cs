 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CiBitMainServer.DBLogic
{
    public class CibitDb : IDisposable
    {
        public MySqlConnection Connection { get; }

        public CibitDb( string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        private MySqlConnection GetConnection()
        {
            return Connection;
        }

        public void Dispose() => Connection.Dispose();

        public MySqlDataReader StoredProcedureSql(string spName, List<SpObject> spObject)
        {
            MySqlCommand cmd = new MySqlCommand(spName, Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (spObject != null)
                foreach (var obj in spObject)
                {
                    MySqlParameter param = new MySqlParameter(obj.Name, obj.value);
                    param.MySqlDbType = obj.ParamType;
                    cmd.Parameters.Add(param);
                }
            Connection.Open();
            return cmd.ExecuteReader();
        }
    }
}
