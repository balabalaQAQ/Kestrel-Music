﻿using Kestrel.EntityModel.Attachments;
using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Music
{
    //歌曲、单曲
    public class MusicSingle : IEntity
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

        //歌手
        public virtual Singer Singer { get; set; }

        //作者（原创作者、原唱）
        public virtual Author Author { get; set; }

        //收听级别 
        public ListenLevel ListenLevel { get; set; }

        //售价
        public decimal Price { get; set; } 
        
        //音乐文件
        public virtual BusinessFile MusicFile { get; set; }

        //音乐图片
        public virtual BusinessImage MusicImage{ get; set; }

        //音乐视频
        public virtual BusinessVideo MusicVideo { get; set; }

        public Album Album { get; set; }

    }
}
