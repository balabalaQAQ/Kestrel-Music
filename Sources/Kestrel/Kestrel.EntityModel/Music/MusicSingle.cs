using Kestrel.EntityModel.Attachments;
using Kestrel.EntityModel.Ffoundation;
 
using Kestrel.EntityModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Music
{
    /// <summary>
    /// 歌曲、单曲
    /// </summary>
    public class MusicSingle :MusicEntity
    {
      
        //歌手
        public virtual Singer Singer { get; set; }

        //作者（原创作者、原唱）
        public virtual Author Author { get; set; }

        //收听级别 
        public ListenLevel ListenLevel { get; set; }

        //售价
        public decimal Price { get; set; }

        //是否原创
        public bool IfOriginal { get; set; }
    
        //音乐文件
        public virtual BusinessFile MusicFile { get; set; }

        //音乐视频
        public virtual BusinessVideo MusicVideo { get; set; }

    
        //所属专辑
      //  public virtual Album Album { get; set; }

    }
}
