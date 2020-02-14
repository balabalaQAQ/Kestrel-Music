﻿using Kestrel.EntityModel.Music;
using Kestrel.EntityModel.KestrelMusicUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kestrel.ORM
{
    public class KestrelDbcontext : DbContext

    {

        #region 用户角色实体
        public DbSet<KestrelMusicUser> KestrelMusicUser { get; set; }
        #endregion

        #region 音乐相关实体

        public DbSet<Album> Album { get; set; }
        public DbSet<MusicSingle> MusicSingle { get; set; }

        public DbSet<RadioStation> RadioStation { get; set; }

        public DbSet<SongSheet> SongSheet { get; set; }

        public DbSet<MusicOther> MusicOther { get; set; }


        public DbSet<AlbumGenre> AlbumGenre { get; set; }
        public DbSet<RadioStation> SongGenre { get; set; }

        #endregion
    }
}
