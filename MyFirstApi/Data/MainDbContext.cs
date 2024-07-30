using Microsoft.EntityFrameworkCore;
using MyFirstApi.Models;

namespace MyFirstApi.Data;

public class MainDbContext(DbContextOptions<MainDbContext> options, IConfiguration configuration)
    : DbContext(options)
{
    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    
    // One-to-One
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Address> Addresses => Set<Address>();
    
    // Many-to-Many
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Actor> Actors => Set<Actor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //seed data commented because need to add Contact model relation also
        /*modelBuilder.Entity<Invoice>().HasData(
            new Invoice
            {
                Id = Guid.NewGuid(),
                InvoiceNumber = "INV-001",
                ContactName = "Iron Man",
                Description = "Invoice for the first month",
                Amount = 100,
                InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                Status = InvoiceStatus.AwaitPayment,
                Contact = new Contact
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com"
                },
                InvoiceItems = new List<InvoiceItem>
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Description = "Item 1",
                        Quantity = 1,
                        UnitPrice = 100,
                        Amount = 100
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Description = "Item 2",
                        Quantity = 2,
                        UnitPrice = 200,
                        Amount = 400
                    }
                }
            },
            new Invoice
            {
                Id = Guid.NewGuid(),
                InvoiceNumber = "INV-002",
                ContactName = "Captain America",

                Description = "Invoice for the first month",
                Amount = 200,
                InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                Status = InvoiceStatus.AwaitPayment,
                ContactId = Guid.NewGuid()
            },
            new Invoice
            {
                Id = Guid.NewGuid(),
                InvoiceNumber = "INV-003",
                ContactName = "Thor",
                Description = "Invoice for the first month",
                Amount = 300,
                InvoiceDate = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero),
                DueDate = new DateTimeOffset(2021, 1, 15, 0, 0, 0, TimeSpan.Zero),
                Status = InvoiceStatus.Draft,
                ContactId = Guid.NewGuid()
            }
        );*/

        // Use IEntityTypeConfiguration<TEntity> interface
        //modelBuilder.ApplyConfiguration(new InvoiceConfiguration());

        // Or
        //new InvoiceConfiguration().Configure(modelBuilder.Entity<Invoice>());.

        // Grouping the configurations (if many configurations needs to be added)
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        
        optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
                //b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
           // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking) // Global AsNoTracking()
            .EnableSensitiveDataLogging() // Enable sensitive data logging
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}