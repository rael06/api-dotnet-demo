using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using MyWebAPI.Services.TodoService;

namespace MyWebAPI.Infrastructure.Database.Repositories;

public class TodoRepository : ITodoRepository
{
  private readonly AppDbContext _context;
  public TodoRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Todo> CreateTodo(Todo todo)
  {
    var createdTodo = await _context.Todos.AddAsync(todo);
    await _context.SaveChangesAsync();
    return createdTodo.Entity;
  }

  public async Task<ICollection<Todo>> GetTodos()
  {
    return await _context.Todos.ToListAsync();
  }
}