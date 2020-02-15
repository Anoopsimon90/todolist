using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;
using ToDoList.Utils;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors]
    public class TodoController : ControllerBase
    {
        private readonly ITodoListService todoListService;
        public TodoController(ITodoListService todoListService)
        {
            this.todoListService = todoListService;
        }

        [HttpPost]
        public ActionResult AddItem([FromBody] Item item)
        {
            var response= todoListService.AddItem(item);

            return Ok(response);
                        
        }

        [HttpGet]
        public ActionResult GetItems()
        {
            var response = todoListService.GetItems();

            return Ok(response);

        }

        [HttpGet("getItem")]
        public ActionResult GetItem(string itemName)
        {
            if (ValidationHelper.IsTaskNameEmpty(itemName))
                return BadRequest(itemName);

            var response = todoListService.GetItem(itemName);
                if (response is null) return NotFound(itemName);

            return Ok(response);

        }
    }
}