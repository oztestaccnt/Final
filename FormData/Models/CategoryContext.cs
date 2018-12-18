using System.Collections.Generic;
using System.Linq;

namespace FormData.Models
{
    public class CategoryContext 
    {
        List<Category> _categories;

        public CategoryContext()
        {
            _categories = new List<Category>()
            {
                new Category { Id="1", Name="Toys" },
                new Category { Id="2", Name="Music" },
                new Category { Id="3", Name="Automotive" }
            };
        }
        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category Find(string id)
        {
            return _categories.Where(p => p.Id == id).SingleOrDefault();
        }
    }
}