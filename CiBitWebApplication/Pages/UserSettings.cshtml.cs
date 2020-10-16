using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CiBitUtil.Message.Request;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CiBitWebApplication.Pages
{
    public class UserSettingsModel : PageModel
    {
        private readonly string InvalidValue = "Invalid Value!";

        private static IHttpClientFactory ClientFactory { get; set; }

        #region Error Messages

        [BindProperty]
        public string ErrorMsgFn { get; set; }
        [BindProperty]
        public string ErrorMsgMn { get; set; }
        [BindProperty]
        public string ErrorMsgSn { get; set; }
        [BindProperty]
        public string ErrorMsgDob { get; set; }
        [BindProperty]
        public string ErrorMsgPass { get; set; }
        [BindProperty]
        public string ErrorMsgCoPass { get; set; }
        [BindProperty]
        public string ErrorMsgEm { get; set; }
        [BindProperty]
        public string ErrorMsgUni { get; set; }
        [BindProperty]
        public string ErrorMsgArt { get; set; }

        #endregion

        #region Properties

        public bool Loading { get; set; }
        
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string University { get; set; }
        
        public CreateUserRequest CreateUser { get; set; }

        public bool CreateUserResponse { get; set; }

        [BindProperty(SupportsGet = true)]
        public GetBankNamesResponse UniversitiesList { get; set; }

        public List<SelectListItem> SelectList
        {
            get
            {
                var result = new List<SelectListItem>();
                foreach (var item in UniversitiesList.Universities)
                {
                    result.Add(new SelectListItem(item, item));
                }
                return result;
            }
        }
        #endregion

        public UserSettingsModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async void OnGetAsync()
        {
            Loading = true;

            string pathName = @"Users/GetBankName/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var httpResponse =
                await _httpClient.GetAsync($"{pathName}");

            if (httpResponse.IsSuccessStatusCode)
            {
                UniversitiesList = await httpResponse.Content.ReadFromJsonAsync<GetBankNamesResponse>();
            }
            else
            {
                UniversitiesList = new GetBankNamesResponse();
                UniversitiesList.Universities = new List<string>();
            }

            Loading = false;
        }

        public async Task OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                return;

            string pathName = @"Users/CreateUser/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CreateUser), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                CreateUserResponse = await httpResponse.Content.ReadFromJsonAsync<bool>();

                if (CreateUserResponse)
                {
                    //TODO Show Message success: wait for Bank confirmation.
                }
            }
            else
            {
            }
        }

        private bool CheckDetails()
        {
            bool IsValid = true;
            
            if (string.IsNullOrWhiteSpace(Email))
            {
                IsValid = false;
                ErrorMsgEm = InvalidValue;
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
            
            CreateUser = new CreateUserRequest
            {
                Password = Password,
                VerifyPassword = ConfirmPassword,
                Email = Email,
                University = University
            };

            return CreateUser != null && IsValid;
        }
    }
}