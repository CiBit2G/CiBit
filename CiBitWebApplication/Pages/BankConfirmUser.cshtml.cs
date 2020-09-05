using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class BankConfirmUserModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public GetUserConfirmResponse UserInfo { get; set; }

        public GetAllUsersResponse UserList { get; set; }

        [BindProperty]
        public bool Loading { get; set; }

        public BankConfirmUserModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async void OnGetAsync()
        {
            Loading = true;

            string pathName = @"Users/GetUser/";

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
                UserList = await httpResponse.Content.ReadFromJsonAsync<GetAllUsersResponse>();
            }

            Loading = false;
        }
    }
}