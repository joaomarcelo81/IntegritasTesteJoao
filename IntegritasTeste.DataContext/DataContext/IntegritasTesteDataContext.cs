using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegritasTeste.DataContext.Migrations;
using IntegritasTeste.Domain.Entities;


namespace IntegritasTeste.DataContext.DataContext
{
    public class IntegritasTesteDataContext : DbContext
    {

        public IntegritasTesteDataContext()
            : base("IntegritasTesteDataContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IntegritasTesteDataContext, Configuration>());

            //Conventions Configuration
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();



            
            modelBuilder.Properties<string>()
             .Configure(p => p.HasColumnType("varchar"));


            //Caso não especifique o tamanho do varchar sera sempre 100
            //If i didnt specify the column varchar It will be always 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));



            modelBuilder.Entity<Product>()
                .HasMany(x => x.Prices)
                .WithMany()
                .Map(
                    x =>
                    {
                        x.MapLeftKey("ProductID");
                        x.MapRightKey("PriceID");
                        x.ToTable("ProductPrice");
                    });



            modelBuilder.Entity<Order>()
             .HasMany(x => x.Products)
             .WithMany()
             .Map(
                 x =>
                 {
                     x.MapLeftKey("OrderID");
                     x.MapRightKey("ProductID");
                     x.ToTable("OrderProduct");
                 });


        }
        public override int SaveChanges()
        {

            #region Garantindo que o campo Active esteja preenchida ao ser criada

            foreach (var entry in ChangeTracker.Entries())
            {

                if (entry.Entity.GetType().GetProperty("Active") != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("Active").CurrentValue = true;
                    }
                    //if (entry.State == EntityState.Modified)
                    //{
                    //    entry.Property("Ativo").IsModified = false;
                    //}
                }
            }

            #endregion

            return base.SaveChanges();
        }
    }
}
