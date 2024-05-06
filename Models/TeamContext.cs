using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace webproject.Models
{
    public class TeamContext : DbContext
    {
        public TeamContext() { }
        public TeamContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<LahoreQalandars> LahoreQalandars { get; set; }
        public DbSet<MultanSultans> MultanSultans { get; set; }
        public DbSet<QuettaGladiators> QuettaGladiators { get; set; }
        public DbSet<KarachiKings> KarachiKings { get; set; }
        public DbSet<IslamabadUnited> IslamabadUnited { get; set; }
        public DbSet<PeshawarZalmi> PeshawarZalmi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TeamsDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<LahoreQalandars>().ToTable("LahoreQalandars");
            modelBuilder.Entity<MultanSultans>().ToTable("MultanSultans");
            modelBuilder.Entity<QuettaGladiators>().ToTable("QuettaGladiators");
            modelBuilder.Entity<KarachiKings>().ToTable("KarachiKings");
            modelBuilder.Entity<PeshawarZalmi>().ToTable("PeshawarZalmi");
            modelBuilder.Entity<IslamabadUnited>().ToTable("IslamabadUnited");


           
            /*modelBuilder.Ignore<IslamabadUnited>();*/
        }

        public string UserName { get; set; } = "Admin";

        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                var tableName = entry.Entity.GetType().Name;
                dynamic entity;
                if (tableName == "LahoreQalandars")
                    entity = (LahoreQalandars)entry.Entity;
                else if (tableName == "KarachiKings")
                    entity = (KarachiKings)entry.Entity;
                else if (tableName == "PeshawarZalmi")
                    entity = (PeshawarZalmi)entry.Entity;
                else if (tableName == "MultanSultans")
                    entity = (MultanSultans)entry.Entity;
                else if (tableName == "QuettaGladiators")
                    entity = (QuettaGladiators)entry.Entity;
                else if (tableName == "IslamabdUnited")
                    entity = (QuettaGladiators)entry.Entity;
                else
                    continue;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = UserName;
                    entity.CreatedTime = System.DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedBy = UserName;
                    entity.ModifiedTime = System.DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        /*public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is FullAuditModel)
                {
                    var referenceEntity = entry.Entity as FullAuditModel;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedDate = DateTime.Now;
                            if (string.IsNullOrWhiteSpace(referenceEntity.
                            CreatedByUserId))
                            {
                                referenceEntity.CreatedByUserId = _systemUserId;
                            }
                            break;
                        case EntityState.Deleted:
                        case EntityState.Modified:
                            referenceEntity.LastModifiedDate = DateTime.Now;
                            if (string.IsNullOrWhiteSpace(referenceEntity.
                            LastModifiedUserId))
                            {
                                referenceEntity.LastModifiedUserId = _systemUserId;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }*/

    }
}
