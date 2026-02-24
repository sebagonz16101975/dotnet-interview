namespace TodoApi.Dtos;

using TodoApi.Models;

public class CreateTodoList
{
    public required string Name { get; set; }
    public List<TodoItem> TodoItems { get; set; } = new();
}
