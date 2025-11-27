using MyWebAPI.Models;

namespace MyWebAPI.Services.TodoService;

public interface ITodoRepository
{
  Task<Todo> CreateTodo(Todo todo);
  Task<ICollection<Todo>> GetTodos();
  Task<Todo?> GetTodoById(int id);
  Task<Todo?> UpdateTodo(Todo todo);
  Task<bool> DeleteTodo(int id);
}