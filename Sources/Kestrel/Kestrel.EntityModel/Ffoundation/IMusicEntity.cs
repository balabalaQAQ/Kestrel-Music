using Kestrel.EntityModel.Attachments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Ffoundation
{
     public interface IMusicEntity : IEntity 
    {
        //音乐图片
        public ICollection<BusinessImage> MusicImage { get; set; }

        //累计播放次数
        public int AddPlay { get; set; }

        //累计喜欢♥
        public int Addlike { get; set; }

        //累计赞👍

        public int AddThumb { get; set; }

        //累计踩👎
        public int AddTread { get; set; }


    }
}
