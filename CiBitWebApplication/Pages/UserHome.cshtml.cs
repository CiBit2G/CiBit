using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Models;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;

namespace CiBitWebApplication.Pages
{
    public class UserHomeModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CiBitId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty(SupportsGet = true)]
        public GetUserTransactionResponse Transaction { get; set; }

        [BindProperty]
        public GetUserResponse UserTransation { get; set; }

        public UserHomeModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public List<GetUserTransactionResponse> TransactionList { get; set; }

        public async void OnGetAsync()
        {
            string pathName = @"Users/GetUser/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CiBitId), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                UserTransation = await httpResponse.Content.ReadFromJsonAsync<GetUserResponse>();
            }
        }
    }
}