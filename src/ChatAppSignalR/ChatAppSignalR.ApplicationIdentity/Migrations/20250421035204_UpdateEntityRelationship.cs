using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatAppSignalR.ApplicationIdentity.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserConnections_AspNetUsers_ConnectedUserId",
                table: "UserConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_UserConnections_AspNetUsers_UserId",
                table: "UserConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_IdentityUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserConnections_ConnectedUserId",
                table: "UserConnections");

            migrationBuilder.DropIndex(
                name: "IX_UserConnections_UserId",
                table: "UserConnections");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserConnections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ConnectedUserId",
                table: "UserConnections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserConnections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ConnectedUserId",
                table: "UserConnections",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnections_ConnectedUserId",
                table: "UserConnections",
                column: "ConnectedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConnections_UserId",
                table: "UserConnections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserConnections_AspNetUsers_ConnectedUserId",
                table: "UserConnections",
                column: "ConnectedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserConnections_AspNetUsers_UserId",
                table: "UserConnections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_IdentityUserId",
                table: "Users",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
