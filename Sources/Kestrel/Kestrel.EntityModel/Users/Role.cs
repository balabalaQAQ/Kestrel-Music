using Kestrel.EntityModel.Ffoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Users
{
  public class Role: Entity
    {
        public Role() : base()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
