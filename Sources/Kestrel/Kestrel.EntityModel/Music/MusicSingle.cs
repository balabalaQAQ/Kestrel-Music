using Kestrel.EntityModel.Attachments;
using Kestrel.EntityModel.Ffoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Music
{
    public class MusicSingle : IEntity
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public bool IsPseudoDelete { get; set; }

        //作者
        public string Author { get; set; }

        //收听级别
        public ListenLevel ListenLevel { get; set; }

        //售价
        public double Price { get; set; } = 0.00;
        
        //音乐文件
        public BusinessFile MusicFile { get; set; }

        //音乐图片
        public BusinessImage MusicImage{ get; set; }


        //音乐视频
        public BusinessVideo MusicVideo { get; set; }

        
       



    }
}
