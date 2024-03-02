using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Delgado.Shared;
using System.Linq.Expressions;

namespace Delgado.Server.DBConnect
{
    public class DBConnect<T>
    {
        private IMongoDatabase _db;

        public DBConnect(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(dbName);
        }

        public async Task Add(string col, T data)
        {
            var collection = _db.GetCollection<T>(col);
            await collection.InsertOneAsync(data);
        }

        public async Task<List<T>> GetAll(string col)
        {
            var collection = _db.GetCollection<T>(col);
            return await collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<T> Get(string col, string id)
        {
            var collection = _db.GetCollection<T>(col);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Update(string col, string id, T data)
        {
            var collection = _db.GetCollection<T>(col);
            var filter = Builders<T>.Filter.Eq("Id", id);
            await collection.ReplaceOneAsync(filter, data);
        }

        public async Task Delete(string col, string id)
        {
            var collection = _db.GetCollection<T>(col);
            var filter = Builders<T>.Filter.Eq("Id", id);
            await collection.DeleteOneAsync(filter);
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> filter,string col)
        {
            var collection = _db.GetCollection<T>(col);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
