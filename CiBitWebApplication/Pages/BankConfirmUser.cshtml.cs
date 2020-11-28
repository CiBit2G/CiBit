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
using Newtonsoft.Json;

namespace CiBitWebApplication.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class BankConfirmUserModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public GetUserConfirmResponse UserInfo { get; set; }

        public GetAllUsersResponse UserList { get; set; }
        
        [BindProperty]
        public string JsonList { get; set; }

        [BindProperty]
        public bool Loading { get; set; }

        public BankConfirmUserModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }


        public async void OnGetAsync()
        {
            Loading = true;

            string pathName = @"Users/GetAllUsers/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            GetUserRequest request = new GetUserRequest
            {
                Token = Token
            };

            var todoItemJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                UserList = await httpResponse.Content.ReadFromJsonAsync<GetAllUsersResponse>();
            }

            if (UserList == null)
                return;

            var StatusList = new
            {
                status = UserList.Users.Select(x => x.Status).ToList()
            };
            if(StatusList != null)
                JsonList = JsonConvert.SerializeObject(StatusList);
            Loading = false;
        }

        [HttpPost]
        public async Task<ActionResult> OnPostConfirm([FromBody] ConfirmUserRequest json)
        {
            string pathName = @"Users/ConfirmUser/";
            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(System.Text.Json.JsonSerializer.Serialize(json), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                var ConfirmResponse = await httpResponse.Content.ReadFromJsonAsync<ConfirmUserResponse>();

                if (ConfirmResponse.IsSuccessful)
                {
                    return new JsonResult(new { token = ConfirmResponse.Token });
                }
            }

            return new JsonResult(new { token = Token });
        }
    }
}