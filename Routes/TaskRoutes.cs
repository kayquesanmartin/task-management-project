using Azure.Core;
using Gerenciador_de_Tarefas.Data;
using Gerenciador_de_Tarefas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador_de_Tarefas.Routes;

public static class TaskRoutes
{
    public static void AddTaskRoutes(this WebApplication app)
    {
        var taskRoutes = app.MapGroup("Task");

        taskRoutes.MapPost("",
            async (AddTaskRequest request, AppDbContext context, CancellationToken ct) =>
            {
                var alreadyExists = await context.Tasks
                    .AnyAsync(task => task.Title == request.Title, ct);

                if (alreadyExists)
                    return Results.Conflict($"The task with the title '{request.Title}' already exists");

                var newTask = new TaskItem(request.Title, request.Description);
                await context.Tasks.AddAsync(newTask, ct);
                await context.SaveChangesAsync(ct);

                var returnTask = new TaskDto(newTask.Id, newTask.Title, newTask.Description, newTask.Status);

                return Results.Ok(returnTask);
            });
        
        taskRoutes.MapGet("/GetAll", async (AppDbContext context, CancellationToken ct) =>
        {
            var tasks = await context
                .Tasks
                .Select(task => new TaskDto(task.Id, task.Title, task.Description, task.Status))
                .ToListAsync(ct);

            return tasks;
        });

        taskRoutes.MapPut("/{id:guid}",
            async (Guid id, UpdateTaskDto updateTaskDto, AppDbContext context, CancellationToken ct) =>
            {
                var task = await context.Tasks
                    .SingleOrDefaultAsync(task => task.Id == id, ct);

                if (task == null)
                    return Results.NotFound();
                
                task.UpdateTask(updateTaskDto);
                await context.SaveChangesAsync(ct);

                return Results.Ok(task);
            });

        taskRoutes.MapDelete("{id}", async (Guid id, AppDbContext context, CancellationToken ct) =>
        {
            var task = await context.Tasks
                .SingleOrDefaultAsync(task => task.Id == id, ct);

            if (task == null)
                return Results.NotFound();

            context.Tasks.Remove(task);

            await context.SaveChangesAsync();

            return Results.Ok(task);
        });
    }
}