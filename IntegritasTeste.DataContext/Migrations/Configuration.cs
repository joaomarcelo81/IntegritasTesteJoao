using IntegritasTeste.Domain.Entities;

namespace IntegritasTeste.DataContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IntegritasTeste.DataContext.DataContext.IntegritasTesteDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(IntegritasTeste.DataContext.DataContext.IntegritasTesteDataContext context)
        {

            if (!context.Categories.Any())
            {
                var Categories = context.Categories.Add(new Category()
                {
                    Name = "Fruits",
                    Description = "Fruits"
                });
            }

            if (!context.Products.Any() && context.Categories.Any())
            {

                var category = context.Categories.FirstOrDefault(x => x.Name == "Fruits");

               //  context.Categories.

                var product = new Product()
                {
                    Name = "Banana",
                    Category = category,
                    Description = "Banana"

                };



                product.Prices.Add(new Price()
                {
                    StartDate = DateTime.Now.AddMonths(-1),
                    LastDate = DateTime.Now.AddMonths(3),
                    Value = 1.49M,
                    Active = true



                });


                var Products = context.Products.Add(product);
            }
        }
    }
}
