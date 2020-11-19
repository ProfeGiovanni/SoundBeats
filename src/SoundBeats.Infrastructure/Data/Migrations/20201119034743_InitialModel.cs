using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace SoundBeats.Infrastructure.Data.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameEn = table.Column<string>(maxLength: 80, nullable: true),
                    NameEs = table.Column<string>(maxLength: 80, nullable: true),
                    ISO2 = table.Column<string>(maxLength: 2, nullable: true),
                    ISO3 = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musician",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    BirthPlace = table.Column<string>(maxLength: 100, nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    ImageType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musician", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Biography = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    PhotoCover = table.Column<byte[]>(nullable: true),
                    ImageType = table.Column<string>(nullable: true),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    JoinInYear = table.Column<int>(nullable: false),
                    LeftYear = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false),
                    MusicianId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMember_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_Musician_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "Musician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TrackNumber = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 80, nullable: true),
                    Length = table.Column<decimal>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Song_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Song_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "ISO2", "ISO3", "NameEn", "NameEs" },
                values: new object[,]
                {
                    { 1, "AD", "AND", " ", "Andorra" },
                    { 156, "MY", "MYS", " ", "Malasia" },
                    { 157, "MZ", "MOZ", " ", "Mozambique" },
                    { 158, "NA", "NAM", " ", "Namibia" },
                    { 159, "NC", "NCL", " ", "Nueva Caledonia" },
                    { 160, "NE", "NER", " ", "Níger" },
                    { 161, "NF", "NFK", " ", "Isla Norfolk" },
                    { 162, "NG", "NGA", " ", "Nigeria" },
                    { 163, "NI", "NIC", " ", "Nicaragua" },
                    { 164, "NL", "NLD", " ", "Países Bajos" },
                    { 165, "NO", "NOR", " ", "Noruega" },
                    { 166, "NP", "NPL", " ", "Nepal" },
                    { 167, "NR", "NRU", " ", "Naurú" },
                    { 155, "MX", "MEX", " ", "México" },
                    { 168, "NU", "NIU", " ", "Niue" },
                    { 170, "OM", "OMN", " ", "Omán" },
                    { 171, "PA", "PAN", " ", "Panamá" },
                    { 172, "PE", "PER", " ", "Perú" },
                    { 173, "PF", "PYF", " ", "Polinesia Francesa" },
                    { 174, "PG", "PNG", " ", "Papúa-Nueva Guinea" },
                    { 175, "PH", "PHL", " ", "Filipinas" },
                    { 176, "PK", "PAK", " ", "Pakistán" },
                    { 177, "PL", "POL", " ", "Polonia" },
                    { 178, "PM", "SPM", " ", "San Pedro y Miquelón" },
                    { 179, "PN", "PCN", " ", "Pitcairn" },
                    { 180, "PR", "PRI", " ", "Puerto Rico" },
                    { 181, "PS", "PSE", " ", "Estado de Palestina" },
                    { 169, "NZ", "NZL", " ", "Nueva Zelanda" },
                    { 154, "MW", "MWI", " ", "Malawi" },
                    { 153, "MV", "MDV", " ", "Maldivas" },
                    { 152, "MU", "MUS", " ", "Mauricio" },
                    { 125, "LA", "LAO", " ", "Laos" },
                    { 126, "LB", "LBN", " ", "Líbano" },
                    { 127, "LC", "LCA", " ", "Santa Lucía" },
                    { 128, "LI", "LIE", " ", "Liechtenstein" },
                    { 129, "LK", "LKA", " ", "Sri Lanka" },
                    { 130, "LR", "LBR", " ", "Liberia" },
                    { 131, "LS", "LSO", " ", "Lesotho" },
                    { 132, "LT", "LTU", " ", "Lituana" },
                    { 133, "LU", "LUX", " ", "Luxembur " },
                    { 134, "LV", "LVA", " ", "Letonia" },
                    { 135, "LY", "LBY", " ", "Libia" },
                    { 136, "MA", "MAR", " ", "Marruecos" },
                    { 137, "MC", "MCO", " ", "Mónaco" },
                    { 138, "MD", "MDA", " ", "Moldavia" },
                    { 139, "ME", "MNE", " ", "Montenegro" },
                    { 140, "MG", "MDG", " ", "Madagascar" },
                    { 141, "MH", "MHL", " ", "Islas Marschall" },
                    { 142, "MK", "MKD", " ", "Macedonia" },
                    { 143, "ML", "MLI", " ", "Malí" },
                    { 144, "MM", "MMR", " ", "Myanmar" },
                    { 145, "MN", "MNG", " ", "Mon lia" },
                    { 146, "MO", "MAC", " ", "Macao" },
                    { 147, "MP", "MNP", " ", "Islas Marianas del Norte" },
                    { 148, "MQ", "MTQ", " ", "Martinica" },
                    { 149, "MR", "MRT", " ", "Mauritania" },
                    { 150, "MS", "MSR", " ", "Montserrat" },
                    { 151, "MT", "MLT", " ", "Malta" },
                    { 182, "PT", "PRT", " ", "Portugal" },
                    { 183, "PW", "PLW", " ", "Palau" },
                    { 184, "PY", "PRY", " ", "Paraguay" },
                    { 185, "QA", "QAT", " ", "Qatar" },
                    { 217, "TL", "TKM", " ", "Timor Este" },
                    { 218, "TM", "TUN", " ", "Turkmenistán" },
                    { 219, "TN", "TON", " ", "Tunicia" },
                    { 220, "TO", "TMP", " ", "Tonga" },
                    { 221, "TR", "TUR", " ", "Turquía" },
                    { 222, "TT", "TTO", " ", "Trinidad y Toba " },
                    { 223, "TV", "TUV", " ", "Tuvalú" },
                    { 224, "TW", "TWN", " ", "Taiwán" },
                    { 225, "TZ", "TZA", " ", "Tanzania" },
                    { 226, "UA", "UKR", " ", "Ucrania" },
                    { 227, "UG", "UGA", " ", "Uganda" },
                    { 228, "UM", "UMI", " ", "Islas Menores de Estados Unidos" },
                    { 229, "US", "USA", " ", "Estados Unidos" },
                    { 230, "UY", "URY", " ", "Uruguay" },
                    { 231, "UZ", "UZB", " ", "Uzbekistán" },
                    { 232, "VA", "VAT", " ", "El Vaticano" },
                    { 233, "VC", "VCT", " ", "San Vicente y Granadinas" },
                    { 234, "VE", "VEN", " ", "Venezuela" },
                    { 235, "VG", "VGB", " ", "Islas Vírgenes Británicas" },
                    { 236, "VI", "VIR", " ", "Islas Vírgenes de Estados Unidos" },
                    { 237, "VN", "VNM", " ", "Vietnam" },
                    { 238, "VU", "VUT", " ", "Vanuatu" },
                    { 239, "WF", "WLF", " ", "Wallis y Futuna" },
                    { 240, "WS", "WSM", " ", "Samoa" },
                    { 241, "YE", "YEM", " ", "Yemén" },
                    { 242, "YT", "MYT", " ", "Mayotte" },
                    { 243, "ZA", "ZAF", " ", "Suráfrica" },
                    { 216, "TK", "TKL", " ", "Tokelau" },
                    { 124, "KZ", "KAZ", " ", "Kasajistán" },
                    { 215, "TJ", "TJK", " ", "Tajikistán" },
                    { 213, "TG", "TGO", " ", "Togo" },
                    { 186, "RE", "REU", " ", "Reunión" },
                    { 187, "RO", "ROM", " ", "Rumania" },
                    { 188, "RS", "SRB", " ", "Serbia" },
                    { 189, "RU", "RUS", " ", "Rusia" },
                    { 190, "RW", "RWA", " ", "Ruanda" },
                    { 191, "SA", "SAU", " ", "Arabia Saudita" },
                    { 192, "SB", "SLB", " ", "Islas Salomón" },
                    { 193, "SC", "SYC", " ", "Seychelles" },
                    { 194, "SD", "SDN", " ", "Sudán" },
                    { 195, "SE", "SWE", " ", "Suecia" },
                    { 196, "SG", "SGP", " ", "Singapur" },
                    { 197, "SH", "SHN", " ", "Santa Helena" },
                    { 198, "SI", "SVN", " ", "Eslovenia" },
                    { 199, "SJ", "SJM", " ", "Svalbard y Jan Mayen" },
                    { 200, "SK", "SVK", " ", "Eslovaquia" },
                    { 201, "SL", "SLE", " ", "Sierra Leona" },
                    { 202, "SM", "SMR", " ", "San Marino" },
                    { 203, "SN", "SEN", " ", "Senegal" },
                    { 204, "SO", "SOM", " ", "Somalia" },
                    { 205, "SR", "SUR", " ", "Surinam" },
                    { 206, "ST", "STP", " ", "Santo Tomé y Príncipe" },
                    { 207, "SV", "SLV", " ", "El Salvador" },
                    { 208, "SY", "SYR", " ", "Siria" },
                    { 209, "SZ", "SWZ", " ", "Swazilandia" },
                    { 210, "TC", "TCA", " ", "Isla Turks y Caicos" },
                    { 211, "TD", "TCD", " ", "Chad" },
                    { 212, "TF", "ATF", " ", "Territorios Franceses del Sur" },
                    { 214, "TH", "THA", " ", "Tailandia" },
                    { 244, "ZM", "ZMB", " ", "Zambia" },
                    { 123, "KY", "CYM", " ", "Islas Caimán" },
                    { 121, "KR", "KOR", " ", "República de Corea" },
                    { 33, "BT", "BTN", " ", "Bután" },
                    { 34, "BV", "BVT", " ", "Isla Bouvet" },
                    { 35, "BW", "BWA", " ", "Botswana" },
                    { 36, "BY", "BLR", " ", "Bielorusia" },
                    { 37, "BZ", "BLZ", " ", "Belice" },
                    { 38, "CA", "CAN", " ", "Canadá" },
                    { 39, "CC", "CCK", " ", "Islas Cocos" },
                    { 40, "CD", "COD", " ", "Republica Democrática del Congo" },
                    { 41, "CF", "CAF", " ", "República Centrofricana" },
                    { 42, "CG", "COG", " ", "República del Congo" },
                    { 43, "CH", "CHE", " ", "Suiza" },
                    { 44, "CI", "CIV", " ", "Costa de Marfil" },
                    { 32, "BS", "BHS", " ", "Bahamas" },
                    { 45, "CK", "COK", " ", "Islas Cook" },
                    { 47, "CM", "CMR", " ", "Camerún" },
                    { 48, "CN", "CHN", " ", "China" },
                    { 49, "CO", "COL", " ", "Colombia" },
                    { 50, "CR", "CRI", " ", "Costa Rica" },
                    { 51, "CU", "CUB", " ", "Cuba" },
                    { 52, "CV", "CPV", " ", "Cabo Verde" },
                    { 53, "CX", "CXR", " ", "Isla de Navidad" },
                    { 54, "CY", "CYP", " ", "Chipre" },
                    { 55, "CZ", "CZE", " ", "República Checa" },
                    { 56, "DE", "DEU", " ", "Alemania" },
                    { 57, "DJ", "DJI", " ", "Yibuti" },
                    { 58, "DK", "DNK", " ", "Dinamarca" },
                    { 46, "CL", "CHL", " ", "Chile" },
                    { 31, "BR", "BRA", " ", "Brasil" },
                    { 30, "BO", "BOL", " ", "Bolivia" },
                    { 29, "BN", "BRN", " ", "Brunei" },
                    { 2, "AE", "ARE", " ", "Emiratos Árabes Unidos" },
                    { 3, "AF", "AFG", " ", "Afganistán" },
                    { 4, "AG", "ATG", " ", "Antigua y Barbuda" },
                    { 5, "AI", "AIA", " ", "Anguila" },
                    { 6, "AL", "ALB", " ", "Albania" },
                    { 7, "AL", "ALB", " ", "Albania" },
                    { 8, "AM", "ARM", " ", "Armenia" },
                    { 9, "AN", "ANT", " ", "Antillas Holandesas" },
                    { 10, "AO", "AGO", " ", "Angola" },
                    { 11, "AQ", "ATA", " ", "Antártida" },
                    { 12, "AR", "ARG", " ", "Argentina" },
                    { 13, "AS", "ASM", " ", "Samoa Americana" },
                    { 14, "AT", "AUT", " ", "Austria" },
                    { 15, "AU", "AUS", " ", "Australia" },
                    { 16, "AW", "ABW", " ", "Aruba" },
                    { 17, "AX", "ALA", " ", "Islas Aland" },
                    { 18, "AZ", "AZE", " ", "Azerbaiyán" },
                    { 19, "BA", "BIH", " ", "Bosnia y Herzegovina" },
                    { 20, "BB", "BRB", " ", "Barbados" },
                    { 21, "BD", "BGD", " ", "Bangladesh" },
                    { 22, "BE", "BEL", " ", "Bélgica" },
                    { 23, "BF", "BFA", " ", "Burkina Faso" },
                    { 24, "BG", "BGR", " ", "Bulgaria" },
                    { 25, "BH", "BHR", " ", "Bahrein" },
                    { 26, "BI", "BDI", " ", "Burundi" },
                    { 27, "BJ", "BEN", " ", "Benín" },
                    { 28, "BM", "BMU", " ", "Bermudas" },
                    { 59, "DM", "DMA", " ", "Dominica" },
                    { 60, "DO", "DOM", " ", "República Dominicana" },
                    { 61, "DZ", "DZA", " ", "Argelia" },
                    { 62, "EC", "ECU", " ", "Ecuador" },
                    { 94, "HK", "HKG", " ", "Hong Kong" },
                    { 95, "HM", "HMD", " ", "Islas Heard y McDonald" },
                    { 96, "HN", "HND", " ", "Honduras" },
                    { 97, "HR", "HRV", " ", "Croacia" },
                    { 98, "HT", "HTI", " ", "Haití" },
                    { 99, "HU", "HUN", " ", "Hungría" },
                    { 100, "ID", "IDN", " ", "Indonesia" },
                    { 101, "IE", "IRL", " ", "Irlanda" },
                    { 102, "IL", "ISR", " ", "Israel" },
                    { 103, "IM", "IMN", " ", "Isla de Man" },
                    { 104, "IN", "IND", " ", "India" },
                    { 105, "IO", "IOT", " ", "Terrirorio Británico del Océano Índico" },
                    { 106, "IQ", "IRQ", " ", "Irak" },
                    { 107, "IR", "IRN", " ", "Irán" },
                    { 108, "IS", "ISL", " ", "Islandia" },
                    { 109, "IT", "ITA", " ", "Italia" },
                    { 110, "JE", "JEY", " ", "Jersey" },
                    { 111, "JM", "JAM", " ", "Jamaica" },
                    { 112, "JO", "JOR", " ", "Jordania" },
                    { 113, "JP", "JPN", " ", "Japón" },
                    { 114, "KE", "KEN", " ", "Kenia" },
                    { 115, "KG", "KGZ", " ", "Kirguistán" },
                    { 116, "KH", "KHM", " ", "Camboya" },
                    { 117, "KI", "KIR", " ", "Kiribati" },
                    { 118, "KM", "COM", " ", "Comoras" },
                    { 119, "KN", "KNA", " ", "San Cristóbal y Nieves" },
                    { 120, "KP", "PRK", " ", "República Democrática de Corea" },
                    { 93, "GY", "GUY", " ", "Guyana" },
                    { 122, "KW", "KWT", " ", "Kuwait" },
                    { 92, "GW", "GNB", " ", "Guinea-Bissau" },
                    { 90, "GT", "GTM", " ", "Guatemala" },
                    { 63, "EE", "EST", " ", "Estonia" },
                    { 64, "EG", "EGY", " ", "Egipto" },
                    { 65, "EH", "ESH", " ", "Sahara Occidental" },
                    { 66, "ER", "ERI", " ", "Eritrea" },
                    { 67, "ES", "ESP", " ", "España" },
                    { 68, "ET", "ETH", " ", "Etiopía" },
                    { 69, "FI", "FIN", " ", "Finlandia" },
                    { 70, "FJ", "FJI", " ", "Fiji" },
                    { 71, "FK", "FLK", " ", "Islas Malvinas" },
                    { 72, "FM", "FSM", " ", "Micronesia" },
                    { 73, "FO", "FRO", " ", "Islas Faroe" },
                    { 74, "FR", "FRA", " ", "Francia" },
                    { 75, "GA", "GAB", " ", "Gabón" },
                    { 76, "GB", "GBR", " ", "Reino Unido" },
                    { 77, "GD", "GRD", " ", "Granada" },
                    { 78, "GE", "GEO", " ", "Georgia" },
                    { 79, "GF", "GUF", " ", "Guayana Francesa" },
                    { 80, "GG", "GGY", " ", "Guernsey" },
                    { 81, "GH", "GHA", " ", "Ghana" },
                    { 82, "GI", "GIB", " ", "Gibraltar" },
                    { 83, "GL", "GRL", " ", "Groenlandia" },
                    { 84, "GM", "GMB", " ", "Gambia" },
                    { 85, "GN", "GIN", " ", "Guinea" },
                    { 86, "GP", "GLP", " ", "Guadalupe" },
                    { 87, "GQ", "GNQ", " ", "Guinea Ecuatorial" },
                    { 88, "GR", "GRC", " ", "Grecia" },
                    { 89, "GS", "SGS", " ", "Georgia del Sur y las islas Sandwich" },
                    { 91, "GU", "GUM", " ", "Guam" },
                    { 245, "ZW", "ZWE", " ", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CountryId",
                table: "Artist",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_ArtistId",
                table: "GroupMember",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_MusicianId",
                table: "GroupMember",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_AlbumId",
                table: "Song",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Song_GenreId",
                table: "Song",
                column: "GenreId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Musician");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
