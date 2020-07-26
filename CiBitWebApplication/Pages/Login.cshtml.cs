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
    public class LoginModel : PageModel
    {
        private static IHttpClientFactory ClientFactory { get; set; }

        [BindProperty]
        public LoginRequest LoginRequest { get; set; }

        [BindProperty]
        public GetLoginResponse LoginResponse { get; set; }

        [BindProperty]
        public string ErrorMsg { get; set; }

        public LoginModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostProcessRequestAsync()
        {

            string pathName = @"Users/Login/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(LoginRequest), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if(httpResponse.IsSuccessStatusCode)
            {
                LoginResponse = await httpResponse.Content.ReadFromJsonAsync<GetLoginResponse>();
                if (string.IsNullOrWhiteSpace(LoginResponse.Token))
                    ErrorMsg = "Login Failed: CiBitId or Password is incorrect.";
                else if(LoginResponse.IsBank)
                {
                    return RedirectToPage("/BankConfirmUser", new { LoginResponse.Token, LoginRequest.CibitId });
                }
                else
                {
                    return RedirectToPage("/UserHome", new { LoginResponse.Token, LoginRequest.CibitId });
                }
            }
            else
            {
                ErrorMsg = "Server Login Failed.";
            }

            return RedirectToPage("/Login");
        }
    }
}