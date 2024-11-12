using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Personal> DncPersonal { get; set; }

    public DbSet<RoleList> DncRoleList { get; set; }

    public DbSet<Product> DncProduct { get; set; }

    public DbSet<ProductDtl> DncProductDtl { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personal>()
            .HasIndex(p => p.Username)
            .IsUnique(); // ตั้งค่าให้ Username เป็น unique


        modelBuilder.Entity<RoleList>()
            .HasIndex(p => p.RoleName)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.MatirialCode)
            .IsUnique();

        modelBuilder.Entity<ProductDtl>()
            .HasIndex(p => p.MatCode)
            .IsUnique();
        
        
    }
}
