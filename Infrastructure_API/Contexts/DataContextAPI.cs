using Infrastructure_API.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure_API.Contexts;

public class DataContextApi(DbContextOptions options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<SubscriberEntity> Subscribers { get; set; }

    
}

