using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PuzzleGame.Model;

namespace PuzzleGame.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly SqliteContext _context;

    public Cell[,] Cells { get; set; }

    public int TasksPassed { get; set; }
    public int TasksLeft { get; set; }

    public IndexModel(ILogger<IndexModel> logger, SqliteContext context)
    {
        _logger = logger;
        _context = context;
    }

    public void OnGet()
    {
        var allCells = _context.Cell.ToList();
        Cells = new Cell[6,6];

        foreach (var cell in allCells)
            Cells[cell.Row-1, cell.Column-1] = cell;

        TasksPassed = allCells.Count(cell => cell.Type == CellType.Target && cell.State == CellState.Opened);
        TasksLeft = allCells.Count(cell => cell.Type == CellType.Target && cell.State != CellState.Opened);
    }
}
