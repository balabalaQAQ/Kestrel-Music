using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.KestrelMusicUser;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kestrel.EntityModel.Music
{
    public class Album :IEntity
    {
        [Key]
        public Guid ID { get; set; }

        [StringLength(100)]
        //专辑名称
        public string Name { get; set; }

        [StringLength(500)]
        //专辑描述
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }
        //售价
        public decimal Price { get; set; }

        public virtual MusicOther MusicOther { get; set; }

        public Author Author { get; set; }

    }
}
