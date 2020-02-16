using Kestrel.EntityModel.Ffoundation;
using Kestrel.EntityModel.Music;
using Kestrel.EntityModel.Tools;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kestrel.EntityModel.Users
{

    public class KestrelMusicUser :  Entity
    {
       
        public string UserName { get; set; }
        public virtual ICollection<SongSheet> MySongSheet { get; set; }

        public virtual ICollection<KestrelMusicUser> MyLoveUser { get; set; }

        public virtual ICollection<Album> MyAlbum { get; set; }
        public KestrelMusicUser() : base()
        {
            this.ID = Guid.NewGuid();
            this.SortCode = EntityHelper.SortCodeByDefaultDateTime<KestrelMusicUser>();
        }
       
    }
}
