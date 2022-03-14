using MongoDB.Bson;
using MongoDB.Driver;

namespace Privas.Interface
{
    public interface IConnector
    {
        private static MongoClient Client => new("mongodb+srv://500PlusClient:SecretsOfVatican1978@cluster0.1kawz.azure.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        static IMongoDatabase Database => Client.GetDatabase("Privas");
        List<MongoDB.Bson.BsonDocument> GetAll();
        BsonDocument Get(string id);
        Task Add(BsonDocument document);
        ReplaceOneResult Update(string uniqueCode, BsonDocument chatroom);
        DeleteResult Delete(string id);
    }
}