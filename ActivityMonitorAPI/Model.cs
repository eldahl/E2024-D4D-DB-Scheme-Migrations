using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ActivityMonitorAPI;


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class ActivityDBContext : DbContext
{
    public string DbPath { get; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityDuration> ActivityCategories { get; set; }
    
    public ActivityDBContext(DbContextOptions<ActivityDBContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(p => p.id);
            entity.Property(p => p.nameActivity);
            entity.Property(p => p.activityDescription);
        });
        modelBuilder.Entity<ActivityDuration>(entity =>
        {
            entity.HasKey(p => p.id);
            entity.Property(p => p.activityId);
            entity.Property(p => p.durationTime);
            entity.Property(p => p.startTime);
        });
        
        modelBuilder.Entity<ActivityCategory>(entity =>
        {
            entity.HasKey(p => p.catName);
        });
        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(p => p.id);
            entity.Property(p => p.userName);
            entity.Property(p => p.email);
        });
    }
}

public partial class Activity
{
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id{ get; set; }
    
    [Required]
    [Column(TypeName = "varchar(25)")]
    public string nameActivity{ get; set; }
    
    [Required]
    [Column(TypeName = "varchar(200)")]
    public string activityDescription{ get; set; }
    }

public partial class ActivityCategory
{
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string catName{ get; set; }
    }

public partial class ActivityDuration
{
    
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id{ get; set; }
    
    [Required]
    public int activityId{ get; set; }
    
    [Required]
    public DateTime startTime{ get; set; }
    
    public TimeSpan durationTime { get; set; }
}

public partial class Users
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string userName { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string email { get; set; }
}
