using MongoDB.Bson;
using MongoDB.Driver;
using Privas.Interface;

namespace Privas.Connectors
{
    public class MembershipConnector : IConnector
    {
        public IMongoCollection<BsonDocument> Collection = IConnector.Database.GetCollection<BsonDocument>("chatroom_membership");

        public async Task Add(BsonDocument newMembership)
        {
            await Collection.InsertOneAsync(newMembership);
        }

        public async Task<DeleteResult> Delete(string userId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);
            return await Collection.DeleteOneAsync(filter);

        }

        public async Task<DeleteResult> DeleteAllByChatId(string chatId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("ChatId", chatId);
            return await Collection.DeleteManyAsync(filter);
        }

        public async Task<BsonDocument> Get(string userId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);
            var searchResult = await Collection.FindAsync(filter);
            return await searchResult.FirstOrDefaultAsync();
        }

        public async Task<List<MongoDB.Bson.BsonDocument>> GetAll()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<MongoDB.Bson.BsonDocument>> GetAllFilter(string userId) 
        {
            var filter = Builders<BsonDocument>.Filter.Eq("userId", userId);
            var searchResult = await Collection.FindAsync(filter);
            return await searchResult.ToListAsync();   
        }

        public async Task<List<BsonDocument>> GetAllByChatId(string chatId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("ChatId", chatId);
            var searchResult = await Collection.FindAsync(filter);
            return await searchResult.ToListAsync();
        }

        public async Task<ReplaceOneResult> Update(string userId, BsonDocument chatroom)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("userId", userId);
            return await Collection.ReplaceOneAsync(filter, chatroom);
        }
    }
}