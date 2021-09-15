using AdvancedProgramming_Lesson4.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AdvancedProgramming_Lesson4.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;

        }

        public IList<IdentityUser> UserList { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var authenticated = this.User.Identity.IsAuthenticated;
            var email = this.User.Identity.Name;

            if(authenticated && email == "admin@email.com")
            {
                UserList = await _context.Users.ToListAsync();

                return Page();
            }

            return RedirectToPage("/PageNotFound");
  
        }
    }
}
