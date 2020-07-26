using System;

namespace CiBitUtil.Message.Response
{
    public class GetUserConfirmResponse
    {
        public DateTime Date { get; set; }
        public string CiBitId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string University { get; set; }
        public string Status { get; set; }
    }
}
