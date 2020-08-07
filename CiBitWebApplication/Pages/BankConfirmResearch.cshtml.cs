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

namespace CiBitWebApplication.Pages
{
    public class BankConfirmResearchModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        [BindProperty]
        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public GetResearchConfirmResponse Research { get; set; }

        public GetAllResearchConfirmResponse ResearchList { get; set; }


        public async void OnGetAsync()
        {
            Loading = true;

            string pathName = @"Users/GetUser/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            GetResearchRequest request = new GetResearchRequest
            {
                Token = Token
            };

            var todoItemJson = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                ResearchList = await httpResponse.Content.ReadFromJsonAsync<GetAllResearchConfirmResponse>();
            }

            Loading = false;
        }
    }
}