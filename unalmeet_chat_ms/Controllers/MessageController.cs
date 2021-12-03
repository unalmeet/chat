using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private IMessageColletion db = new MessageCollection();
        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            return Ok(await db.GetAllMessages());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageDetails(string id)
        {
            return Ok(await db.GetMessageById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage([FromBody] Message message)
        {
            if (message == null)
                return BadRequest();
            if(message.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The message shouldn't be empty");
            }
            await db.InsertMessage(message);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage([FromBody] Message message, string id)
        {
            if (message == null)
                return BadRequest();
            if (message.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The message shouldn't be empty");
            }

            message.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateMessage(message);
            return Created("Created", true);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMessage(string id)
        {
            await db.DeleteMessage(id);

            return NoContent();
        }

    }
}
