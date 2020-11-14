using System.Collections.Generic;
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

        [BindProperty(SupportsGet = true)]
      

        #region Properties

        public bool Loading { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Token { get; set; }

        [BindProperty]
        public string ReceiverId { get; set; }

        [BindProperty]
        public bool TransactionType { get; set; }

        [BindProperty]
        public string Research { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public int ResearchId
        {
            get
            {
                return int.Parse(ResearchList.ResearchNamesList.FirstOrDefault(x => x.Value.Equals(Research)).Key);
           }
        }

        public int Amount { get; set; }

        public AddTransactionRequest NewTransaction{ get; set; }

        private static IHttpClientFactory ClientFactory { get; set; }

        public GetResearchListResponse ResearchList { get; set; }

        public GetUserListResponse UserList { get; set; }

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
        public string ErrorMsgRsch { get; set; }

        

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

            return new JsonResult(UserList.UserNamesList.Values.ToList());
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
            return new JsonResult(UserList.UserNamesList.Values.ToList());

        }

        public async Task<JsonResult> OnGetList()
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

            return new JsonResult(UserList?.UserNamesList);
        }


        public async Task<JsonResult> OnGetResearchList(string token, string id, string list)
        {
            string pathName = @"Research/GetAllUserResearchs/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var userDict = JsonSerializer.Deserialize<Dictionary<string, string>>(list);

            var request = new GetResearchListRequest
            {
                Token = Token,
                CibitId = userDict.FirstOrDefault(x => x.Value.Equals(id)).Key
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

            return ResearchList == null ? null : new JsonResult(ResearchList.ResearchNamesList.Values.ToList());
        }

        public async Task OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                return;

            string pathName = @"Transaction/NewTransaction/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(NewTransaction), Encoding.UTF8, "application/json");


            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                var TransactionResponse = await httpResponse.Content.ReadFromJsonAsync<bool>();

                if (TransactionResponse)
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

            if (string.IsNullOrWhiteSpace(ReceiverId) && ResearchId < 0)
            {
                IsValid = false;
                ErrorMsgRsch = InvalidValue;
            }

            NewTransaction = new AddTransactionRequest
            {
                Amount = Amount,
                ReceiverId = ReceiverId,
                ResearchId = ResearchId,
                Token = Token
            };

            return NewTransaction != null && IsValid;
        }
      
    }
}