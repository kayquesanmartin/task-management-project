namespace Gerenciador_de_Tarefas.Entities;

public class TaskItem
{
    public Guid Id { get; init; }
    public string Title { get; private set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public EnumTaskStatus Status { get; set; }

    public TaskItem(string title, string description)
    {
        Title = title;
        Id = Guid.NewGuid();
        Description = description;
        Date = DateTime.Now;
        Status = EnumTaskStatus.Pendente;
    }

    public void UpdateTask(UpdateTaskDto updateTaskDto)
    {
        if (!string.IsNullOrEmpty(updateTaskDto.Title))
        {
            Title = updateTaskDto.Title;
        }

        if (!string.IsNullOrEmpty(updateTaskDto.Description))
        {
            Description = updateTaskDto.Description;
        }

        if (updateTaskDto.Status.HasValue)
        {
            Status = updateTaskDto.Status.Value;
        }
    }
}