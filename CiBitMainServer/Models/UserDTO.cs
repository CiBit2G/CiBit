using System;

namespace CiBitMainServer.Models
{
    public class UserDTO
    {
        public string CibitId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string University { get; set; }
        public string ArticleName { get; set; }
        public int CitationCount { get; set; }
    }
}
