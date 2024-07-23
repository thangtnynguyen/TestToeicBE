using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Quiz.Api.Data.EntityFrameworkCore.Migrations
{
    public partial class EditTableQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Questions",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a3e854a-843d-4e65-ab88-9d5736c831f2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "354c1d79-ad7e-4bd7-9619-dce161344047", "AQAAAAEAACcQAAAAECCNw/qYarlHSm37LYdXaevlzWjyBi6lPDtf6KyATIZHsODbVLF9ukf1KJAfNli37g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55e6f3f9-2f2c-4bb9-9653-33be7c680050", "AQAAAAEAACcQAAAAEDPySqeliAErnhLwfJVhIDWRxyQCe/niMIGjGLSghRax03ieesJFD97lFz+kSeg0nQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4f97a72-6b4a-47d3-ba1b-6fe15e62c192"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ebdb367-254f-42f7-bc8d-63fbd7c9ef2c", "AQAAAAEAACcQAAAAECHmLBEt+wFOX6+CPHia5KDtkxhYJ2gi5tUqu+utabdNv8GzjwVR7/kyGKOsZk7wVg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b10ed8a-634e-4ed2-b9f1-6481d8118e68", "AQAAAAEAACcQAAAAEE3ZlKeFkFiEFpBbKM1ruMVf9+uZ4i8jdrWZ906UTeklRFVyfRZ1xAfxICxX8cenoA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cfaa904a-f9af-4e5b-959a-8581c9ec3016", "AQAAAAEAACcQAAAAEHd43xIrupRjYEX+XSYxljC2exq7ciFFqJP5/yW7qRMTCIeFqdmSNTJuVlmbPuLzFg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6adc972e-340f-4cde-88f4-228dcf1c6931", "AQAAAAEAACcQAAAAEAxOF6s0Dzh1luJvNjlleOU43Zb7H6Sd0/Dj9m77u43hHk1g/2t1skaUAckFrryHdg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "464b5431-cfe8-4b22-afd6-149b27c1dd57", "AQAAAAEAACcQAAAAECWrAE9AuZpt6CL33FJGCAZL48zGE/VWMtFGLe3kNJMDaYFqXRmL2NJhvqX42U+VTw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "716e97e6-6f1c-4bab-b863-914f6b924947", "AQAAAAEAACcQAAAAEO9HmY1YxtkWu4l4AYylbN6WIpTYl8WRQeSkCViWBQ7j8CW4NWMcMJeNZq/HiEVsHQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f92f5c85-5027-42bc-8a4e-cdd56d142a46", "AQAAAAEAACcQAAAAEAkGvc6UVNeNh/RkfhwjtNcXgTfBb2Jxz8nxPY1dq/p9+QXThGbXdZDS3qIhlQOWPw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "4b6e50af-bed5-4198-8a60-80771b2669a7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"),
                column: "ConcurrencyStamp",
                value: "038c2684-f51c-44c2-bd98-24b7eca3ce66");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a3e854a-843d-4e65-ab88-9d5736c831f2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "365723b3-6f5e-4c5b-a3cd-4adf6bffaccb", "AQAAAAEAACcQAAAAEAm+FWqTEQfXPhGWJ0hsbOB80s3+iJofJsxElVrq6wUwqmxCPf8gq18ub3rHBh0J3w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05856533-e568-4a20-8e0e-052a2ad64aab", "AQAAAAEAACcQAAAAEJC53ctXLzQPwXJHWQPfAyVcZTPmQYZXDUnF0aA3Jy2lw5ArXdlzy6JVtiepzSOt2A==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4f97a72-6b4a-47d3-ba1b-6fe15e62c192"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "93993fc8-ef09-4ae6-a6d1-88f809d5430d", "AQAAAAEAACcQAAAAENmSjsR4xBq5nxSjY9euCgv1fI41AvxpkZntolJmYXCTc1sY17Qbih2HYTS27RzEOA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35942765-1a8f-400f-9e23-de636b52d4b2", "AQAAAAEAACcQAAAAEDrioa3LZJ7J+34oKw217i9ALWkWOuKp3UpY0Bn1xhK+9o/MCG9s8oleAN831gld2g==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3780707d-9c98-4800-a9fd-c65d1682b2e6", "AQAAAAEAACcQAAAAEAHDhaA0X4pCIdW/iVBwuavgBT7xLq3ei/QyUi4qltKzbJY+oqH2DC9pN+my7ZsZ/Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "837d6854-795d-4a85-871b-1f7d5847431a", "AQAAAAEAACcQAAAAEF2+kgZH/VqY0tKL655aCTFv5pdgTuvVIB3EyVVpspE4+EnZSxWCNnEpjAYpAgvARQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f54cd845-a853-46a8-9e13-dce7d9dfb32e", "AQAAAAEAACcQAAAAEPmu+WVs4up5SSrCGIC6D5DWsOwUf+ysheTIhPBiiPl6bLUP76pc2q/fI2Pqpj5XVQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2113046a-9552-440b-be0b-d7e1ec6fe65d", "AQAAAAEAACcQAAAAEAF2bQLrh/ek/zaCtADgBzA9psA6EZukdKtfkQ5W1VS6BNPHNngMx8SwYi5r8OqDxw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1dca93b9-e52f-4b3b-b62e-ce44435ce409", "AQAAAAEAACcQAAAAEHoJ4F8NRCm737yDgJeqRbz1UWVw4sRdd0Kj7c2rI8MSDhT6yB2s7gIfJkCIe3nBZA==" });
        }
    }
}
