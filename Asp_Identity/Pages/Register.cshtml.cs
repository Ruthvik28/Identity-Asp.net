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
	public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> usermanager;
        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public Register RegModel { get; set; }


        public RegisterModel(UserManager<IdentityUser> usermanager, SignInManager<IdentityUser> signInManager)
        {
            this.usermanager = usermanager;
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = RegModel.Email,
                    Email = RegModel.Email
                };
               var result = await usermanager.CreateAsync(user, RegModel.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return Page();
            
            
        }
    }
}
