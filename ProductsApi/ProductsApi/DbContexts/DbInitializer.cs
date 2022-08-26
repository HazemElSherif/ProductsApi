using ProductsApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.DbContexts
{
    public static class DbInitializer
    {
        public static void Initialize(ProductsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var categories = new Category[]
            {
            new Category{Name="Category1"},
            new Category{Name="Category2"},
            new Category{Name="Category3"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
            new Product{Name="Product1",Price=10,Quantity=15,ImgURL="/image1",CategoryID=1},
            new Product{Name="Product2",Price=20,Quantity=25,ImgURL="/image2",CategoryID=1},
            new Product{Name="Product3",Price=30,Quantity=35,ImgURL="/image3",CategoryID=1},
            new Product{Name="Product4",Price=40,Quantity=45,ImgURL="/image4",CategoryID=2},
            new Product{Name="Product5",Price=50,Quantity=55,ImgURL="/image5",CategoryID=2},
            new Product{Name="Product6",Price=60,Quantity=65,ImgURL="/image6",CategoryID=2},
            new Product{Name="Product7",Price=70,Quantity=75,ImgURL="/image7",CategoryID=3},
            new Product{Name="Product8",Price=80,Quantity=85,ImgURL="/image8",CategoryID=3},
            new Product{Name="Product9",Price=90,Quantity=95,ImgURL="/image9",CategoryID=3},
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}

