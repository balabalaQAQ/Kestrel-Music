using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kestrel.ORM.Migrations
{
    public partial class KestrelMusicData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumGenre",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumGenre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessFile",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    AttachmentTimeUploaded = table.Column<DateTime>(nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 500, nullable: true),
                    UploadPath = table.Column<string>(maxLength: 500, nullable: true),
                    IsInDB = table.Column<bool>(nullable: false),
                    UploadFileSuffix = table.Column<string>(maxLength: 10, nullable: true),
                    BinaryContent = table.Column<byte[]>(nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    IconString = table.Column<string>(maxLength: 120, nullable: true),
                    IsUnique = table.Column<bool>(nullable: false),
                    RelevanceObjectID = table.Column<Guid>(nullable: false),
                    UploaderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessFile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessVideo",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    AttachmentTimeUploaded = table.Column<DateTime>(nullable: false),
                    OriginalFileName = table.Column<string>(maxLength: 500, nullable: true),
                    UploadPath = table.Column<string>(maxLength: 500, nullable: true),
                    IsInDB = table.Column<bool>(nullable: false),
                    UploadFileSuffix = table.Column<string>(maxLength: 10, nullable: true),
                    BinaryContent = table.Column<byte[]>(nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    IconString = table.Column<string>(maxLength: 120, nullable: true),
                    IsUnique = table.Column<bool>(nullable: false),
                    RelevanceObjectID = table.Column<Guid>(nullable: false),
                    UploaderID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessVideo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KestrelMusicUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    KestrelMusicUserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KestrelMusicUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KestrelMusicUser_KestrelMusicUser_KestrelMusicUserID",
                        column: x => x.KestrelMusicUserID,
                        principalTable: "KestrelMusicUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Singer",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RadioStation",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    AlbumGenreID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadioStation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RadioStation_AlbumGenre_AlbumGenreID",
                        column: x => x.AlbumGenreID,
                        principalTable: "AlbumGenre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    AddPlay = table.Column<int>(nullable: false),
                    Addlike = table.Column<int>(nullable: false),
                    AddThumb = table.Column<int>(nullable: false),
                    AddTread = table.Column<int>(nullable: false),
                    KestrelMusicUserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Album_KestrelMusicUser_KestrelMusicUserID",
                        column: x => x.KestrelMusicUserID,
                        principalTable: "KestrelMusicUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SongSheet",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    AddPlay = table.Column<int>(nullable: false),
                    Addlike = table.Column<int>(nullable: false),
                    AddThumb = table.Column<int>(nullable: false),
                    AddTread = table.Column<int>(nullable: false),
                    UserID1 = table.Column<Guid>(nullable: true),
                    UserID = table.Column<string>(nullable: true),
                    SingerID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongSheet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SongSheet_Singer_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongSheet_KestrelMusicUser_UserID1",
                        column: x => x.UserID1,
                        principalTable: "KestrelMusicUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicSingle",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    CreatTime = table.Column<DateTime>(nullable: false),
                    AddPlay = table.Column<int>(nullable: false),
                    Addlike = table.Column<int>(nullable: false),
                    AddThumb = table.Column<int>(nullable: false),
                    AddTread = table.Column<int>(nullable: false),
                    SingerID = table.Column<Guid>(nullable: true),
                    AuthorID = table.Column<Guid>(nullable: true),
                    ListenLevel = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    IfOriginal = table.Column<bool>(nullable: false),
                    MusicFileID = table.Column<Guid>(nullable: true),
                    MusicVideoID = table.Column<Guid>(nullable: true),
                    SongSheetID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicSingle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MusicSingle_Author_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Author",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicSingle_BusinessFile_MusicFileID",
                        column: x => x.MusicFileID,
                        principalTable: "BusinessFile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicSingle_BusinessVideo_MusicVideoID",
                        column: x => x.MusicVideoID,
                        principalTable: "BusinessVideo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicSingle_Singer_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicSingle_SongSheet_SongSheetID",
                        column: x => x.SongSheetID,
                        principalTable: "SongSheet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessImage",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    SortCode = table.Column<string>(maxLength: 100, nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: true),
                    OriginalFileName = table.Column<string>(maxLength: 256, nullable: true),
                    UploadedTime = table.Column<DateTime>(nullable: false),
                    UploadPath = table.Column<string>(maxLength: 256, nullable: true),
                    UploadFileSuffix = table.Column<string>(maxLength: 256, nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    IconString = table.Column<string>(maxLength: 120, nullable: true),
                    IsForTitle = table.Column<bool>(nullable: false),
                    IsUnique = table.Column<bool>(nullable: false),
                    IsAvatar = table.Column<bool>(nullable: false),
                    RelevanceObjectID = table.Column<Guid>(nullable: false),
                    UploaderID = table.Column<Guid>(nullable: false),
                    AlbumID = table.Column<Guid>(nullable: true),
                    MusicSingleID = table.Column<Guid>(nullable: true),
                    SongSheetID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessImage_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImage_MusicSingle_MusicSingleID",
                        column: x => x.MusicSingleID,
                        principalTable: "MusicSingle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessImage_SongSheet_SongSheetID",
                        column: x => x.SongSheetID,
                        principalTable: "SongSheet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SortCode = table.Column<string>(nullable: true),
                    IsPseudoDelete = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    AlbumID = table.Column<Guid>(nullable: true),
                    MusicSingleID = table.Column<Guid>(nullable: true),
                    RadioStationID = table.Column<Guid>(nullable: true),
                    SongSheetID = table.Column<Guid>(nullable: true),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    ParentReplyID = table.Column<Guid>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_MusicSingle_MusicSingleID",
                        column: x => x.MusicSingleID,
                        principalTable: "MusicSingle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentReplyID",
                        column: x => x.ParentReplyID,
                        principalTable: "Comment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_RadioStation_RadioStationID",
                        column: x => x.RadioStationID,
                        principalTable: "RadioStation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_SongSheet_SongSheetID",
                        column: x => x.SongSheetID,
                        principalTable: "SongSheet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_KestrelMusicUserID",
                table: "Album",
                column: "KestrelMusicUserID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImage_AlbumID",
                table: "BusinessImage",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImage_MusicSingleID",
                table: "BusinessImage",
                column: "MusicSingleID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessImage_SongSheetID",
                table: "BusinessImage",
                column: "SongSheetID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AlbumID",
                table: "Comment",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MusicSingleID",
                table: "Comment",
                column: "MusicSingleID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentReplyID",
                table: "Comment",
                column: "ParentReplyID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RadioStationID",
                table: "Comment",
                column: "RadioStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_SongSheetID",
                table: "Comment",
                column: "SongSheetID");

            migrationBuilder.CreateIndex(
                name: "IX_KestrelMusicUser_KestrelMusicUserID",
                table: "KestrelMusicUser",
                column: "KestrelMusicUserID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicSingle_AuthorID",
                table: "MusicSingle",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicSingle_MusicFileID",
                table: "MusicSingle",
                column: "MusicFileID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicSingle_MusicVideoID",
                table: "MusicSingle",
                column: "MusicVideoID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicSingle_SingerID",
                table: "MusicSingle",
                column: "SingerID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicSingle_SongSheetID",
                table: "MusicSingle",
                column: "SongSheetID");

            migrationBuilder.CreateIndex(
                name: "IX_RadioStation_AlbumGenreID",
                table: "RadioStation",
                column: "AlbumGenreID");

            migrationBuilder.CreateIndex(
                name: "IX_SongSheet_SingerID",
                table: "SongSheet",
                column: "SingerID");

            migrationBuilder.CreateIndex(
                name: "IX_SongSheet_UserID1",
                table: "SongSheet",
                column: "UserID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessImage");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "MusicSingle");

            migrationBuilder.DropTable(
                name: "RadioStation");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "BusinessFile");

            migrationBuilder.DropTable(
                name: "BusinessVideo");

            migrationBuilder.DropTable(
                name: "SongSheet");

            migrationBuilder.DropTable(
                name: "AlbumGenre");

            migrationBuilder.DropTable(
                name: "Singer");

            migrationBuilder.DropTable(
                name: "KestrelMusicUser");
        }
    }
}
