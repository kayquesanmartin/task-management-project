namespace Gerenciador_de_Tarefas.Entities;

public record TaskDto(Guid Id, string Title, string Description, EnumTaskStatus Status);