using System.ComponentModel.DataAnnotations.Schema;
using ToDo.Domain.Common;

namespace ToDo.Domain.Entities
{
    [Table("category",Schema ="todo_list")]
    public class Categorey : AuditableEntity<long>
    {
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
    }
}
