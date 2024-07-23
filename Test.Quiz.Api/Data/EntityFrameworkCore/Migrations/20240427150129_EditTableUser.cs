using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Quiz.Api.Data.EntityFrameworkCore.Migrations
{
    public partial class EditTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("1a3e854a-843d-4e65-ab88-9d5736c831f2") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("c4f97a72-6b4a-47d3-ba1b-6fe15e62c192") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a1") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a6") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b1") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a3e854a-843d-4e65-ab88-9d5736c831f2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4f97a72-6b4a-47d3-ba1b-6fe15e62c192"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b1"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "640f3739-2fbf-4671-896b-8fadbe231a72");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"),
                column: "ConcurrencyStamp",
                value: "d0c01797-59db-4dc9-b3c1-54fd8b28f34c");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c11afd00-0197-4fc1-b414-613373d5cd78");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"),
                column: "ConcurrencyStamp",
                value: "21e0b564-6671-46ae-831b-f38a96f1c253");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AvatarUrl", "BirthDay", "ConcurrencyStamp", "DeletedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1a3e854a-843d-4e65-ab88-9d5736c831f2"), 0, null, "/User/AvatarDefault.png", null, "354c1d79-ad7e-4bd7-9619-dce161344047", null, "nguyenvanthang@gmail.com", true, false, null, "Nguyễn Văn Hà", "nguyenvanthang@gmail.com", "nguyenvanthang", "AQAAAAEAACcQAAAAECCNw/qYarlHSm37LYdXaevlzWjyBi6lPDtf6KyATIZHsODbVLF9ukf1KJAfNli37g==", null, false, "", null, true, false, "nguyenvanthang" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, null, "/User/AvatarDefault.png", null, "55e6f3f9-2f2c-4bb9-9653-33be7c680050", null, "thanga3tqk1821@gmail.com", true, false, null, "Nguyễn Văn Thắng", "thanga3tqk1821@gmail.com", "admin", "AQAAAAEAACcQAAAAEDPySqeliAErnhLwfJVhIDWRxyQCe/niMIGjGLSghRax03ieesJFD97lFz+kSeg0nQ==", null, false, "", null, true, false, "admin" },
                    { new Guid("c4f97a72-6b4a-47d3-ba1b-6fe15e62c192"), 0, null, "/User/AvatarDefault.png", null, "9ebdb367-254f-42f7-bc8d-63fbd7c9ef2c", null, "chienthangvipkc@gmail.com", true, false, null, "Nguyễn Thị Ngọc Anh", "chienthangvipkc@gmail.com", "user", "AQAAAAEAACcQAAAAECHmLBEt+wFOX6+CPHia5KDtkxhYJ2gi5tUqu+utabdNv8GzjwVR7/kyGKOsZk7wVg==", null, false, "", null, true, false, "user" },
                    { new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a1"), 0, null, "/User/AvatarDefault.png", null, "3b10ed8a-634e-4ed2-b9f1-6481d8118e68", null, "daoxuanduc@gmail.com", true, false, null, "Đào Xuân Đức", "daoxuanduc@gmail.com", "daoxuanduc", "AQAAAAEAACcQAAAAEE3ZlKeFkFiEFpBbKM1ruMVf9+uZ4i8jdrWZ906UTeklRFVyfRZ1xAfxICxX8cenoA==", null, false, "", null, true, false, "daoxuanduc" },
                    { new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a2"), 0, null, "/User/AvatarDefault.png", null, "cfaa904a-f9af-4e5b-959a-8581c9ec3016", null, "phamthanhlong@gmail.com", true, false, null, "Phạm Thanh Long", "phamthanhlong@gmail.com", "phamthanhlong", "AQAAAAEAACcQAAAAEHd43xIrupRjYEX+XSYxljC2exq7ciFFqJP5/yW7qRMTCIeFqdmSNTJuVlmbPuLzFg==", "+84922002222", false, "", null, true, false, "phamthanhlong" },
                    { new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a6"), 0, null, "/User/AvatarDefault.png", null, "6adc972e-340f-4cde-88f4-228dcf1c6931", null, "phamxuantuyen@gmail.com", true, false, null, "Phạm Xuân Tuyển", "phamxuantuyen@gmail.com", "phamxuantuyen", "AQAAAAEAACcQAAAAEAxOF6s0Dzh1luJvNjlleOU43Zb7H6Sd0/Dj9m77u43hHk1g/2t1skaUAckFrryHdg==", null, false, "", null, true, false, "phamxuantuyen" },
                    { new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a7"), 0, null, "/User/AvatarDefault.png", null, "464b5431-cfe8-4b22-afd6-149b27c1dd57", null, "buixuanhoang@gmail.com", true, false, null, "Bùi Xuân Hoàng", "buixuanhoang@gmail.com", "buixuanhoang", "AQAAAAEAACcQAAAAECWrAE9AuZpt6CL33FJGCAZL48zGE/VWMtFGLe3kNJMDaYFqXRmL2NJhvqX42U+VTw==", "+84922002111", false, "", null, true, false, "buixuanhoang" },
                    { new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b1"), 0, null, "/User/AvatarDefault.png", null, "716e97e6-6f1c-4bab-b863-914f6b924947", null, "hoanggiabao@gmail.com", true, false, null, "Hoàng Gia Bảo", "hoanggiabao@gmail.com", "hoanggiabao", "AQAAAAEAACcQAAAAEO9HmY1YxtkWu4l4AYylbN6WIpTYl8WRQeSkCViWBQ7j8CW4NWMcMJeNZq/HiEVsHQ==", "+84922002360", false, "", null, true, false, "hoanggiabao" },
                    { new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b2"), 0, null, "/User/AvatarDefault.png", null, "f92f5c85-5027-42bc-8a4e-cdd56d142a46", null, "nguyendinhhung@gmail.com", true, false, null, "Nguyễn Đình Hùng", "nguyendinhhung@gmail.com", "nguyendinhhung", "AQAAAAEAACcQAAAAEAkGvc6UVNeNh/RkfhwjtNcXgTfBb2Jxz8nxPY1dq/p9+QXThGbXdZDS3qIhlQOWPw==", "+84922002333", false, "", null, true, false, "nguyendinhhung" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("1a3e854a-843d-4e65-ab88-9d5736c831f2"), "UserRole" },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), "UserRole" },
                    { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("c4f97a72-6b4a-47d3-ba1b-6fe15e62c192"), "UserRole" },
                    { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a1"), "UserRole" },
                    { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a6"), "UserRole" },
                    { new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"), new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b1"), "UserRole" }
                });
        }
    }
}
