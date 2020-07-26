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

        public bool VerifyToken(string token)
        {
            var saltedValue = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var date = DateTime.Parse(saltedValue);
            if (date.AddMonths(5).CompareTo(DateTime.Now) < 0)
                return false;
            var len = DateTime.Now.ToString().Count();
            return IsUserExist(saltedValue.Substring(len - 1));           
        }

        private static bool IsUserExist(string cibitId)
        {
            var request = new GetUserRequest() { CibitId = cibitId };
            var userinfo = TypeMapper.Mapper.Map<GetUserRequest, UserDTO>(request);
            var spObj = Converters.GetUserConverter(userinfo);
            var reader = Controllers.UsersController._context.StoredProcedureSql("getUser", spObj);

            GetUserResponse response = new GetUserResponse();

            return response != null;
        }
    }
}
