using Microsoft.EntityFrameworkCore;
using DbProdutos.Models;

namespace DbConnection.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<DbProduto> DbProdutos { get; set; }
  }
}
