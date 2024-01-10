using Microsoft.EntityFrameworkCore.Migrations;

namespace odev.webui.Migrations
{
    public partial class RemoveExtraColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Odevler",
                table: "Odevler");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Odevler");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Odevler");

            migrationBuilder.DropColumn(
                name: "Baslik",
                table: "Odevler");

            migrationBuilder.RenameColumn(
                name: "Ad",
                table: "Odevler",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Odevler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Odevler",
                table: "Odevler",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Odevler",
                table: "Odevler");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Odevler",
                newName: "Ad");

            migrationBuilder.AlterColumn<int>(
                name: "Ad",
                table: "Odevler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Odevler",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Odevler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Baslik",
                table: "Odevler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Odevler",
                table: "Odevler",
                column: "Id");
        }
    }
}
