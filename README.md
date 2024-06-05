## Documentação da API

### Rotas da API

#### Criar uma nova tarefa

```http
  POST /Task
```

| Parâmetro    | Tipo       | Descrição                           |
| :----------  | :--------- | :-----------------------------------|
| `title`      | `string`   | "title": "Título da tarefa"         |
| `description`| `string`   | "description": "Descrição da tarefa"|

#### Retorna todos os itens

```http
  GET /Task/GetAll
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :-----------------------------------|
| `id`        | `GUID`     | Retorna todos os dados do ID        |

#### Atualizar uma tarefa

```http
  PUT /Task/{id}
```

| Parâmetro   | Tipo       | Descrição                                           |
| :---------- | :--------- | :---------------------------------------------------|
| `id`        | `GUID`     | **Obrigatório**. O ID do item que você quer alterar |

#### Deletar uma tarefa

```http
  DELETE /{id}
```

| Parâmetro   | Tipo       | Descrição                                           |
| :---------- | :--------- | :---------------------------------------------------|
| `id`        | `GUID`     | **Obrigatório**. O ID do item que você quer alterar |

## Estrutura do Projeto

```
Gerenciador_de_Tarefas/
├── Data/
│   └── AppDbContext.cs
├── DTO/
│   ├── TaskDto.cs
│   └── UpdateTaskDto.cs
├── Entities/
│   ├── AddTaskRequest.cs
│   ├── UpdateTaskRequest.cs
│   ├── TaskItem.cs
│   └── EnumTaskStatus.cs
├── Routes/
│   └── TaskRoutes.cs
├── Program.cs
├── appsettings.json
└── README.md
```
