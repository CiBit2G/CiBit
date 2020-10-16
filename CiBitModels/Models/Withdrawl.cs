namespace CiBitUtil.Models
{
    public class Withdrawl : Transaction
    {
        public string Reason { get; set; }

        public int Status { get; set; }

        public string FullName { get; set; }
    }
}
