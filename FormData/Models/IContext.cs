using System.Collections.Generic;

namespace FormData.Models
{
    public interface IContext
    {
        List<Category> GetAll();

        Category Find(string id);

        IEnumerable<Product> FindBy(string id);
    }
}
