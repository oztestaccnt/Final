using System.Collections.Generic;
using System.Linq;

namespace FormData.Models
{
    public class ProductContext 
    {
        List<Product> _products;

        public ProductContext()
        {
            _products = new List<Product>()
            {
                new Product { Id="100", Name="Car Steering Wheel", Price=50.99, CatId="3" },
                new Product { Id="101", Name="Luke Skywalker Doll", Price=10.98, CatId="1" },
                new Product { Id="102", Name="Leilani Wolfgramm Reggae CD", Price = 8.99, CatId="2" },
                new Product { Id="103", Name="Fuel Injector(s)", Price=99.99, CatId="3" },
                new Product { Id="104", Name="Beebull Hatchimal", Price=5.99, CatId="1" },
                new Product { Id="105", Name="Nattali Rize CD", Price=7.99, CatId="2" },
                new Product { Id="106", Name="Prince and the Revolution", Price=11.99, CatId="2" }

            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public Product Find(string id)
        {
            return _products.Where(p => p.Id == id).SingleOrDefault();
        }

        public IEnumerable<Product> FindBy(string id)
        {
            return _products.Where(p => p.CatId == id);
        }
    }
}