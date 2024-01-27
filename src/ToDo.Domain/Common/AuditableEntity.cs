using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Common
{
    public class AuditableEntity<T> : BaseEntitiy<T>
    {
        [Column("create_at")]
        public DateTime?     CreateAt { get; set; }
        [Column("update_at")]
        public DateTime? UpdateAt { get; set; }
        [Column("delete_at")]
        public DateTime? DeleteAt { get; set; }
    }
}
