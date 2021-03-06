﻿using System;
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
    public class UserRegistrationModel : PageModel
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

        public string ErrorMsg { get; set; }

        #endregion

        #region Properties

        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string MiddleName { get; set; }

        [BindProperty]
        public string Surname { get; set; }

        [BindProperty]
        public DateTime DOB { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string University { get; set; }

        [BindProperty]
        public string Article { get; set; }

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
         
        public UserRegistrationModel(IHttpClientFactory clientFactory)
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

        public async Task<IActionResult> OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                ErrorMsg = "Detailes are not valid";

            string pathName = @"Users/CreateUser/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CreateUser), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                CreateUserResponse = await httpResponse.Content.ReadFromJsonAsync<bool>();

                if(CreateUserResponse)
                {
                    return RedirectToPage("/RegisterComplete", new { Approval = "university's" });
                }
            }
            else
            {
                ErrorMsg = "Registeration Failed";
            }
            return RedirectToPage("/UserRegistration");
        }

        private bool CheckDetails()
        {
            bool IsValid = true;

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                IsValid = false;
                ErrorMsgFn = InvalidValue;
            }
        
            if (!string.IsNullOrWhiteSpace(MiddleName))
            {
                var passRegex = new Regex(@"^[a-zA-Z]{2,50}$");

                if (!passRegex.Match(MiddleName).Success)
                {
                    IsValid = false;
                    ErrorMsgMn = InvalidValue;
                }
            }

            if (string.IsNullOrWhiteSpace(Surname))
            {
                IsValid = false;
                ErrorMsgSn = InvalidValue;
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

            if (string.IsNullOrWhiteSpace(Article))
            {
                IsValid = false;
                ErrorMsgArt = InvalidValue;
            }

            if (DOB.CompareTo(DateTime.Now) >= 0)
            {
                IsValid = false;
                ErrorMsgFn = InvalidValue;
            }

            CreateUser = new CreateUserRequest
            {
                FName = FirstName + " " + MiddleName,
                LName = Surname,
                Email = Email,
                DOB = DOB,
                Password = Password,
                VerifyPassword = ConfirmPassword,
                University = University,
                ArticleName = Article
            };

            return CreateUser != null && IsValid;
        }
    }
}