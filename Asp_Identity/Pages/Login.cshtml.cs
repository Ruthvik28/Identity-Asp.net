using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp_Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Identity.Pages
{
	public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LogModel { get; set; }

        private readonly SignInManager<IdentityUser> signInManager;

        public void OnGet()
        {
        }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result= await signInManager.PasswordSignInAsync(LogModel.Email, LogModel.Password,false,false);
                if (result.Succeeded)
                {
                   
                        return RedirectToPage("Index");
                
                    
                    
                }
                ModelState.AddModelError("", "Incorrect Email or Password");
            }
            return Page();
        }

       
    }
}
