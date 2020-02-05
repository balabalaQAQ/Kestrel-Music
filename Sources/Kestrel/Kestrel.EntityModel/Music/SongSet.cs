using Kestrel.EntityModel.Attachments;
using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.Music;
using Kestrel.EntityModel.Tools;
using Kestrel.EntityModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kestrel.EntityModel
{
    //歌单
    public class SongSheet : IEntity
    {
        [Key]
        public Guid ID { get; set; }
        //歌集名称
        [StringLength(100)]
        public string Name { get; set; }
        //歌单描述
        [StringLength(500)]
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

        //创建时间
        public DateTime CreatTime { get; set; }

        public virtual MusicOther MusicOther { get; set; }

        //歌集图片
        public virtual BusinessImage BusinessImage { get; set; }

        //评论
        public virtual ICollection<Comment> Comment { get; set; }

        //所包含的歌曲
        public virtual MusicSingle MusicSingle { get; set; }

        //作者
        public virtual Author Author { get; set; }

        public string AuthorID { get; set; }
        public SongSheet()
        {
            this.ID = new Guid();
            this.CreatTime = DateTime.Now;
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<SongSheet>();
        }

    }
}
