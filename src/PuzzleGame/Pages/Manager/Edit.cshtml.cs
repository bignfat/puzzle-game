#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PuzzleGame.Model;

namespace PuzzleGame.Pages.Manager
{
    public class EditModel : PageModel
    {
        private readonly PuzzleGame.Model.SqliteContext _context;

        public EditModel(PuzzleGame.Model.SqliteContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CellExists(Cell.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CellExists(int id)
        {
            return _context.Cell.Any(e => e.Id == id);
        }
    }
}
