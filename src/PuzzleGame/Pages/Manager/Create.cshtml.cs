﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PuzzleGame.Model;

namespace PuzzleGame.Pages.Manager
{
    public class CreateModel : PageModel
    {
        private readonly PuzzleGame.Model.SqliteContext _context;

        public CreateModel(PuzzleGame.Model.SqliteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cell Cell { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cell.Add(Cell);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
