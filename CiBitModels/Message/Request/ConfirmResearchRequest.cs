namespace CiBitUtil.Message.Request
{
    public class ConfirmResearchRequest: BaseWebRequest
    {
        public string CibitId { get; set; }

        public int Status { get; set; }

        public string researchName { get; set; }
    }
}
