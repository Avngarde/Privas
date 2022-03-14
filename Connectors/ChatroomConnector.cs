using MongoDB.Bson;
using MongoDB.Driver;
using Privas.Interface;

namespace Privas.Connectors
{
    public class ChatroomConnector : IConnector
    {
        public IMongoCollection<BsonDocument> Collection = IConnector.Database.GetCollection<BsonDocument>("chatrooms");

        public async Task Add(BsonDocument newChatroom)
        {
            await Collection.InsertOneAsync(newChatroom);
        }

        public DeleteResult Delete(string uniqueCode)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("uniqueCode", uniqueCode);
            return Collection.DeleteOne(filter);

        }

        public BsonDocument Get(string uniqueCode)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("uniqueCode", uniqueCode);
            return Collection.Find(filter).FirstOrDefault();
        }

        public List<MongoDB.Bson.BsonDocument> GetAll()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public ReplaceOneResult Update(string uniqueCode, BsonDocument chatroom)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("uniqueCode", uniqueCode);
            return Collection.ReplaceOne(filter, chatroom);
        }
    }
}