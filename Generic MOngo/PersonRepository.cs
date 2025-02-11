using MongoDB.Driver;
using System.Linq.Expressions;

namespace Generic_MOngo
{
    public class PersonRepository : MongoRepository<Person>, IPersonRepository
    {
        private readonly IMongoCollection<Person> _collection;
        public PersonRepository(IMongoClient mongoClient, string databaseName, string collectionName) :
            base(mongoClient, databaseName, "PersonCollection")
        {
            var database = mongoClient.GetDatabase(databaseName);
            _collection = database.GetCollection<Person>("PersonCollection");
        }

        //Task IRepository<Person>.DeleteManyAsync(Expression<Func<Person, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IRepository<Person>.DeleteOneAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Person>> IRepository<Person>.FindAsync(Expression<Func<Person, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<IEnumerable<Person>> IRepository<Person>.GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Person> IRepository<Person>.GetByIdAsync(string id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IRepository<Person>.InsertManyAsync(ICollection<Person> documents)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IRepository<Person>.InsertOneAsync(Person document)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IRepository<Person>.UpdateOneAsync(string id, Person document)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
