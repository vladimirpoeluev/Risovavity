using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataIntegration.Model;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canvas> Canvas { get; set; }

    public virtual DbSet<InteractiveCanvas> InteractiveCanvas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlServer("Data Source=NIGHSVOLK\\SQLEXPRESS;Initial Catalog=Risovaviti;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Canvas>(entity =>
        {
			entity.HasKey(u => u.Id);
			entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Canvas)
                .HasForeignKey(d => d.IdAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Canvas_User");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Canvas)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Canvas_Status");
        });

        modelBuilder.Entity<InteractiveCanvas>(entity =>
        {
			entity.HasKey(u => u.Id);
			entity.Property(e => e.ConnectionString).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.AuthorNavigation).WithMany(p => p.InteractiveCanvas)
                .HasForeignKey(d => d.Author)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InteractiveCanvas_User");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.InteractiveCanvas)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InteractiveCanvas_Status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
			entity.HasKey(u => u.Id);
			entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .HasMaxLength(50);

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
