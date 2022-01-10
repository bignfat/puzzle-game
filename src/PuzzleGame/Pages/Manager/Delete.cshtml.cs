#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PuzzleGame.Model;

namespace PuzzleGame.Pages.Manager
{
    public class DeleteModel : PageModel
    {
        private readonly PuzzleGame.Model.SqliteContext _context;

        public DeleteModel(PuzzleGame.Model.SqliteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cell Cell { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cell = await _context.Cell.FirstOrDefaultAsync(m => m.Id == id);

            if (Cell == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cell = await _context.Cell.FindAsync(id);

            if (Cell != null)
            {
                _context.Cell.Remove(Cell);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
