using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using volunteer.Models;

namespace volunteer.Data;

public partial class VolunteerContext : IdentityDbContext
{
    public VolunteerContext()
    {
    }

    public VolunteerContext(DbContextOptions<VolunteerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aprovedpost> Aprovedposts { get; set; }

    public virtual DbSet<CommentPost> CommentPosts { get; set; }

    public virtual DbSet<Pendingpost> Pendingposts { get; set; }

    public virtual DbSet<PostLike> PostLikes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-9SUHA30\\MSSQLSERVER01;Initial Catalog=Volunteer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {




        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });


        modelBuilder.Entity<Aprovedpost>(entity =>
        {
            entity.Property(e => e.ApprovedPostId).ValueGeneratedNever();
            entity.Property(e => e.Approvedby).IsFixedLength();
            entity.Property(e => e.Postdescribtion).IsFixedLength();
            entity.Property(e => e.Postname).IsFixedLength();
        });

        modelBuilder.Entity<CommentPost>(entity =>
        {
            entity.Property(e => e.PostCommentId).ValueGeneratedNever();
            entity.Property(e => e.CommentDescribt).IsFixedLength();
            entity.Property(e => e.Commentby).IsFixedLength();

            entity.HasOne(d => d.ApprovedPost).WithMany(p => p.CommentPosts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("relation1");
        });

        modelBuilder.Entity<Pendingpost>(entity =>
        {
            entity.Property(e => e.PendingpostId).ValueGeneratedNever();
            entity.Property(e => e.PostName).IsFixedLength();
            entity.Property(e => e.Postdescribtion).IsFixedLength();
            entity.Property(e => e.UserName).IsFixedLength();
        });

        modelBuilder.Entity<PostLike>(entity =>
        {
            entity.Property(e => e.LikepostId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  

}
