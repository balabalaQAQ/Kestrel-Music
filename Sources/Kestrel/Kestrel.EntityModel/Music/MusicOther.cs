using Kestrel.EntityModel.Ffoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Music
{
    //音乐的拓展功能
    public class MusicOther : IEntity
    {
        public Guid ID { get; set; }
        //名字
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }
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
