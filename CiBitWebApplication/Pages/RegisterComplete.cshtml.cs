using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CiBitWebApplication.Pages
{
    public class RegisterCompleteModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string Approval { get; set; }

        public void OnGet()
        {
        }
    }
}
