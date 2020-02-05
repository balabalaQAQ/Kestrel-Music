using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kestrel.EntityModel.Ffoundation
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public   Guid ID { get; set; }
    }
}
