using Microsoft.EntityFrameworkCore;

namespace sqlwpfkurwamac;

public partial class AlbertoDbContext : DbContext
{
    public AlbertoDbContext()
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<AlbertoUser> AlbertoUsers { get; set; }
    public DbSet<AlbertoZakup> AlbertoZakupy { get; set; }
    public DbSet<AlbertoSong> AlbertoSongs { get; set; }
   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=tcp:musicplayer-db.database.windows.net,1433;Initial Catalog=alberto-db;Persist Security Info=False;User ID=alberto;Password=Admin1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

 
}