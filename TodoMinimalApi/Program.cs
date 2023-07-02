using TodoMinimalApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

RouteGroupBuilder todoItems = app.MapGroup("/todoitems");

todoItems.MapGet("/", TodoService.GetAllTodos).WithName("AllTodos").WithOpenApi();
todoItems.MapGet("/complete", TodoService.GetCompleteTodos).WithName("CompleteTodos").WithOpenApi();
todoItems.MapGet("/{id}", TodoService.GetTodo).WithName("Todo").WithOpenApi();
todoItems.MapPost("/", TodoService.CreateTodo).WithName("CreateTodo").WithOpenApi();
todoItems.MapPut("/{id}", TodoService.UpdateTodo).WithName("UpdateTodo").WithOpenApi();
todoItems.MapDelete("/{id}", TodoService.DeleteTodo).WithName("DeleteTodo").WithOpenApi();

app.Run();