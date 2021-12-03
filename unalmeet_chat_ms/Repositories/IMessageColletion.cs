using TodoApi.Models;

namespace TodoApi.Repositories
{
    public interface IMessageColletion
    {
        Task InsertMessage(Message message);
        Task UpdateMessage(Message message);
        Task DeleteMessage(string id);
        Task<List<Message>> GetAllMessages();
        Task<Message> GetMessageById(string id);
    }
}




