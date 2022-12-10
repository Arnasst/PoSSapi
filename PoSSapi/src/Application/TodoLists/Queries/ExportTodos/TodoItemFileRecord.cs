using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
