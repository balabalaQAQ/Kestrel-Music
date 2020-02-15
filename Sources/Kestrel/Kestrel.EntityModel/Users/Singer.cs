using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.Music;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.EntityModel.Users
{
    /// <summary>
    /// 歌手
    /// </summary>
    public class Singer:Entity
    {
        //所著歌
        public virtual ICollection<MusicSingle> MusicSingles { get; set; }
   
        public virtual ICollection<SongSheet> SongSheets { get; set; }
      
    }
}
