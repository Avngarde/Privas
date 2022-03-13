using MongoDB.Bson;
using MongoDB.Driver;

namespace Privas.Interface
{
    public interface IConnector
    {
        private static MongoClient Client => new("MongoDBPasses");
        static IMongoDatabase Database => Client.GetDatabase("Privas");
        BsonDocument GetAll();
        BsonDocument Get();
        void Add();
        UpdateResult Update();
        DeleteResult Delete();
    }
}
