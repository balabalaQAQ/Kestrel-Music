using Kestrel.EntityModel.Ffoundation;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kestrel.EntityModel.Music
{
    /// <summary>
    /// 电台
    /// </summary>
    public class RadioStation:IEntity
    {
        [Key]
        public Guid ID { get; set; }
        //电台名称
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

        //售价
        public decimal Price { get; set; }
        //所属用户
     //   public  User User { get; set; }

        //类别
        public virtual AlbumGenre AlbumGenre { get; set; }

      
    }
}
