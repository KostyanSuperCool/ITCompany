using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ITCompany.NewFolder;

public partial class ItcompanyKiselevContext : DbContext
{
    public ItcompanyKiselevContext()
    {
    }

    public ItcompanyKiselevContext(DbContextOptions<ItcompanyKiselevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignmentToProject> AssignmentToProjects { get; set; }

    public virtual DbSet<Executor> Executors { get; set; }

    public virtual DbSet<Fulproject> Fulprojects { get; set; }

    public virtual DbSet<Priorite> Priorites { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleProject> RoleProjects { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ITCompanyKiselev;Username = postgres;Password = 1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentToProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assignment_to_projects_pkey");

            entity.ToTable("assignment_to_projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdExecutors).HasColumnName("id_executors");
            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.IdRoleProject).HasColumnName("id_role_project");

            entity.HasOne(d => d.IdExecutorsNavigation).WithMany(p => p.AssignmentToProjects)
                .HasForeignKey(d => d.IdExecutors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assignment_to_projects_id_executors_fkey");

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.AssignmentToProjects)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assignment_to_projects_id_project_fkey");

            entity.HasOne(d => d.IdRoleProjectNavigation).WithMany(p => p.AssignmentToProjects)
                .HasForeignKey(d => d.IdRoleProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("assignment_to_projects_id_role_project_fkey");
        });

        modelBuilder.Entity<Executor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("executors_pkey");

            entity.ToTable("executors");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameExecutor).HasColumnName("name_executor");
        });

        modelBuilder.Entity<Fulproject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("fulprojects_pkey");

            entity.ToTable("fulprojects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataFirst).HasColumnName("data_first");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdProject).HasColumnName("id_project");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.ManagerProject).HasColumnName("manager_project");

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.Fulprojects)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fulprojects_id_project_fkey");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Fulprojects)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fulprojects_id_status_fkey");
        });

        modelBuilder.Entity<Priorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("priorites_pkey");

            entity.ToTable("priorites");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PrioritetName).HasColumnName("prioritet_name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProjectName).HasColumnName("project_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<RoleProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_project_pkey");

            entity.ToTable("role_project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameProject).HasColumnName("name_project");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tasks_pkey");

            entity.ToTable("tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateExecution).HasColumnName("date_execution");
            entity.Property(e => e.IdFullProject).HasColumnName("id_full_project");
            entity.Property(e => e.IdProjectName).HasColumnName("id_project_name");
            entity.Property(e => e.NameTasks).HasColumnName("name_tasks");

            entity.HasOne(d => d.IdFullProjectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdFullProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_id_full_project_fkey");

            entity.HasOne(d => d.IdProjectNameNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.IdProjectName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tasks_id_project_name_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdExecutors).HasColumnName("id_executors");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.UserName).HasColumnName("user_name");

            entity.HasOne(d => d.IdExecutorsNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdExecutors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_executors_fkey");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
