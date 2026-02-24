namespace TodoApi.Models
{
    public class TodoItem
    {
        public required TodoList todoList { get; set; }
        public long Id { get; set; }
        public required string Name { get; set; }
        public long idTodoList { get; set; }
        // Foreign Key
        public int TodoListId { get; set; }
        // Propiedad de navegación (muchos -> uno)
        public required TodoList TodoList { get; set; }


    }
}
