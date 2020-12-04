namespace CiBitUtil.Models
{
    public class User
    {
        public string CibitId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string University { get; set; }
        public int? CitationAmount { get; set; }

        public string Picture { get; set; }

        public int Balance { get; set; }
    }
}
