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
        
        public IActionResult OnPostLogin()
        {
            return RedirectToPage("/login");
        }

        public IActionResult OnPostRegister()
        {

            return RedirectToPage("/UserRegistration");
        }
    }
}
