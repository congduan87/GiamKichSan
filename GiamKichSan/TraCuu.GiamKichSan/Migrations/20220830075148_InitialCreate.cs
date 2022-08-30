using Microsoft.EntityFrameworkCore.Migrations;

namespace TraCuu.GiamKichSan.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TraCuu_PersionCommunity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    WorkCategoryID = table.Column<int>(type: "int", nullable: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraCuu_PersionCommunity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TraCuu_PersionCommunityMedia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaType = table.Column<int>(type: "int", nullable: false),
                    PersionCommunityID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraCuu_PersionCommunityMedia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TraCuu_WorkCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraCuu_WorkCategory", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraCuu_PersionCommunity");

            migrationBuilder.DropTable(
                name: "TraCuu_PersionCommunityMedia");

            migrationBuilder.DropTable(
                name: "TraCuu_WorkCategory");
        }
    }
}
