using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiBitUtil.Message.Response;
using CiBitUtil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class BankConfirmUserModel : PageModel
    {

        [BindProperty]
        public GetUserConfirmResponse UserInfo { get; set; }

        public List<GetUserConfirmResponse> UserList { get; set; }

        public void OnGet()
        {
            UserList = new List<GetUserConfirmResponse>();
            UserList.Add(
                new GetUserConfirmResponse
                {
                    Date = new DateTime(2000,5,1),
                    CiBitId = "1",
                    Email = "a@a.com",
                    FullName = "a b",
                    University = "uni",
                    Status = "Panding"
                });
            UserList.Add(
                new GetUserConfirmResponse
                {
                    Date = new DateTime(1955, 10, 21),
                    CiBitId = "2",
                    Email = "b@a.com",
                    FullName = "b c",
                    University = "unic",
                    Status = "Panding"
                });
            UserList.Add(
                new GetUserConfirmResponse
                {
                    Date = new DateTime(2020, 12, 31),
                    CiBitId = "3",
                    Email = "c@a.com",
                    FullName = "c d",
                    University = "unid",
                    Status = "Panding"
                });
        }
    }
}