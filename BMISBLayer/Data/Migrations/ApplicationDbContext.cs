using System;
using System.Collections.Generic;
using System.Text;
using BMISBLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace PMISBLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
     
        public DbSet<Person> Person { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Deliverable> Deliverable { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoicePaymentTerm> InvoicePaymentTerm { get; set; }
        public DbSet<PaymentTerm> PaymentTerm { get; set; }
        public DbSet<Phase> Phase { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectPhase> ProjectPhase { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<ProjectManager> ProjectManager { get; set; }
        public DbSet<Client> Clients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

          

            base.OnModelCreating(builder);
            builder.Entity<ProjectPhase>().HasKey(x => x.ProjectPhaseId);
            //m-m
            builder.Entity<Project>().HasMany(p => p.ProjectPhases)
                .WithOne(x => x.Project)
                .HasForeignKey(s => s.ProjectId);

            builder.Entity<ProjectPhase>().HasOne(p => p.Phase)
                .WithMany(s => s.ProjectPhases)
                .HasForeignKey(x => x.PhaseId);

            builder.Entity<InvoicePaymentTerm>().HasKey(x => new { x.InvoiceId, x.PaymentTermId });
           
            builder.Entity<Invoice>().HasMany(p => p.InvoicePaymentTerms)
                .WithOne(s => s.Invoice)
                .HasForeignKey(x => x.InvoiceId);

            builder.Entity<InvoicePaymentTerm>().HasOne(s => s.PaymentTerm)
                .WithMany(c => c.InvoicePaymentTerms)
                .HasForeignKey(x => x.PaymentTermId);
            //1-m
            builder.Entity<ProjectType>().HasMany(x => x.Projects)
                .WithOne(c => c.ProjectType)
                .HasForeignKey(s => s.ProjectTypeId);
            //1-m
            builder.Entity<Project>().HasOne(s => s.ProjectStatus)
                .WithMany(c => c.Projects)
                .HasForeignKey(x => x.ProjectStatusId);
            builder.Entity<Deliverable>().HasOne(x => x.ProjectPhase)
                .WithMany(c => c.Deliverables)
                .HasForeignKey(s => s.ProjectPhaseId);
            //1-m

            builder.Entity<PaymentTerm>().HasOne(s => s.Deliverable)
                .WithMany(c => c.PaymentTerms)
                .HasForeignKey(x => x.DeliverableId);

            builder.Entity<Invoice>().HasOne(s => s.Project)
               .WithMany(c => c.Invoice)
               .HasForeignKey(x => x.ProjectId);


        }
    }
}