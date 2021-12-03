using MongoDB.Driver;

namespace TodoApi.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;
        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://mongo:27017");
            db = client.GetDatabase("unalmeet_chat_db");
        }
    }
}