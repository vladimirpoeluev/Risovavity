using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataIntegration.Model;

public partial class DatabaseContext : DbContext, IDataBaseModel
{
    string ConnectionSting { get; set; } = "Host=localhost;Port=5000;Database=risovavity;Username=postgres;Password=password";
    public DatabaseContext(string connectionString)
    {
        ConnectionSting = connectionString;
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) {
    }

    public virtual DbSet<LikeOfCanvas> LikeOfCanvas { get; set; }
    public virtual DbSet<Canvas> Canvas { get; set; }

    public virtual DbSet<InteractiveCanvas> InteractiveCanvas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VersionProject> VersionsProjects { get; set; }
    public virtual DbSet<LikeOfVersionProject> LikeOfVersionProjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		optionsBuilder.UseNpgsql(ConnectionSting);
		//optionsBuilder.UseSqlServer("Data Source=NIGHSVOLK\\SQLEXPRESS;Initial Catalog=Risovaviti;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VersionProject>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(256);

            entity.HasOne(e => e.ParentOfVersion)
            .WithMany(e => e.DescendantsVersionProject)
            .HasForeignKey(e => e.ParentOfVersionId)
			.OnDelete(DeleteBehavior.Restrict)
			.HasConstraintName("FK_VersionProject_VersionProject");

            entity.HasOne(e => e.AuthorOfVersion)
                .WithMany(e => e.VersionsProjects)
                .HasForeignKey(e => e.AuthorOfVersionId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_VersionProject_User");
        });
        modelBuilder.Entity<Canvas>(entity =>
        {
			entity.HasKey(u => u.Id);
			entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Canvas)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Canvas_User");

            entity.HasOne(d => d.Status).WithMany(p => p.Canvas)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Canvas_Status");

            entity.HasOne(d => d.MainVersion)
                .WithOne(d => d.Canvas)
				.HasForeignKey<Canvas>(d => d.MainVersionId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_Canvas_VersionProject");
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
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.UseTwoFactorAuthentication);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<LikeOfCanvas>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.CanvasId });

            entity.HasOne(e => e.User)
            .WithMany(e => e.LikeOfCanvas)
            .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.Canvas)
            .WithMany(e => e.LikeOfCanvas)
            .HasForeignKey(e => e.CanvasId);
        });

        modelBuilder.Entity<LikeOfVersionProject>(entity =>
        {
            entity.HasKey(e => new {e.VersionProjectId, e.UserId});

            entity.HasOne(e => e.User)
            .WithMany(e => e.LikeOfVersionProject)
            .HasForeignKey(e => e.UserId);

            entity.HasOne(e => e.VersionProject)
            .WithMany(e => e.LikeOfVersions)
            .HasForeignKey(e => e.VersionProjectId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
