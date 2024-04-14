using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APITraining.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8506a759-6f16-457d-9da7-b75b17cb45c6"), "Medium" },
                    { new Guid("9f480a29-56d8-48fb-859c-96321fcce1a3"), "Easy" },
                    { new Guid("b48ba3a6-d095-4b13-8226-5e6a8739f000"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("019505d6-1c17-4372-83ab-1711030957ab"), "KWR", "Kwara", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Kwarastatedrummers.jpg/220px-Kwarastatedrummers.jpg" },
                    { new Guid("269166c9-b4ca-4a63-b865-edccee3ab03f"), "OND", "Ondo", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Idanre_Hills_Ondo_State.jpg/2560px-Idanre_Hills_Ondo_State.jpg" },
                    { new Guid("57f83532-2774-4349-b56a-70a21ca41b54"), "LAG", "Lagos", "https://www.istockphoto.com/fi/valokuva/afrikkalainen-megakaupunki-lagos-nigeria-gm1320231994-406863542" },
                    { new Guid("e1e558cf-26db-4961-9b51-effecc874f97"), "OSU", "Osun", "https://c8.alamy.com/comp/E8WAKE/streets-of-oshogbo-a-city-in-osun-state-nigeria-E8WAKE.jpg" },
                    { new Guid("e39156e2-4672-4e38-a61f-bcd20af31397"), "EKT", "Ekiti", "https://upload.wikimedia.org/wikipedia/commons/5/5c/The_Iworoko_mountain_05.jpg" },
                    { new Guid("e661ea9e-6cb4-47cd-bade-04c8017fea1e"), "OYO", "Oyo", "https://c8.alamy.com/comp/E8W8H1/streets-of-the-city-of-ibadan-oyo-state-nigeria-E8W8H1.jpg" },
                    { new Guid("f5d9c0b1-32fa-4e61-b705-1ae097e109f1"), "OGU", "Ogun", "https://upload.wikimedia.org/wikipedia/commons/e/ef/The_First_Overhead_Bridge_in_Abeokuta_Ogun_State.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8506a759-6f16-457d-9da7-b75b17cb45c6"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9f480a29-56d8-48fb-859c-96321fcce1a3"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b48ba3a6-d095-4b13-8226-5e6a8739f000"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("019505d6-1c17-4372-83ab-1711030957ab"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("269166c9-b4ca-4a63-b865-edccee3ab03f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("57f83532-2774-4349-b56a-70a21ca41b54"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e1e558cf-26db-4961-9b51-effecc874f97"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e39156e2-4672-4e38-a61f-bcd20af31397"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e661ea9e-6cb4-47cd-bade-04c8017fea1e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f5d9c0b1-32fa-4e61-b705-1ae097e109f1"));
        }
    }
}
