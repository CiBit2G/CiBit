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
    public class UserResearchModel : PageModel
    {
        private readonly string InvalidValue = "Invalid Value!";

        private static IHttpClientFactory ClientFactory { get; set; }

        #region Error Messages

        [BindProperty]
        public string ErrorMsgRsch { get; set; }

        #endregion

        #region Properties

        public bool Loading { get; set; }

        [BindProperty]
        public string CiBitId { get; set; }

        [BindProperty]
        public string ResearchName { get; set; }

        [BindProperty]
        public string Abstract { get; set; }

        public CreateResearchRequest CreateResearch { get; private set; }

        #endregion

        public UserResearchModel(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public async Task OnPostProcessRequestAsync()
        {
            if (!CheckDetails())
                return;

            string pathName = @"Research/CreateResearch/";

            var _httpClient = ClientFactory.CreateClient("cibit");

            var todoItemJson = new StringContent(JsonSerializer.Serialize(CreateResearch), Encoding.UTF8, "application/json");

            var httpResponse =
                await _httpClient.PostAsync($"{pathName}", todoItemJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                var CreateResearchResponse = await httpResponse.Content.ReadFromJsonAsync<bool>();

                if (CreateResearchResponse)
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

            if (string.IsNullOrWhiteSpace(ResearchName))
            {
                IsValid = false;
                ErrorMsgRsch = InvalidValue;
            }
            
            CreateResearch = new CreateResearchRequest
            {
                CiBitId = CiBitId,
                ResearchName = ResearchName,
                Abstract = Abstract
            };

            return CreateResearch != null && IsValid;
        }
    }
}