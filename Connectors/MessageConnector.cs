using MongoDB.Bson;
using MongoDB.Driver;
using Privas.Interface;

namespace Privas.Connectors
{
    public class MessageConnector : IConnector
    {
        public IMongoCollection<BsonDocument> Collection = IConnector.Database.GetCollection<BsonDocument>("messages");

        public async Task Add(BsonDocument newMessage)
        {
            await Collection.InsertOneAsync(newMessage);
        }

        public async Task<DeleteResult> Delete(string messageId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MessageId", messageId);
            return await Collection.DeleteOneAsync(filter);
        }

        public async Task<BsonDocument> Get(string messageId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MessageId", messageId);
            var searchResult = await Collection.FindAsync(filter);
            return await searchResult.FirstOrDefaultAsync();
        }

        public async Task<List<BsonDocument>> GetAll()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<ReplaceOneResult> Update(string messageId, BsonDocument message)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("MessageId", messageId);
            return await Collection.ReplaceOneAsync(filter, message);
        }
    }
}
