using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EF
{
    public partial class ACMEContext : DbContext
    {
        public ACMEContext()
        {
        }

        public ACMEContext(DbContextOptions<ACMEContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonCompany> PersonCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=ACME;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PersonCompany>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.CompanyId });

                entity.ToTable("PersonCompany");

                entity.HasIndex(e => e.CompanyId, "IX_PersonCompany_CompanyId");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PersonCompanies)
                    .HasForeignKey(d => d.CompanyId);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonCompanies)
                    .HasForeignKey(d => d.PersonId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
