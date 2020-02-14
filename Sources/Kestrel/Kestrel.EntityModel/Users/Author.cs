using Kestrel.EntityModel.Ffoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.KestrelMusicUser
{
  public  class Author:IEntity
    {
        public Guid ID { get; set; }
        //作者名称
        public string Name { get; set; }
        //作者简介
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

   
    }
}
