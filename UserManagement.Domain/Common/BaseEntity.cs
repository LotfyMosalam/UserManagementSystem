using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        protected BaseEntity()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
