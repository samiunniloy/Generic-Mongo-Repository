
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Reflection.Metadata.Ecma335;

namespace Generic_MOngo
{
    public class ProductRepository :MongoRepository<Product>,IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;
        public ProductRepository(IMongoClient mongoClient,string databaseName, string collectionName) :
            base(mongoClient, databaseName,"ProductCollection")
        {
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<Product>("ProductCollection");
        }
        

       // public async Task<Product> Add(Product product)
       // {
       //     await InsertOneAsync(product);
       //     return product;
            
       // }

       // Task IProductRepository.Delete(string Name)
       // {
       //     throw new NotImplementedException();
       // }

       // public async Task<Product> Get(string Name)
       // {
       //     throw new NotImplementedException();
       // }

       //public async  Task<IEnumerable<Product>> GetAll()
       // {
       //    var pro= await GetAllAsync();
       //     return pro;
       // }

       // Task IProductRepository.Update(Product product)
       // {
       //     throw new NotImplementedException();
       // }
    }
}
