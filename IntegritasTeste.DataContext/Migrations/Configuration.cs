using System.Collections.Generic;
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
                context.Categories.Add(new Category()
                {
                    Name = "Fruits",
                    Description = "Fruits"
                });

                context.Categories.Add(new Category()
                {
                    Name = "Vegetables",
                    Description = "Vegetables"
                });
            }

            if (!context.Products.Any() && context.Categories.Any())
            {

                var category = context.Categories.FirstOrDefault(x => x.Name == "Fruits");


                
                context.Products.Add(new Product()
                {
                    Name = "Banana",
                    Category = category,
                    Description = "Banana",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 1.49M,
                            Active = true
                        }
                    }
                });


                context.Products.Add(new Product()
                {
                    Name = "Apple",
                    Category = category,
                    Description = "Apple",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 2.15M,
                            Active = true
                        }
                    }
                });

          
                context.Products.Add(new Product()
                {
                    Name = "Bilberry",
                    Category = category,
                    Description = "Apple",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 4.15M,
                            Active = true
                        }
                    }
                  });

                context.Products.Add(new Product()
                {
                    Name = "Blackberry",
                    Category = category,
                    Description = "Blackberry",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 2.25M,
                            Active = true
                        }
                    }
                   });

                context.Products.Add(new Product()
                {
                    Name = "Blackcurrant",
                    Category = category,
                    Description = "Blackcurrant",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 3.15M,
                            Active = true
                        }
                    }
                  });

                context.Products.Add(new Product()
                {
                    Name = "Blueberry",
                    Category = category,
                    Description = "Blueberry",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 0.25M,
                            Active = true
                        }
                    }
                  });

                context.Products.Add(new Product()
                {
                    Name = "Boysenberry",
                    Category = category,
                    Description = "Boysenberry",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 2.25M,
                            Active = true
                        }
                    }
                 });

                context.Products.Add(new Product()
                {
                    Name = "Currant",
                    Category = category,
                    Description = "Currant",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 7.25M,
                            Active = true
                        }
                    }
                   });

                context.Products.Add(new Product()
                {
                    Name = "Cherry",
                    Category = category,
                    Description = "Cherry",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 3.25M,
                            Active = true
                        }
                    }
                   });

                context.Products.Add(new Product()
                {
                    Name = "Cherimoya",
                    Category = category,
                    Description = "Cherimoya",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 3.25M,
                            Active = true
                        }
                    }
                   });

                context.Products.Add(new Product()
                {
                    Name = "Cloudberry",
                    Category = category,
                    Description = "Cloudberry",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 1.05M,
                            Active = true
                        }
                    }
                   });

                context.Products.Add(new Product()
                {
                    Name = "Coconut",
                    Category = category,
                    Description = "Coconut",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 4.66M,
                            Active = true
                        }
                    }
                   });

                context.Products.Add(new Product()
                {
                    Name = "Cranberry",
                    Category = category,
                    Description = "Cranberry",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 2.25M,
                            Active = true
                        }
                    }
                  });

                context.Products.Add(new Product()
                {
                    Name = "Cucumber",
                    Category = category,
                    Description = "Cucumber",
                    Prices = new List<Price>()
                    {
                        new Price()
                        {
                            StartDate = DateTime.Now.AddMonths(-1),
                            LastDate = DateTime.Now.AddMonths(3),
                            Value = 1.15M,
                            Active = true
                        }
                    }
                });




            }
        }
    }
}
