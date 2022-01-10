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
    public class IndexModel : PageModel
    {
        private readonly PuzzleGame.Model.SqliteContext _context;

        public IndexModel(PuzzleGame.Model.SqliteContext context)
        {
            _context = context;
        }

        public List<Cell> AllCells { get;set; }

        public async Task OnGetAsync()
        {
            AllCells = await _context.Cell.ToListAsync();
        }

        public async Task OnGetReset()
        {
            AllCells = await _context.Cell.ToListAsync();
            AllCells.ForEach(cell =>
            {
                cell.Answer = "";
                cell.State = CellState.Closed;
            });
            await _context.SaveChangesAsync();
        }
    }
}
