using AspNetCoreIdentityApp.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreIdentityApp.Web.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.PublicationYear)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(b => b.Genre)
                .HasMaxLength(50);

            builder.Property(b => b.Publisher)
                .HasMaxLength(100);

            builder.Property(b => b.PageCount)
                .IsRequired();

            builder.Property(b => b.Language)
                .HasMaxLength(50);

            builder.Property(b => b.Summary)
                .HasMaxLength(1000);

            builder.Property(b => b.AvaliableCopies)
                .IsRequired();

           
            builder.ToTable("Books");
        }
    }
}
