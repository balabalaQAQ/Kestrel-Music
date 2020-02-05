﻿using Kestrel.EntityModel.Ffoundation;
 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kestrel.EntityModel.Music
{
    //专辑类别
   public class AlbumGenre:IEntity
    {
        [Key]
        public Guid ID { get; set; }

        [StringLength(100)]
        //类别名称
        public string Name { get; set; }
      
        [StringLength(500)]
        //专辑描述
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

     
    }
}
