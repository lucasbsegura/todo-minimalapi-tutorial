using Microsoft.EntityFrameworkCore;
using TodoMinimalApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

RouteGroupBuilder todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", TodoService.GetAllTodos);
todoItems.MapGet("/complete", TodoService.GetCompleteTodos);
todoItems.MapGet("/{id}", TodoService.GetTodo);
todoItems.MapPost("/", TodoService.CreateTodo);
todoItems.MapPut("/{id}", TodoService.UpdateTodo);
todoItems.MapDelete("/{id}", TodoService.DeleteTodo);

app.Run();