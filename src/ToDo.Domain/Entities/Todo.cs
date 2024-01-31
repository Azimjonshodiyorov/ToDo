using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Domain.Common;
using ToDo.Domain.Enums;

namespace ToDo.Domain.Entities
{
    [Table("todo1", Schema ="todo1_list")]
    public class Todo : AuditableEntity<long>
    {
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]

        public string Description { get; set; }
        [Column("todo_status")]
        public TodoStatus  TodoStatus { get; set; }
        [Column("category_id")]
        public long CategoryId { get; set; }

        public virtual Categorey Category { get; set; }
    }
}
