using CiBitMainServer.Mapping;
using CiBitMainServer.Models;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using System;
using System.Linq;
using System.Text;

namespace CiBitMainServer.DBLogic
{
    public class Tokens
    {
        public static string CreateToken(string value)
        {
            var timeStamp = DateTime.Now.ToString();
            var stamp = Encoding.UTF8.GetBytes(timeStamp);
            var saltedValue = stamp.Concat(Encoding.UTF8.GetBytes(value)).ToArray();
            return Convert.ToBase64String(saltedValue);
        }

        public static bool VerifyToken(string token, out string id)
        {
            var saltedValue = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var len = DateTime.Now.ToString().Count();
            var date = DateTime.Parse(saltedValue.Remove(len));
            id = saltedValue.Substring(len);
            if (date.AddMinutes(5).CompareTo(DateTime.Now) < 0)
                return false;
            if (IsUserExist(id))
                return true;
            else
                id = string.Empty;
            return false;
        }

        public static bool IsUserExist(string cibitId)
        {
            bool IsExist = false;
            var request = new GetUserRequest() { CibitId = cibitId };
            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(request);
            var spObj = Converters.GetUserConverter(userinfo);
            var reader = Controllers.UsersController._context.StoredProcedureSql("getUser", spObj);

            while(reader.Read())
            {
                IsExist = true;
            }

            Controllers.UsersController._context.Connection.Close();
            return IsExist;
        }
    }
}
