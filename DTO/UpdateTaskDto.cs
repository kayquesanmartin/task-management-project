namespace Gerenciador_de_Tarefas.Entities;

public class UpdateTaskDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public EnumTaskStatus? Status { get; set; }
}