using Biotekno.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biotekno.Presentation.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        Random randomGenerator = new Random();

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {

            List<Product> products = new List<Product>();
            for (int i = 0; i < 1000; i++)
            {
                Product product = new Product()
                {
                    Id = i,
                    UnitPrice= randomGenerator.Next(1,10000),
                    Description = Faker.Lorem.Sentence(100),
                    Category = Faker.Name.First(),
                    Unit = randomGenerator.Next(1,10),
                    Status = true,
                    CreatedDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                };
                products.Append(product);
            }
            modelBuilder.Entity<Product>().HasData(products);
               
        }
    }
}
