using Kestrel.EntityModel.Ffoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.User
{
    public class Comment : IEntity
    {
        public string Name { get; set ; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }
        public Guid ID { get; set; }
    }
}
