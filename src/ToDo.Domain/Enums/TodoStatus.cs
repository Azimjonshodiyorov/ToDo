using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Enums
{
    public enum TodoStatus
    {
        [EnumMember(Value ="done")]
        Done,
        [EnumMember(Value ="inprogress")]
        InProgress,
        [EnumMember(Value ="completed")]
        Completed
    }
}
