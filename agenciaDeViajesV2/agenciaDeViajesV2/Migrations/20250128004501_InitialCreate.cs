using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agenciaDeViajesV2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbactivities",
                columns: table => new
                {
                    PK_activity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbactivities", x => x.PK_activity);
                });

            migrationBuilder.CreateTable(
                name: "tbclients",
                columns: table => new
                {
                    PK_client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    preferences = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbclients", x => x.PK_client);
                });

            migrationBuilder.CreateTable(
                name: "tbflies",
                columns: table => new
                {
                    PK_fly = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sailsIn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    arrivesIn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sailsAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    arrivesExpected = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pricePerSeat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbflies", x => x.PK_fly);
                });

            migrationBuilder.CreateTable(
                name: "tbhotels",
                columns: table => new
                {
                    PK_hotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    addressAt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    stars = table.Column<int>(type: "int", nullable: false),
                    imageHotel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbhotels", x => x.PK_hotel);
                });

            migrationBuilder.CreateTable(
                name: "tbroles",
                columns: table => new
                {
                    PK_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbroles", x => x.PK_rol);
                });

            migrationBuilder.CreateTable(
                name: "tbrooms",
                columns: table => new
                {
                    PK_room = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_hotel = table.Column<int>(type: "int", nullable: false),
                    pricePerNight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false),
                    HotelClassPK_hotel = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbrooms", x => x.PK_room);
                    table.ForeignKey(
                        name: "FK_tbrooms_tbhotels_FK_hotel",
                        column: x => x.FK_hotel,
                        principalTable: "tbhotels",
                        principalColumn: "PK_hotel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbrooms_tbhotels_HotelClassPK_hotel",
                        column: x => x.HotelClassPK_hotel,
                        principalTable: "tbhotels",
                        principalColumn: "PK_hotel");
                });

            migrationBuilder.CreateTable(
                name: "tbusers",
                columns: table => new
                {
                    PK_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_rol = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbusers", x => x.PK_user);
                    table.ForeignKey(
                        name: "FK_tbusers_tbroles_FK_rol",
                        column: x => x.FK_rol,
                        principalTable: "tbroles",
                        principalColumn: "PK_rol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tboffers",
                columns: table => new
                {
                    PK_offer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_room = table.Column<int>(type: "int", nullable: false),
                    FK_client = table.Column<int>(type: "int", nullable: false),
                    FK_activity = table.Column<int>(type: "int", nullable: true),
                    Destiny = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DistanceDays = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false),
                    ActivityClassPK_activity = table.Column<int>(type: "int", nullable: true),
                    ClientClassPK_client = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tboffers", x => x.PK_offer);
                    table.ForeignKey(
                        name: "FK_tboffers_tbactivities_ActivityClassPK_activity",
                        column: x => x.ActivityClassPK_activity,
                        principalTable: "tbactivities",
                        principalColumn: "PK_activity");
                    table.ForeignKey(
                        name: "FK_tboffers_tbactivities_FK_activity",
                        column: x => x.FK_activity,
                        principalTable: "tbactivities",
                        principalColumn: "PK_activity");
                    table.ForeignKey(
                        name: "FK_tboffers_tbclients_ClientClassPK_client",
                        column: x => x.ClientClassPK_client,
                        principalTable: "tbclients",
                        principalColumn: "PK_client");
                    table.ForeignKey(
                        name: "FK_tboffers_tbclients_FK_client",
                        column: x => x.FK_client,
                        principalTable: "tbclients",
                        principalColumn: "PK_client",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tboffers_tbrooms_FK_room",
                        column: x => x.FK_room,
                        principalTable: "tbrooms",
                        principalColumn: "PK_room",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbpayments",
                columns: table => new
                {
                    PK_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_offer = table.Column<int>(type: "int", nullable: false),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    paymentMethod = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbpayments", x => x.PK_payment);
                    table.ForeignKey(
                        name: "FK_tbpayments_tboffers_FK_offer",
                        column: x => x.FK_offer,
                        principalTable: "tboffers",
                        principalColumn: "PK_offer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbseats",
                columns: table => new
                {
                    PK_seat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_fly = table.Column<int>(type: "int", nullable: false),
                    FK_offer = table.Column<int>(type: "int", nullable: false),
                    seatNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    reserState = table.Column<bool>(type: "bit", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    states = table.Column<int>(type: "int", nullable: false),
                    FlyClassPK_fly = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbseats", x => x.PK_seat);
                    table.ForeignKey(
                        name: "FK_tbseats_tbflies_FK_fly",
                        column: x => x.FK_fly,
                        principalTable: "tbflies",
                        principalColumn: "PK_fly",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbseats_tbflies_FlyClassPK_fly",
                        column: x => x.FlyClassPK_fly,
                        principalTable: "tbflies",
                        principalColumn: "PK_fly");
                    table.ForeignKey(
                        name: "FK_tbseats_tboffers_FK_offer",
                        column: x => x.FK_offer,
                        principalTable: "tboffers",
                        principalColumn: "PK_offer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tboffers_ActivityClassPK_activity",
                table: "tboffers",
                column: "ActivityClassPK_activity");

            migrationBuilder.CreateIndex(
                name: "IX_tboffers_ClientClassPK_client",
                table: "tboffers",
                column: "ClientClassPK_client");

            migrationBuilder.CreateIndex(
                name: "IX_tboffers_FK_activity",
                table: "tboffers",
                column: "FK_activity");

            migrationBuilder.CreateIndex(
                name: "IX_tboffers_FK_client",
                table: "tboffers",
                column: "FK_client");

            migrationBuilder.CreateIndex(
                name: "IX_tboffers_FK_room",
                table: "tboffers",
                column: "FK_room");

            migrationBuilder.CreateIndex(
                name: "IX_tbpayments_FK_offer",
                table: "tbpayments",
                column: "FK_offer");

            migrationBuilder.CreateIndex(
                name: "IX_tbrooms_FK_hotel",
                table: "tbrooms",
                column: "FK_hotel");

            migrationBuilder.CreateIndex(
                name: "IX_tbrooms_HotelClassPK_hotel",
                table: "tbrooms",
                column: "HotelClassPK_hotel");

            migrationBuilder.CreateIndex(
                name: "IX_tbseats_FK_fly",
                table: "tbseats",
                column: "FK_fly");

            migrationBuilder.CreateIndex(
                name: "IX_tbseats_FK_offer",
                table: "tbseats",
                column: "FK_offer");

            migrationBuilder.CreateIndex(
                name: "IX_tbseats_FlyClassPK_fly",
                table: "tbseats",
                column: "FlyClassPK_fly");

            migrationBuilder.CreateIndex(
                name: "IX_tbusers_FK_rol",
                table: "tbusers",
                column: "FK_rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbpayments");

            migrationBuilder.DropTable(
                name: "tbseats");

            migrationBuilder.DropTable(
                name: "tbusers");

            migrationBuilder.DropTable(
                name: "tbflies");

            migrationBuilder.DropTable(
                name: "tboffers");

            migrationBuilder.DropTable(
                name: "tbroles");

            migrationBuilder.DropTable(
                name: "tbactivities");

            migrationBuilder.DropTable(
                name: "tbclients");

            migrationBuilder.DropTable(
                name: "tbrooms");

            migrationBuilder.DropTable(
                name: "tbhotels");
        }
    }
}
