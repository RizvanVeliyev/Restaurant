using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddParentIdToBlogComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "BlogComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_ParentId",
                table: "BlogComments",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogComments_ParentId",
                table: "BlogComments",
                column: "ParentId",
                principalTable: "BlogComments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogComments_ParentId",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_ParentId",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "BlogComments");
        }
    }
}
