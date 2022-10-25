using System.ComponentModel.DataAnnotations.Schema;

namespace TodoShareApi.Models;

public class Tag
{
    public int Id { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }
    
    public List<TodoTask>? TodoTasks { get; set; }
}