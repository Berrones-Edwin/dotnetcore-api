using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;


[ApiController]
[Route("api/[controller]")]
// [Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{

    private readonly Context _context;
    public TodoItemsController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        return await _context.TodoItems
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }
    //Get: api/todoItems/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDTO>> getTodoItem(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDTO(todoItem);
    }
    // </snippet_GetByID>

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, TodoItemDTO todoDTO)
    {
        if (id != todoDTO.Id)
        {
            return BadRequest();
        }
        
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        todoItem.Name = todoDTO.Name;
        todoItem.isComplete = todoDTO.isComplete;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        {

            return NotFound();
        }

        return NoContent();

    }

    [HttpPost]
    public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
    {
        var todoItem = new TodoItem
        {
            isComplete = todoDTO.isComplete,
            Name = todoDTO.Name,
        };

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(getTodoItem),
            new { id = todoItem.Id },
            ItemToDTO(todoItem)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {

        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {

            return NotFound();
        }

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    private bool TodoItemExists(long id)
    {

        return _context.TodoItems.Any(e => e.Id == id);
    }
    private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
    new TodoItemDTO
    {
        Id = todoItem.Id,
        Name = todoItem.Name,
        isComplete = todoItem.isComplete,
    };

}