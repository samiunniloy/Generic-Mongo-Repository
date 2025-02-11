using Microsoft.AspNetCore.Mvc;

namespace Generic_MOngo
{
    public interface IProductRepository:IRepository<Product>
    {
        //Task<IEnumerable<Product>> GetAll();
        //Task<Product> Get(string Name);
        //Task<Product> Add(Product product);
        //Task Update(Product product);
        //Task Delete(string id);

    }
}
