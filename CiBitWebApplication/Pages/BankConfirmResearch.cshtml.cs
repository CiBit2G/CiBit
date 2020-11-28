using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CiBitUtil.Message.Request;
using Newtonsoft.Json;

namespace CiBitWebApplication.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class BankConfirmResearchModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        public string IsUser;

        [BindProperty]
        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public string JsonList { get; set; }

        [BindProperty]
        public GetResearchConfirmResponse Research { get; set; }

        public GetResearchConfirmListResponse ResearchList { get; set; }

        public BankConfirmResearchModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async void OnGetAsync()
        {
            Loading = true;

            string pathName = @"Research/GetAllResearchs/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            GetResearchRequest request = new GetResearchRequest()
            {
                Token = Token
            };

            var todoItemJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                ResearchList = await httpResponse.Content.ReadFromJsonAsync<GetResearchConfirmListResponse>();
            }


            var StatusList = new
            {
                status = ResearchList.ResearchConfirmList.Select(x => x.Status).ToList()
            };
            if (StatusList != null)
                JsonList = JsonConvert.SerializeObject(StatusList);

            //Token = ResearchList.Token;

            Loading = false;
        }

        public async Task<ActionResult> OnPostConfirm([FromBody] ConfirmResearchRequest json)
        {
            string pathName = @"Research/ConfirmResearch/";
            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(json), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                var ConfirmResponse = await httpResponse.Content.ReadFromJsonAsync<ConfirmResearchResponse>();

                if (ConfirmResponse.IsSuccessful)
                {
                    return new JsonResult(new { token = ConfirmResponse.Token });
                }
            }

            return new JsonResult(new { token = Token });
        }
    }
}