using PoSSapi.Application.TodoLists.Queries.ExportTodos;

namespace PoSSapi.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
