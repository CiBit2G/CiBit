using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class UserResearchModel : PageModel
    {
        private readonly string InvalidValue = "Invalid Value!";

        private static IHttpClientFactory ClientFactory { get; set; }

        #region Error Messages

        [BindProperty]
        public string ErrorMsgRsch { get; set; }

        #endregion

        #region Properties

        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public string ResearchName { get; set; }

        [BindProperty]
        public string Abstract { get; set; }

        public CreateResearchRequest CreateResearch { get; private set; }

        #endregion

        public UserResearchModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async Task<IActionResult> OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                ErrorMsgRsch = "Research name is not valid";

            string pathName = @"Research/CreateResearch/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CreateResearch), Encoding.UTF8, "application/json");


            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                var ResearchResponse = await httpResponse.Content.ReadFromJsonAsync<CreateResearchResponse>();

                if (ResearchResponse.IsSuccessful)
                {
                    return RedirectToPage("/UserResearch", new { ResearchResponse.Token });
                }
            }
            else
            {
                ErrorMsgRsch = "Failed To Add Research";
            }
            return RedirectToPage("/UserResearch");
        }

        private bool CheckDetails()
        {
            bool IsValid = true;

            if (string.IsNullOrWhiteSpace(ResearchName))
            {
                IsValid = false;
                ErrorMsgRsch = InvalidValue;
            }
            
            CreateResearch = new CreateResearchRequest
            {
                ResearchName = ResearchName,
                Abstract = Abstract,
                Token = Token
            };

            return CreateResearch != null && IsValid;
        }
    }
}