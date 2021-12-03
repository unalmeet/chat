using MongoDB.Bson;
using MongoDB.Driver;
using TodoApi.Models;

namespace TodoApi.Repositories
{
    public class MessageCollection : IMessageColletion
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Message> Collection;
        public MessageCollection()
        {
            Collection = _repository.db.GetCollection<Message>("Messages");
        }
        public async Task DeleteMessage(string id)
        {
            var filter = Builders<Message>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);

        }

        public async Task<List<Message>> GetAllMessages()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Message> GetMessageById(string id)
        {
            throw new NotImplementedException();
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.
                FirstAsync();
        }

        public async Task InsertMessage(Message message)
        {
            await Collection.InsertOneAsync(message);
        }

        public async Task UpdateMessage(Message message)
        {
            var filter = Builders<Message>.Filter.Eq(s => s.Id, message.Id);
            await Collection.ReplaceOneAsync(filter, message);
        }
    }
}


