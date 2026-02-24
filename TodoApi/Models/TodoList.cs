namespace TodoApi.Models;

public class TodoList
{
    public long Id { get; set; }
    public required string Name { get; set; }
    // Relación 1 -> N
    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
