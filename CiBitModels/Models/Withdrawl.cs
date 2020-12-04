namespace CiBitUtil.Models
{
    public class Withdrawl : Transaction
    {
        public int WithdrawalId { get; set; }

        public int Status { get; set; }

        public string FullName { get; set; }
    }
}
