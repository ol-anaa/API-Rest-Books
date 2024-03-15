using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data;

public class BookContext : DbContext
{
    //Passando para o construtor da classe base(DbContext) as opts do nosso construtor 
    public BookContext(DbContextOptions<BookContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressViewModel>()
            .HasOne(adderess => adderess.Bookstore)
            .WithOne(bookstore => bookstore.Address)
            .HasForeignKey<BookstoreViewModel>(bookstores => bookstores.AddressId);

        modelBuilder.Entity<BookstoreViewModel>()
            .HasOne(bookstore => bookstore.Manager)
            .WithMany(manager => manager.Bookstore)
            .HasForeignKey(bookstore => bookstore.ManagerId);
        //.OnDelete(DeleteBehavior.Restrict)
        //.IsRequired(false);

        modelBuilder.Entity<AutographSessionViewModel>()
            .HasOne(autographSession => autographSession.Book)
            .WithMany(book => book.AutographSessions)
            .HasForeignKey(autographSession => autographSession.BookId);


        modelBuilder.Entity<AutographSessionViewModel>()
            .HasOne(autographSession => autographSession.Bookstore)
            .WithMany(bookstore => bookstore.AutographSession)
            .HasForeignKey(autographSession => autographSession.BookstoreId);
    }

    public DbSet<BookViewModel> Books { get; set; }
    public DbSet<BookstoreViewModel> Bookstores { get; set; }
    public DbSet<AddressViewModel> Addresses { get; set; }
    public DbSet<ManagerViewModel> Manager { get; set; }
    public DbSet<AutographSessionViewModel> AutographSession { get; set; }
}
