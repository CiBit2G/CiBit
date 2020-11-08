using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CiBitWebApplication.Pages
{
    public class UserNewTransactionModel : PageModel
    {
        private readonly string InvalidValue = "Invalid Value!";

        [BindProperty(SupportsGet = true)]
      

        #region Properties

        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public string ReceiverId { get; set; }

        [BindProperty]
        public string Research { get; set; }

        public int Amount { get; set; }

        public AddTransactionRequest NewTransaction{ get; set; }
        #endregion

        #region Error Messages

        [BindProperty]
        public string ErrorMsgRsch { get; set; }

        

        #endregion

        private static IHttpClientFactory ClientFactory { get; set; }

        public GetResearchListResponse ResearchList { get; set; }

        public List<SelectListItem> SelectList
        {
            get
            {
                var result = new List<SelectListItem>();
                var researchNameList = ResearchList.ResearchNamesList.Values.ToList();
                foreach (var item in researchNameList)
                {
                    result.Add(new SelectListItem(item, item));
                }
                return result;
            }
        }

        public UserNewTransactionModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        /*public async Task OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                return;

            string pathName = @"Research/CreateResearch/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CreateTransaction), Encoding.UTF8, "application/json");


            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                var CreateResearchResponse = await httpResponse.Content.ReadFromJsonAsync<bool>();

                if (CreateResearchResponse)
                {
                    //TODO Show Message success: wait for Bank confirmation.
                }
            }
            else
            {
            }
        }
        */

      private bool CheckDetails()
        {
            bool IsValid = true;

            if (string.IsNullOrWhiteSpace(ReceiverId))
            {
                IsValid = false;
                ErrorMsgRsch = InvalidValue;
            }

            NewTransaction = new AddTransactionRequest
            {
                Amount = Amount,
                ReceiverId = ReceiverId,
                ResearchId = "re"
            };

            return NewTransaction != null && IsValid;
        }
      
    }
}