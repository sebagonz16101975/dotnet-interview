using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/todolists
        [HttpGet]
        public async Task<ActionResult<IList<TodoItem>>> GetTodoItems()
        {
            return Ok(await _context.TodoItem.ToListAsync());
        }

        // GET: api/todolists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // POST: api/todolists
        // To protect from over-posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodoItem(CreateTodoItem pTodoItem)
        {
            var todoItem = new TodoList { Name = pTodoItem.Name };
            _context.TodoList.Add(todoItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTodoList", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/todolists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItem.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _context.TodoItem.Remove(todoItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoItem(long id, UpdateTodoItem pUpdateTodoItem)
        {
            var todoList = await _context.TodoList.FindAsync(id);

            if (todoList == null)
            {
                return NotFound();
            }

            todoList.Name = pUpdateTodoItem.Name;
            await _context.SaveChangesAsync();

            return Ok(todoList);
        }
    }
}
