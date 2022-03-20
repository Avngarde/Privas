using MongoDB.Bson;
using MongoDB.Driver;

namespace Privas.Interface
{
    public interface IConnector
    {
        private static MongoClient Client => new("mongodb+srv://500PlusClient:SecretsOfVatican1978@cluster0.1kawz.azure.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        static IMongoDatabase Database => Client.GetDatabase("Privas");
        Task<List<MongoDB.Bson.BsonDocument>> GetAll();
        Task<BsonDocument> Get(string id);
        Task Add(BsonDocument document);
        Task<ReplaceOneResult> Update(string uniqueCode, BsonDocument chatroom);
        Task<DeleteResult> Delete(string id);
    }
}