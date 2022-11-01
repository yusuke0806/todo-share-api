using System.ComponentModel.DataAnnotations.Schema;

namespace TodoShareApi.Models;
public class TodoTask
{
    public int Id { get; set; }
    
    public int? TagId { get; set; }
    
    [Column(TypeName = "varchar(255)")]
    public string Name { get; set; }
    
    public bool Completed { get; set; }
    
    public DateTimeOffset? Deadline { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public DateTimeOffset? DeletedAt { get; set; }

    public Tag? Tag { get; set; }
}