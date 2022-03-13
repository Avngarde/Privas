using MongoDB.Bson;
using MongoDB.Driver;
using Privas.Interface;

namespace Privas.Connectors
{
    public class ChatroomConnector : IConnector
    {
        public IMongoCollection<BsonDocument> Collection = IConnector.Database.GetCollection<BsonDocument>("chatrooms");
     
        public void Add()
        {
            throw new NotImplementedException();
        }

        public DeleteResult Delete()
        {
            throw new NotImplementedException();
        }

        public BsonDocument Get()
        {
            throw new NotImplementedException();
        }

        public BsonDocument GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdateResult Update()
        {
            throw new NotImplementedException();
        }
    }
}
