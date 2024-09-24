using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ActivityMonitorAPI;

public class ActivityDBContext : DbContext
{
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
            entity.Property(p => p.categoryName);
            
            entity.HasOne(e => e.activityCategory)
                .WithOne(e => e.activity)
                .HasForeignKey<Activity>(a => a.categoryName)
                .HasConstraintName("FK_activityCategory");
        });
        modelBuilder.Entity<ActivityDuration>(entity =>
        { 
            entity.HasKey(p => p.id);
            entity.Property(p => p.activityId);
            entity.Property(p => p.durationTime);
            entity.Property(p => p.startTime);
            
            entity.HasOne(p => p.activity)
                .WithOne(e => e.activityDuration)
                .HasForeignKey<ActivityDuration>(p => p.activityId)
                .HasConstraintName("FK_ActivityDuration_Activity");
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

        modelBuilder.Entity<ActivityCategory>().HasData(new List<ActivityCategory>()
        {
            new ActivityCategory()
            {
                catName = "Work"
            },
            new ActivityCategory()
            {
                catName = "Leisure"
            },
            new ActivityCategory()
            {
                catName = "Research"
            },
            new ActivityCategory()
            {
                catName = "Afk"
            },
            new ActivityCategory()
            {
                catName = "Meeting"
            },
            new ActivityCategory()
            {
                catName = "Gaming"
            }
        });

        modelBuilder.Entity<Activity>().HasData(new List<Activity>()
        {
            new Activity()
            {   
                id = 1,
                nameActivity = "Coding",
                activityDescription = "Actively using IDE",
                categoryName = "Work",
            },
            new Activity()
            {   
                id = 2,
                nameActivity = "Watching youtube",
                activityDescription = "Relaxing on youtube",
                categoryName = "Leisure"
            },
            new Activity()
            {   
                id = 3,
                nameActivity = "Stackoverflow",
                activityDescription = "Acquiring new knowledge",
                categoryName = "Research"
            },
            new Activity()
            {   
                id = 4,
                nameActivity = "No user activity",
                activityDescription = "PC is idle",
                categoryName = "Afk"
            },
            new Activity()
            {   
                id = 5,
                nameActivity = "Discord Meeting",
                activityDescription = "Planning..? Shittalking..? Its on discord at least.",
                categoryName = "Meeting"
            },
            new Activity()
            {   
                id = 6,
                nameActivity = "Playing OSRS",
                activityDescription = "Limiting EXP waste",
                categoryName = "Gaming"
            },
        });

        modelBuilder.Entity<ActivityDuration>().HasData(new List<ActivityDuration>()
        {
            new ActivityDuration()
            {
                id = 1,
                activityId = 1,
                startTime = DateTime.Now,
                durationTime = TimeSpan.FromHours(2)
            },
            new ActivityDuration()
            {
                id = 2,
                activityId = 2,
                startTime = DateTime.Now,
                durationTime = TimeSpan.FromHours(2)
            },
            new ActivityDuration()
            {
                id = 3,
                activityId = 3,
                startTime = DateTime.Now,
                durationTime = TimeSpan.FromHours(2)
            },
            new ActivityDuration()
            {
                id = 4,
                activityId = 4,
                startTime = DateTime.Now,
                durationTime = TimeSpan.FromHours(2)
            },
            new ActivityDuration()
            {
                id = 5,
                activityId = 5,
                startTime = DateTime.Now,
                durationTime = TimeSpan.FromHours(2)
            },
            new ActivityDuration()
            {
                id = 6,
                activityId = 6,
                startTime = DateTime.Now,
                durationTime = TimeSpan.FromHours(2)
            },
        });

        modelBuilder.Entity<Users>().HasData(new List<Users>()
        {
            new Users()
            {
                id = 1,
                userName  = "Lars Henning",
                email = "larsGmanHenning@gmail.com",
            },
            new Users()
            {
                id = 2,
                userName  = "Peter Paludan",
                email = "Paludan@gmail.com",
            },
            new Users()
            {
                id = 3,
                userName  = "Henriette",
                email = "henribobendi@gmail.com",
            },
            new Users()
            {
                id = 4,
                userName  = "Jens Jensen",
                email = "JensJensJens@gmail.com",
            },
            new Users()
            {
                id = 5,
                userName  = "Bent Belastende",
                email = "belastende@gmail.com",
            },
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
    
    [Required] 
    [Column(TypeName = "varchar(100)")] 
    public string categoryName { get; set; }
    
    public virtual ActivityDuration activityDuration { get; set; } 
    public virtual ActivityCategory activityCategory { get; set; }
}

public partial class ActivityCategory
{
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string catName{ get; set; }
    
    public virtual Activity activity{ get; set; }
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
    
    public Activity activity{ get; set; }
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
