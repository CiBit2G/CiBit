using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiBitUtil.Message.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class BankConfirmResearchModel : PageModel
    {
        [BindProperty]
        public GetResearchConfirmResponse Research { get; set; }

        public List<GetResearchConfirmResponse> ResearchList { get; set; }

        public void OnGet()
        {
            ResearchList = new List<GetResearchConfirmResponse>();
            ResearchList.Add(new GetResearchConfirmResponse
            {
                CiBitId = "1",
                DateOfResearch = new DateTime(2010,1,10),
                ReseachName = "Things to do while you poo",
                Status = "Panding"
            });
            ResearchList.Add(new GetResearchConfirmResponse
            {
                CiBitId = "2",
                DateOfResearch = new DateTime(2011, 4, 10),
                ReseachName = "Things to do whionle the loo",
                Status = "Panding"
            });
            ResearchList.Add(new GetResearchConfirmResponse
            {
                CiBitId = "3",
                DateOfResearch = new DateTime(2020, 10, 6),
                ReseachName = "Things to do with Winnie the po",
                Status = "Panding"
            });
        }
    }
}