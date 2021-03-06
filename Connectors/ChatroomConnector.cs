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

        public async Task<DeleteResult> Delete(string uniqueCode)
        {
            MessageConnector messageConnector = new();
            await messageConnector.DeleteAllByChatId(uniqueCode);
            var filter = Builders<BsonDocument>.Filter.Eq("UniqueCode", uniqueCode);
            return await Collection.DeleteOneAsync(filter);
        }

        public async Task<DeleteResult> DeleteByUserCode(string userCode) 
        {
            MessageConnector messageConnector = new();
            await messageConnector.DeleteAllByOwnerId(userCode);
            var filter = Builders<BsonDocument>.Filter.Eq("OwnerCode", userCode);
            return await Collection.DeleteOneAsync(filter);
        }

        public async Task<BsonDocument> Get(string uniqueCode)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("UniqueCode", uniqueCode);
            var searchResult = await Collection.FindAsync(filter);
            return await searchResult.FirstOrDefaultAsync();
        }

        public async Task<List<MongoDB.Bson.BsonDocument>> GetAll()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<ReplaceOneResult> Update(string uniqueCode, BsonDocument chatroom)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("UniqueCode", uniqueCode);
            return await Collection.ReplaceOneAsync(filter, chatroom);
        }
    }
}