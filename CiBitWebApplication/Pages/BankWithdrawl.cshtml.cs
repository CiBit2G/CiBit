using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using CiBitUtil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class BankWithdrawlModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public Withdrawl WithdrawlInfo { get; set; }

        public GetWithdrawlTransactionsReponse WithdrawlTransactionsList { get; set; }

        [BindProperty]
        public bool Loading { get; set; }

        public BankWithdrawlModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async void OnGetAsync()
        {
            Loading = true;

            string pathName = @"Transaction/GetWithdrawlTransactions/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            GetUserRequest request = new GetUserRequest
            {
                Token = Token
            };

            var todoItemJson = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                WithdrawlTransactionsList = await httpResponse.Content.ReadFromJsonAsync<GetWithdrawlTransactionsReponse>();
            }

            Loading = false;
        }

    }
}