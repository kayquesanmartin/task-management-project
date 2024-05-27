namespace Gerenciador_de_Tarefas.Entities;

public class TaskItem
{
    public Guid Id { get; init; }
    public string Title { get; private set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public EnumTaskStatus Status { get; set; }

    public TaskItem(string title)
    {
        Title = title;
        Id = Guid.NewGuid();
        Description = "";
        Date = DateTime.Now;
        Status = EnumTaskStatus.Pendente;
    }
}