using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoListService todoListService;
        public TodoController(ITodoListService todoListService)
        {
            this.todoListService = todoListService;
        }

        [HttpPost]
        public void AddItem(Item item)
        {
            var response= todoListService.AddItem(item);

            
        }
    }
}