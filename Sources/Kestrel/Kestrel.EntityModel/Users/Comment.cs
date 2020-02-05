using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.Music;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Users
{
    //评论
    public class Comment : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }
        public Guid ID { get; set; }

        public string Content { get; set; }//评论内容

        public virtual User User { get; set; }//所属用户

        public virtual Album Album { get; set; }//所属专辑

        public virtual MusicSingle MusicSingle { get; set; }//所属歌曲

        public virtual RadioStation RadioStation { get; set; }//所属电台

        public virtual SongSheet SongSheet { get; set; }//所属歌单

        public DateTime CommentTime { get; set; }//评论时间

        public virtual Comment ParentReply { get; set; }   //上级回复

        public DateTime CreateDateTime { get; set; }  //回复时间
    }
}
