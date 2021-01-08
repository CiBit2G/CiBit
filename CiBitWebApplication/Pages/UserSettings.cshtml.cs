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

        private List<string> AvatarList;

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
        public string ErrorMsgPicture { get; set; }
        [BindProperty]
        public string ErrorMsgCoPass { get; set; }
        [BindProperty]
        public string ErrorMsgEm { get; set; }
        [BindProperty]
        public string ErrorMsgUni { get; set; }
        [BindProperty]
        public string ErrorMsgArt { get; set; }

        public string ErrorMsgSettings { get; set; }

        #endregion

        #region Properties

        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }
        [BindProperty]
        public string PicturePath { get; set; }
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string University { get; set; }
        
        public UserSettingsRequest CreateUser { get; set; }

        public UserSettingsResponse CreateUserResponse { get; set; }

        [BindProperty(SupportsGet = true)]
        public GetBankNamesResponse UniversitiesList { get; set; }

        public GetUserSettingsResponse UserSettings { get; set; }

        public List<SelectListItem> SelectUniversitiesList
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
            AvatarList = new List<string>();
            AvatarList.Add("man1.jpg");
            AvatarList.Add("man2.jpg");
            AvatarList.Add("man3.jpg");
            AvatarList.Add("man4.jpg");
            AvatarList.Add("woman1.jpg");
            AvatarList.Add("woman2.jpg");
            AvatarList.Add("woman3.jpg");
            AvatarList.Add("woman4.jpg");
            AvatarList.Add("woman5.jpg");
            AvatarList.Add("woman6.jpg");
        }

        public async Task<JsonResult> OnGetUserSettings(string token)
        {
            string pathName = @"Users/GetUserSettings/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(new BaseWebRequest { Token = token }), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                UserSettings = await httpResponse.Content.ReadFromJsonAsync<GetUserSettingsResponse>();
            }
            else
            {
            }
            var JsonList = new
            {
                email = UserSettings.Email,
                university = UserSettings.University,
                tokenGet = UserSettings.Token
            };
            return new JsonResult(JsonList);

        }

        public JsonResult OnGetAvatarImages(string img, int next)
        {
            var pic = img.Split('/');
            var index = AvatarList.IndexOf(pic[pic.Length-1]);
            if (next == 0)
                index = (index - 3) % AvatarList.Count;
            else
                index = (index + 3) % AvatarList.Count;

            var JsonList = new
            {
                left = AvatarList[index],
                mid = AvatarList[(index + 1) % AvatarList.Count],
                right = AvatarList[(index + 2) % AvatarList.Count]
            };
            return new JsonResult(JsonList);
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

        public async Task<IActionResult> OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                ErrorMsgSettings = "Wrong Settings";

            string pathName = @"Users/ChangeSettings/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CreateUser), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                CreateUserResponse = await httpResponse.Content.ReadFromJsonAsync<UserSettingsResponse>();

                if (CreateUserResponse.IsSuccessful)
                {
                    return RedirectToPage("/UserSettings", new {CreateUserResponse.Token });
                }
            }
            else
            {
                ErrorMsgSettings = "Couldn't change Settings";

            }
            return RedirectToPage("/UserSettings");
        }

        private bool CheckDetails()
        {
            bool IsValid = true;
            
            if(string.IsNullOrEmpty(PicturePath))
            {
                IsValid = false;
                ErrorMsgPicture = InvalidValue;
            }
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
            { 
                if (!ConfirmPassword.Equals(Password))
                {
                    IsValid = false;
                    ErrorMsgCoPass = InvalidValue;
                }
            }

            if (string.IsNullOrWhiteSpace(University))
            {
                IsValid = false;
                ErrorMsgUni = InvalidValue;
            }
            
            CreateUser = new UserSettingsRequest
            {
                Picture = PicturePath,
                Password = Password,
                VerifyPassword = ConfirmPassword,
                Email = Email,
                University = University
            };

            return CreateUser != null && IsValid;
        }
    }
}