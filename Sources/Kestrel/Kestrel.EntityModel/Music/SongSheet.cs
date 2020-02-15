using Kestrel.EntityModel.Attachments;
using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.Music;
using Kestrel.EntityModel.Tools;
using Kestrel.EntityModel.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kestrel.EntityModel.Music
{
    /// <summary>
    /// 歌单
    /// </summary>
    public class SongSheet :MusicEntity
    { 
        //评论
        public virtual ICollection<Comment> Comment { get; set; }

        //所包含的歌曲
        public virtual ICollection<MusicSingle> MusicSingle { get; set; }
 
        //创建者
        public virtual KestrelMusicUser User { get; set; }
        public string UserID { get; set; }
        public SongSheet()
        {
            this.ID = new Guid();
            this.CreatTime = DateTime.Now;
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<SongSheet>();
        }

    }
}
