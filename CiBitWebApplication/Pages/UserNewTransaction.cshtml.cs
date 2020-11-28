using System.Collections.Generic;
using System;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace CiBitWebApplication.Pages
{
    public class UserNewTransactionModel : PageModel
    {
        private readonly string InvalidValue = "Invalid Value!";


        #region Properties

        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TransactionType { get; set; }

        [BindProperty(SupportsGet = true)]

        public string Research { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Amount { get; set; }


        public NewTransactionRequest NewTransaction{ get; set; }

        private static IHttpClientFactory ClientFactory { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetResearchListResponse ResearchList { get; set; }
        [BindProperty(SupportsGet = true)]
        public GetUserListResponse UserList { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<SelectListItem> ResearchSelectList
        {
            get
            {
                var result = new List<SelectListItem>();
                if (ResearchList == null)
                    return result;
                var researchNameList = ResearchList.ResearchNamesList.Values.ToList();
                foreach (var item in researchNameList)
                {
                    result.Add(new SelectListItem(item, item));
                }
                return result;
            }
        }

        [BindProperty(SupportsGet = true)]
        public List<SelectListItem> UserSelectList
        {
            get
            {
                var result = new List<SelectListItem>();
                if (UserList == null)
                    return result;
                var userNameList = UserList.UserNamesList.Values.ToList();
                foreach (var item in userNameList)
                {
                    result.Add(new SelectListItem(item, item));
                }
                return result;
            }
        }
        [BindProperty(SupportsGet = true)]
        public List<string> UrlList { get; set; }
        [BindProperty]
        public string JsonBaseWebRequest
        {
            get
            {
                return JsonSerializer.Serialize(new BaseWebRequest { Token = Token });
            }
        }
        #endregion

        #region Error Messages

        [BindProperty]
        public string ErrorMsgTransaction { get; set; }


        #endregion

        public UserNewTransactionModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
            UrlList = new List<string>
            {
                {"https://localhost:5001/Users/GetUserList"},
                {"https://localhost:5001/Users/GetUserBank" },
                {"https://localhost:5001/Research/GetUserList"}
            };
        }

        public async Task<JsonResult> OnGetUserBank(string token)
        {
            string pathName = @"Users/GetUserBank/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(new BaseWebRequest { Token = token}), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                UserList = await httpResponse.Content.ReadFromJsonAsync<GetUserListResponse>();
            }
            else
            {
            }
            var JsonList = new
            {
                IdList = UserList.UserNamesList.Keys.ToList(),
                NameList = UserList.UserNamesList.Values.ToList(),
                tokenGet = UserList.Token
            };
            return new JsonResult(JsonList);
        }

        public async Task<JsonResult> OnGetUsersList()
        {
            string pathName = @"Users/GetUserList/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(new BaseWebRequest { Token = Token }), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                UserList = await httpResponse.Content.ReadFromJsonAsync<GetUserListResponse>();
            }
            else
            {
            }
            var JsonList = new
            {
                IdList = UserList.UserNamesList.Keys.ToList(),
                NameList = UserList.UserNamesList.Values.ToList(),
                tokenGet = UserList.Token
            };
            return new JsonResult(JsonList);

        }

        public async Task<JsonResult> OnGetResearchList(string token, string id)
        {
            string pathName = @"Research/GetAllUserResearchs/";

            var _httpClient = ClientFactory.CreateClient("cibit");


            var request = new GetResearchListRequest
            {
                Token = Token,
                CibitId = id
            };

            var todoItemJson = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                ResearchList = await httpResponse.Content.ReadFromJsonAsync<GetResearchListResponse>();
            }
            else
            {
            }
            var JsonList = new
            {
                IdList = ResearchList.ResearchNamesList.Keys.ToList(),
                NameList = ResearchList.ResearchNamesList.Values.ToList(),
                tokenGet = ResearchList.Token
            };
            return new JsonResult(JsonList);
        }

        public async Task<IActionResult> OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                ErrorMsgTransaction = "Transaction Detailes are wrong.";

            string pathName = (TransactionType == 1) ? @"Transaction/NewTransaction/" : @"Transaction/NewWithdrawal/";
            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(NewTransaction), Encoding.UTF8, "application/json");


            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                var TransactionResponse = await httpResponse.Content.ReadFromJsonAsync<NewTransactionResponse>();

                if (TransactionResponse.IsSuccessful)
                {
                    return RedirectToPage("/UserNewTransaction", new { TransactionResponse.Token });
                }
            }
            else
            {
                ErrorMsgTransaction = "Failed To Add Transaction";
            }
            return RedirectToPage("/UserNewTransaction");
        }
        

      private bool CheckDetails()
        {
            bool IsValid = true;
            if(TransactionType == 1)
            { 
                if (string.IsNullOrWhiteSpace(Research) && string.IsNullOrWhiteSpace(UserId))
                {
                    IsValid = false;
                    ErrorMsgTransaction = InvalidValue;
                }
                NewTransaction = new NewTransactionRequest
                {
                    Amount = Amount,
                    ReceiverId = UserId,
                    ResearchId = Research,
                    Token = Token
                };

                return NewTransaction != null && IsValid;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(UserId))
                {
                    IsValid = false;
                    ErrorMsgTransaction = InvalidValue;
                }
                NewTransaction = new NewTransactionRequest
                {
                    Amount = Amount,
                    ReceiverId = UserId,
                    Token = Token
                };

                return NewTransaction != null && IsValid;
            }
        }
    }
}