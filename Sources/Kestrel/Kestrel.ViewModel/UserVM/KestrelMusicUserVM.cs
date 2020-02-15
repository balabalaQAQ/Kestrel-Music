using Kestrel.EntityModel.Music;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Kestrel.ViewModel.UserVM
{
   public class KestrelMusicUserVM:EntityViewModel
    {
        public string UserNameVM { get; set; }
        public virtual ICollection<SongSheet> MySongSheet { get; set; }

        public virtual ICollection<KestrelMusicUserVM> MyLoveUser { get; set; }

        public virtual ICollection<Album> MyAlbum { get; set; }
    }
}
