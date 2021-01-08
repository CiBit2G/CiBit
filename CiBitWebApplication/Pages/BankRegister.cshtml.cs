using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CiBitUtil.Message.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class BankRegisterModel : PageModel
    {
        private readonly string InvalidValue = "Invalid Value!";

        private static IHttpClientFactory ClientFactory { get; set; }
        #region Error Messages

        [BindProperty]
        public string ErrorMsgCb { get; set; }
        [BindProperty]
        public string ErrorMsgPass { get; set; }
        [BindProperty]
        public string ErrorMsgCoPass { get; set; }
        [BindProperty]
        public string ErrorMsgUni { get; set; }

        public string ErrorMsg { get; set; }
        #endregion

        #region Properties

        [BindProperty]
        public string CiBitId { get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }
        
        [BindProperty]
        public string University { get; set; }
        
        public CreateBankRequest CreateUser { get; set; }

        public bool CreateBankResponse { get; set; }

        #endregion

        public BankRegisterModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                ErrorMsg = "Details are not valid";

            string pathName = @"Users/CreateBank/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CreateUser), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                CreateBankResponse = await httpResponse.Content.ReadFromJsonAsync<bool>();

                if (CreateBankResponse)
                {
                    //TODO Show Message success: wait for Bank confirmation.
                    return RedirectToPage("/RegisterComplete", new { Approval = "CiBit's" });
                }
            }
            else
            {
                ErrorMsg = "Faild To Register";
            }
            return RedirectToPage("/BankRegister");
        }

        private bool CheckDetails()
        {
            bool IsValid = true;

            if (string.IsNullOrWhiteSpace(CiBitId))
            {
                IsValid = false;
                ErrorMsgCb = InvalidValue;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                IsValid = false;
                ErrorMsgPass = InvalidValue;
            }

            if (!string.IsNullOrWhiteSpace(ConfirmPassword))
                if (!ConfirmPassword.Equals(Password))
                {
                    IsValid = false;
                    ErrorMsgCoPass = InvalidValue;
                }

            if (string.IsNullOrWhiteSpace(University))
            {
                IsValid = false;
                ErrorMsgUni = InvalidValue;
            }

            CreateUser = new CreateBankRequest
            {
                CiBitId = CiBitId,
                Password = Password,
                VerifyPassword = ConfirmPassword,
                UniName = University
            };

            return CreateUser != null && IsValid;
        }
    }
}