using Kestrel.EntityModel.Ffoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.KestrelMusicUser
{
    public class KestrelMusicUser : IEntity
    {
        public Guid ID { get; set; }
        //名字
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }


    }
}
