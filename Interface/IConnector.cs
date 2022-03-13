using MongoDB.Bson;
using MongoDB.Driver;

namespace Privas.Interface
{
    public interface IConnector
    {
        private MongoClient Client => new("MongoDBPasses");
        IMongoDatabase Database => Client.GetDatabase("Privas");
        IMongoCollection<BsonDocument> Collection { get; set; }
        BsonDocument GetAll();
        BsonDocument Get();
        void Add();
        UpdateResult Update();
        DeleteResult Delete();
    }
}
