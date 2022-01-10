namespace PuzzleGame.Model
{
    public class Cell
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public CellState State { get; set; }
        public CellType Type { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public string? PossibleAnswer { get; set; }
        public string? Code { get; set; }
        public string? Map { get; set; }
    }
}
