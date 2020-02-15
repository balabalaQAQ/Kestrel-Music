using Kestrel.EntityModel.Music;
using Kestrel.EntityModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kestrel.ViewModel.MusicVM
{
    public class SongSheetVM:MusicEntityViewModel
    {
        //评论
        public virtual ICollection<Comment> Comment { get; set; }

        //所包含的歌曲
        public virtual ICollection<MusicSingle> MusicSingle { get; set; }

        //创建者
        public virtual KestrelMusicUser User { get; set; }
        public string UserID { get; set; }

    }
}
