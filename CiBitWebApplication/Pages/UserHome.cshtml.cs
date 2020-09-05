using Microsoft.AspNetCore.Mvc;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using CiBitUtil.Message.Request;

namespace CiBitWebApplication.Pages
{
    public class UserHomeModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty(SupportsGet = true)]
        public GetUserTransactionResponse Transaction { get; set; }

        [BindProperty]
        public GetUserResponse UserTransation { get; set; } = null;

        [BindProperty]
        public string FullName
        {
            get
            {
                if (UserTransation == null)
                    return "";
                return UserTransation.user.FName + " " + UserTransation.user.LName;
            }
        }

        [BindProperty]
        public bool Loading { get; set; }

        public UserHomeModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async void OnGetAsync()
        {
            Loading = true;

            string pathName = @"Users/GetUser/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            BaseWebRequest request = new BaseWebRequest
            {
                Token = Token
            };

            var todoItemJson = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                UserTransation = await httpResponse.Content.ReadFromJsonAsync<GetUserResponse>();
            }

            Loading = false;
        }
    }
}