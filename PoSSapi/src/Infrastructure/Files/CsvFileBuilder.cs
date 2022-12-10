using System.Globalization;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Application.TodoLists.Queries.ExportTodos;
using PoSSapi.Infrastructure.Files.Maps;
using CsvHelper;

namespace PoSSapi.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
