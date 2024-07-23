using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Quiz.Api.Data.EntityFrameworkCore.Migrations
{
    public partial class EditTableToeicPart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Paragraph",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Audio",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Paragraph",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Audio",
                table: "GroupToeics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "450fd49c-3b28-4cbc-8006-54896fbb078e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"),
                column: "ConcurrencyStamp",
                value: "3185f28f-eddc-44de-9965-aa7e5606270b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1a3e854a-843d-4e65-ab88-9d5736c831f2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bf4d0089-61ee-4140-a2b8-a7a9c20a056e", "AQAAAAEAACcQAAAAEDyakAQ3MQOKFZIFDCbPUm8aCds0i7QZFO3YhI106Cr+6QNSZr1gxQDyznGI8uYxUQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "661fa151-deb3-41f2-9a04-9dd5889fe91f", "AQAAAAEAACcQAAAAED4oBDb5e72oEWVc+ArCLvUYjL30zeiw76PWIto94/yv1Nf2Hu9CNGwJq/4WKlyIUw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4f97a72-6b4a-47d3-ba1b-6fe15e62c192"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "301f5700-1aff-4b8c-b518-92acb76293c4", "AQAAAAEAACcQAAAAEJeICfv0obfc6HuQIhohTx9rHvl+kYG7Rt45jpTNC5sth8d0K1T/MyL4nUfaaJFY5Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54e3cdd4-3599-48e6-b548-1bfe59245ea5", "AQAAAAEAACcQAAAAEMlrpfVqznH6MY+UHvguNIURZqtBjVz9g3HKVXx0nHqdOy305EiPM+8uaL8CDQ2oRg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00386128-7f4c-4955-b362-0647d6c14e5d", "AQAAAAEAACcQAAAAEJWdSnhc2jZh7ghRRcxBU/oWF8szeLH0oiTaC9c1SBy2V41RzH4vyJcO5bidGm5qYQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a6"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42f79f94-9958-4bea-ab2a-f773738c5075", "AQAAAAEAACcQAAAAELMwpe8Cxca/Kdto15KGhARRyYoKYFLVV9561kFpLiuN+q7pM6fnV7Z/QWYEwNcUhg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08a7"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0de6f05-5239-4793-82ff-4b9e40c3d6b6", "AQAAAAEAACcQAAAAEISgAyoTSmXEfiZROMLwYoO3obrCNd4P2iU4+sdQheUhfVJNo1ZqFu+wzR3w/p9BGg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0cd5358-31a2-4d42-827e-b7f54a36cd23", "AQAAAAEAACcQAAAAEGl29V5o66S7CLGyKO+bbVYjVAegmuGzOAVUBHDekW3yOTuR7Kho5u/ljggzveCepw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e5b63a-53a1-4f88-a399-1f7c7f4b08b2"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6667e834-f37b-4d80-b162-b465950d6dbd", "AQAAAAEAACcQAAAAEGi+x7urBM0kVBBQcxcn/peCEs6V/q1KLYf/0fA3U0cbF6lvA4A7g7bslQZcPK8zGw==" });
        }
    }
}
