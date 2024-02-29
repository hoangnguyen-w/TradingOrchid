using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradingOrchid.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrchidProducts",
                columns: table => new
                {
                    OrchidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrchidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrchidProducts", x => x.OrchidID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(1024)", maxLength: 1024, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(1024)", maxLength: 1024, nullable: false),
                    WalletBalance = table.Column<float>(type: "real", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterAuctions",
                columns: table => new
                {
                    BidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Deposit = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterAuctions", x => x.BidID);
                    table.ForeignKey(
                        name: "FK_RegisterAuctions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Autions",
                columns: table => new
                {
                    AutionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingBid = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxBid = table.Column<float>(type: "real", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BidID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autions", x => x.AutionID);
                    table.ForeignKey(
                        name: "FK_Autions_RegisterAuctions_BidID",
                        column: x => x.BidID,
                        principalTable: "RegisterAuctions",
                        principalColumn: "BidID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    InformationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InformationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InformationCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutionID = table.Column<int>(type: "int", nullable: false),
                    OrchidID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.InformationID);
                    table.ForeignKey(
                        name: "FK_Informations_Autions_AutionID",
                        column: x => x.AutionID,
                        principalTable: "Autions",
                        principalColumn: "AutionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informations_OrchidProducts_OrchidID",
                        column: x => x.OrchidID,
                        principalTable: "OrchidProducts",
                        principalColumn: "OrchidID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AutionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Autions_AutionID",
                        column: x => x.AutionID,
                        principalTable: "Autions",
                        principalColumn: "AutionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentMsg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCheckBool = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    InformationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Informations_InformationID",
                        column: x => x.InformationID,
                        principalTable: "Informations",
                        principalColumn: "InformationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    Quanlity = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    OrchidID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrchidProducts_OrchidID",
                        column: x => x.OrchidID,
                        principalTable: "OrchidProducts",
                        principalColumn: "OrchidID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderDetailID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_OrderDetails_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer" },
                    { 3, "Manager" },
                    { 4, "Orchid Owner" },
                    { 5, "Staff" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "PasswordHash", "PasswordSalt", "Phone", "RefreshToken", "RoleID", "Status", "TokenCreated", "TokenExpires", "UserName", "WalletBalance" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", new byte[] { 52, 165, 111, 146, 202, 69, 155, 210, 81, 74, 5, 91, 210, 6, 119, 123, 28, 76, 40, 138, 191, 74, 224, 115, 5, 80, 2, 31, 212, 202, 176, 145, 128, 1, 229, 2, 46, 38, 229, 71, 186, 145, 210, 39, 12, 176, 223, 219, 84, 106, 55, 107, 45, 134, 59, 124, 157, 168, 169, 112, 93, 137, 222, 4 }, new byte[] { 101, 44, 230, 168, 64, 153, 155, 120, 76, 227, 187, 10, 107, 139, 45, 126, 198, 242, 111, 74, 61, 201, 17, 93, 7, 137, 52, 93, 1, 115, 146, 116, 215, 153, 225, 116, 19, 203, 17, 30, 209, 73, 7, 49, 152, 163, 40, 31, 66, 245, 26, 109, 14, 181, 30, 145, 51, 166, 179, 96, 4, 72, 105, 134, 9, 214, 81, 10, 158, 163, 101, 84, 32, 243, 193, 123, 30, 203, 141, 83, 0, 121, 31, 44, 130, 116, 191, 229, 183, 44, 243, 236, 2, 125, 30, 252, 178, 170, 97, 248, 214, 86, 115, 206, 102, 47, 11, 106, 63, 158, 107, 189, 77, 185, 150, 252, 56, 254, 145, 230, 39, 218, 254, 28, 114, 158, 205, 161 }, null, null, 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f },
                    { 2, "customer@gmail.com", new byte[] { 138, 126, 159, 184, 183, 99, 203, 19, 181, 106, 48, 84, 149, 113, 77, 93, 70, 211, 43, 175, 197, 188, 226, 137, 53, 32, 62, 116, 64, 151, 239, 120, 203, 119, 109, 193, 65, 144, 47, 216, 17, 17, 143, 175, 217, 255, 48, 145, 192, 231, 94, 234, 202, 224, 144, 67, 67, 81, 108, 247, 193, 207, 221, 33 }, new byte[] { 6, 148, 91, 47, 223, 37, 46, 13, 193, 29, 188, 9, 5, 168, 205, 209, 133, 167, 102, 95, 75, 158, 64, 183, 118, 46, 65, 190, 125, 77, 238, 102, 247, 246, 59, 84, 0, 7, 46, 210, 242, 211, 134, 34, 119, 133, 40, 181, 200, 159, 242, 180, 1, 107, 137, 123, 184, 29, 183, 16, 138, 171, 72, 103, 45, 60, 122, 26, 30, 35, 213, 218, 75, 223, 217, 202, 131, 120, 45, 97, 134, 119, 31, 5, 129, 65, 234, 180, 150, 97, 91, 231, 248, 4, 220, 91, 75, 102, 190, 201, 178, 252, 218, 206, 55, 241, 41, 147, 234, 215, 216, 54, 137, 72, 46, 55, 23, 41, 66, 162, 139, 175, 66, 199, 49, 71, 167, 94 }, null, null, 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f },
                    { 3, "manager@gmail.com", new byte[] { 178, 33, 230, 34, 129, 196, 20, 233, 245, 83, 163, 242, 41, 34, 27, 209, 37, 243, 79, 126, 50, 100, 60, 9, 39, 66, 144, 184, 191, 89, 25, 138, 96, 73, 138, 250, 52, 95, 168, 130, 149, 195, 3, 26, 175, 228, 171, 184, 63, 149, 49, 228, 17, 150, 237, 156, 99, 157, 106, 71, 163, 212, 8, 228 }, new byte[] { 229, 63, 184, 79, 68, 174, 87, 160, 43, 218, 100, 50, 65, 109, 218, 124, 38, 100, 201, 15, 33, 22, 172, 158, 123, 18, 186, 59, 58, 109, 105, 215, 22, 119, 219, 245, 205, 179, 222, 168, 0, 144, 48, 187, 172, 54, 203, 67, 170, 29, 94, 234, 113, 2, 217, 255, 244, 98, 118, 189, 8, 60, 12, 250, 87, 219, 75, 185, 171, 209, 17, 254, 30, 49, 51, 213, 42, 47, 152, 105, 150, 121, 219, 114, 6, 57, 139, 187, 173, 86, 4, 63, 2, 144, 139, 46, 252, 141, 202, 96, 227, 202, 154, 212, 182, 7, 156, 208, 133, 180, 252, 204, 217, 121, 57, 62, 41, 198, 140, 42, 162, 83, 209, 140, 3, 166, 194, 174 }, null, null, 3, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f },
                    { 4, "orchidowner@gmail.com", new byte[] { 103, 255, 208, 129, 166, 255, 209, 241, 63, 163, 63, 206, 23, 157, 95, 113, 172, 146, 69, 204, 22, 141, 56, 142, 237, 43, 232, 150, 25, 89, 49, 153, 194, 37, 108, 8, 0, 104, 192, 5, 255, 62, 137, 227, 91, 204, 167, 19, 144, 214, 233, 221, 215, 230, 196, 61, 71, 219, 174, 157, 101, 9, 236, 155 }, new byte[] { 25, 72, 36, 180, 249, 219, 91, 107, 93, 60, 81, 171, 238, 182, 146, 6, 73, 68, 124, 209, 209, 163, 69, 5, 19, 57, 186, 233, 236, 116, 36, 43, 34, 246, 54, 45, 194, 102, 222, 217, 74, 49, 70, 36, 24, 124, 5, 63, 60, 11, 225, 180, 94, 75, 211, 189, 109, 187, 204, 17, 74, 85, 235, 50, 207, 208, 74, 29, 57, 138, 51, 83, 120, 235, 58, 109, 140, 234, 237, 25, 135, 141, 228, 17, 239, 229, 138, 93, 91, 142, 227, 63, 26, 163, 38, 228, 138, 230, 86, 168, 175, 107, 252, 6, 208, 215, 32, 204, 141, 99, 198, 168, 48, 41, 245, 214, 38, 28, 9, 47, 80, 160, 60, 76, 7, 146, 174, 201 }, null, null, 4, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f },
                    { 5, "staff@gmail.com", new byte[] { 139, 197, 7, 8, 233, 47, 245, 227, 190, 78, 76, 35, 121, 25, 29, 86, 250, 59, 212, 25, 250, 239, 216, 10, 40, 64, 18, 42, 37, 225, 109, 104, 214, 72, 121, 9, 155, 31, 113, 255, 178, 49, 211, 111, 228, 37, 154, 135, 33, 97, 138, 153, 151, 110, 51, 5, 247, 30, 173, 147, 214, 124, 102, 240 }, new byte[] { 197, 156, 146, 8, 166, 170, 116, 162, 205, 4, 105, 60, 217, 213, 240, 41, 142, 226, 255, 53, 81, 95, 151, 41, 150, 27, 14, 14, 160, 226, 179, 226, 45, 192, 109, 72, 177, 197, 220, 76, 66, 206, 70, 39, 69, 149, 153, 88, 0, 246, 36, 71, 23, 78, 153, 98, 43, 174, 162, 198, 4, 252, 49, 97, 191, 232, 88, 64, 28, 113, 173, 248, 117, 52, 71, 54, 76, 43, 134, 115, 181, 2, 43, 225, 110, 9, 124, 106, 18, 124, 10, 174, 26, 142, 143, 52, 57, 97, 143, 209, 244, 129, 208, 47, 147, 255, 195, 164, 230, 50, 4, 93, 108, 59, 37, 140, 126, 250, 66, 52, 231, 245, 65, 205, 146, 78, 226, 29 }, null, null, 5, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autions_BidID",
                table: "Autions",
                column: "BidID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_InformationID",
                table: "Comments",
                column: "InformationID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_AutionID",
                table: "Informations",
                column: "AutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_OrchidID",
                table: "Informations",
                column: "OrchidID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrchidID",
                table: "OrderDetails",
                column: "OrchidID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AutionID",
                table: "Orders",
                column: "AutionID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterAuctions_UserID",
                table: "RegisterAuctions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OrderDetailID",
                table: "Transactions",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrchidProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Autions");

            migrationBuilder.DropTable(
                name: "RegisterAuctions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
