using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Common
{
    public class BaseEntitiy<T>
    {
        [Column("id")]
        public T Id { get; set; }
    }
}
