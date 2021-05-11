﻿// <auto-generated />
using System;
using Kestrel.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kestrel.ORM.Migrations
{
    [DbContext(typeof(KestrelDbcontext))]
    [Migration("20200216042604_KestrelMusicData")]
    partial class KestrelMusicData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kestrel.EntityModel.Attachments.BusinessFile", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AttachmentTimeUploaded")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("BinaryContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("IconString")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<bool>("IsInDB")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OriginalFileName")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<Guid>("RelevanceObjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UploadFileSuffix")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("UploadPath")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<Guid>("UploaderID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BusinessFile");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Attachments.BusinessImage", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("IconString")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<bool>("IsAvatar")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForTitle")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MusicSingleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OriginalFileName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<Guid>("RelevanceObjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SongSheetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UploadFileSuffix")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("UploadPath")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UploadedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UploaderID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("MusicSingleID");

                    b.HasIndex("SongSheetID");

                    b.ToTable("BusinessImage");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Attachments.BusinessVideo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AttachmentTimeUploaded")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("BinaryContent")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("IconString")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<bool>("IsInDB")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnique")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OriginalFileName")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<Guid>("RelevanceObjectID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UploadFileSuffix")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("UploadPath")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<Guid>("UploaderID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("BusinessVideo");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.Album", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AddPlay")
                        .HasColumnType("int");

                    b.Property<int>("AddThumb")
                        .HasColumnType("int");

                    b.Property<int>("AddTread")
                        .HasColumnType("int");

                    b.Property<int>("Addlike")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KestrelMusicUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("KestrelMusicUserID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.AlbumGenre", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("AlbumGenre");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.MusicSingle", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AddPlay")
                        .HasColumnType("int");

                    b.Property<int>("AddThumb")
                        .HasColumnType("int");

                    b.Property<int>("AddTread")
                        .HasColumnType("int");

                    b.Property<int>("Addlike")
                        .HasColumnType("int");

                    b.Property<Guid?>("AuthorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IfOriginal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<int>("ListenLevel")
                        .HasColumnType("int");

                    b.Property<Guid?>("MusicFileID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MusicVideoID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("SingerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SongSheetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("MusicFileID");

                    b.HasIndex("MusicVideoID");

                    b.HasIndex("SingerID");

                    b.HasIndex("SongSheetID");

                    b.ToTable("MusicSingle");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.RadioStation", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumGenreID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AlbumGenreID");

                    b.ToTable("RadioStation");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.SongSheet", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AddPlay")
                        .HasColumnType("int");

                    b.Property<int>("AddThumb")
                        .HasColumnType("int");

                    b.Property<int>("AddTread")
                        .HasColumnType("int");

                    b.Property<int>("Addlike")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("SingerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserID1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("SingerID");

                    b.HasIndex("UserID1");

                    b.ToTable("SongSheet");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Users.Author", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Users.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MusicSingleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentReplyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RadioStationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SongSheetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.HasIndex("MusicSingleID");

                    b.HasIndex("ParentReplyID");

                    b.HasIndex("RadioStationID");

                    b.HasIndex("SongSheetID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Users.KestrelMusicUser", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<Guid?>("KestrelMusicUserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KestrelMusicUserID");

                    b.ToTable("KestrelMusicUser");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Users.Singer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPseudoDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SortCode")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Singer");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Attachments.BusinessImage", b =>
                {
                    b.HasOne("Kestrel.EntityModel.Music.Album", null)
                        .WithMany("MusicImage")
                        .HasForeignKey("AlbumID");

                    b.HasOne("Kestrel.EntityModel.Music.MusicSingle", null)
                        .WithMany("MusicImage")
                        .HasForeignKey("MusicSingleID");

                    b.HasOne("Kestrel.EntityModel.Music.SongSheet", null)
                        .WithMany("MusicImage")
                        .HasForeignKey("SongSheetID");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.Album", b =>
                {
                    b.HasOne("Kestrel.EntityModel.Users.KestrelMusicUser", null)
                        .WithMany("MyAlbum")
                        .HasForeignKey("KestrelMusicUserID");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.MusicSingle", b =>
                {
                    b.HasOne("Kestrel.EntityModel.Users.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID");

                    b.HasOne("Kestrel.EntityModel.Attachments.BusinessFile", "MusicFile")
                        .WithMany()
                        .HasForeignKey("MusicFileID");

                    b.HasOne("Kestrel.EntityModel.Attachments.BusinessVideo", "MusicVideo")
                        .WithMany()
                        .HasForeignKey("MusicVideoID");

                    b.HasOne("Kestrel.EntityModel.Users.Singer", "Singer")
                        .WithMany("MusicSingles")
                        .HasForeignKey("SingerID");

                    b.HasOne("Kestrel.EntityModel.Music.SongSheet", null)
                        .WithMany("MusicSingle")
                        .HasForeignKey("SongSheetID");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.RadioStation", b =>
                {
                    b.HasOne("Kestrel.EntityModel.Music.AlbumGenre", "AlbumGenre")
                        .WithMany()
                        .HasForeignKey("AlbumGenreID");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Music.SongSheet", b =>
                {
                    b.HasOne("Kestrel.EntityModel.Users.Singer", null)
                        .WithMany("SongSheets")
                        .HasForeignKey("SingerID");

                    b.HasOne("Kestrel.EntityModel.Users.KestrelMusicUser", "User")
                        .WithMany("MySongSheet")
                        .HasForeignKey("UserID1");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Users.Comment", b =>
                {
                    b.HasOne("Kestrel.EntityModel.Music.Album", "Album")
                        .WithMany()
                        .HasForeignKey("AlbumID");

                    b.HasOne("Kestrel.EntityModel.Music.MusicSingle", "MusicSingle")
                        .WithMany()
                        .HasForeignKey("MusicSingleID");

                    b.HasOne("Kestrel.EntityModel.Users.Comment", "ParentReply")
                        .WithMany()
                        .HasForeignKey("ParentReplyID");

                    b.HasOne("Kestrel.EntityModel.Music.RadioStation", "RadioStation")
                        .WithMany()
                        .HasForeignKey("RadioStationID");

                    b.HasOne("Kestrel.EntityModel.Music.SongSheet", "SongSheet")
                        .WithMany("Comment")
                        .HasForeignKey("SongSheetID");
                });

            modelBuilder.Entity("Kestrel.EntityModel.Users.KestrelMusicUser", b =>
                {
                    b.HasOne("Kestrel.EntityModel.Users.KestrelMusicUser", null)
                        .WithMany("MyLoveUser")
                        .HasForeignKey("KestrelMusicUserID");
                });
#pragma warning restore 612, 618
        }
    }
}