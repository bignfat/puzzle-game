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

namespace PuzzleGame.Pages
{
    public class OpenCellModel : PageModel
    {
        private readonly PuzzleGame.Model.SqliteContext _context;

        public OpenCellModel(PuzzleGame.Model.SqliteContext context)
        {
            _context = context;
        }

        public Cell Cell { get; set; }

        [BindProperty]
        public string Answer { get; set; }

        [BindProperty]
        public string Code { get; set; }

        [BindProperty]
        public int Id { get; set; }

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
            Id = Id;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Cell = await _context.Cell.FirstOrDefaultAsync(m => m.Id == Id);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Cell.State == CellState.Closed)
            {
                if (string.IsNullOrEmpty(Answer) || !IsAnswerCorrect())
                {
                    ModelState.AddModelError("Answer", "Ответ неверный. Еще варианты?");
                    return Page();
                }

                Cell.Answer = Answer;
                Cell.State = Cell.Type == CellType.Target ? CellState.Quiz : CellState.Opened;
            }
            else
            {
                if (string.IsNullOrEmpty(Code) || !Code.Equals(Cell.Code, StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError("Code", "Код неверный.");
                    return Page();
                }

                Cell.State = CellState.Opened;
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

            return Page();
        }

        private bool IsAnswerCorrect()
        {
            var possibleAnswers = Cell.PossibleAnswer.Split("|");

            foreach (var possibleAnswer in possibleAnswers)
            {
                if (possibleAnswer.Trim().Equals(Answer, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private bool CellExists(int id)
        {
            return _context.Cell.Any(e => e.Id == id);
        }
    }
}
