using AdvancedProgramming_Lesson4.Data;
using AdvancedProgramming_Lesson4.Hubs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvancedProgramming_Lesson4.Pages.History
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ChatMessage> Messages { get;set; }

        public async Task OnGetAsync()
        {
            Messages = await _context.ChatMessage.ToListAsync();
        }
    }
}
