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
    public class DetailsModel : PageModel
    {
        private readonly PuzzleGame.Model.SqliteContext _context;

        public DetailsModel(PuzzleGame.Model.SqliteContext context)
        {
            _context = context;
        }

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
    }
}
