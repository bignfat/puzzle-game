using Microsoft.EntityFrameworkCore;

namespace PuzzleGame.Model
{
    public class SqliteContext : DbContext
    {
        public DbSet<Cell>? Cell { get; set; }

        public SqliteContext(DbContextOptions<SqliteContext> options)
            : base(options)
        {
        }
    }
}
