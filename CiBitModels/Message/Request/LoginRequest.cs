using System.ComponentModel.DataAnnotations;

namespace CiBitUtil.Message.Request
{
    public class LoginRequest : GetUserRequest
    {
        [Required]
        public string Password { get; set; }
    }
}
