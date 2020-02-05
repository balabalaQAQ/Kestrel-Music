using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kestrel.EntityModel.Ffoundation
{
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public   string Description { get; set; }
        [StringLength(100)]
        public   string SortCode { get; set; }
        public   bool IsPseudoDelete { get; set; }
 
    }
}
