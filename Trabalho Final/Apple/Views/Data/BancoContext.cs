using ControleDeIphone.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeIphones.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<IphoneModel> Iphones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IphoneModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Cor).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Preco).IsRequired().HasColumnType("decimal(18,2)");
            });
        }
    }
}
