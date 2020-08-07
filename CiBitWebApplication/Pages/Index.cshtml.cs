using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
        
        public IActionResult OnPostUser()
        {
            return RedirectToPage("/login", new { Identity = "user" });
        }

        public IActionResult OnPostBank()
        {

            return RedirectToPage("/login",new { Identity = "bank" });
        }
    }
}
