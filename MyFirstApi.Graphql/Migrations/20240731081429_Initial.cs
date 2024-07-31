using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFirstApi.Graphql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    HasComputers = table.Column<bool>(type: "bit", nullable: false),
                    HasProjector = table.Column<bool>(type: "bit", nullable: false),
                    HasWhiteboard = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Furniture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Material = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furniture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LabRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Equipment = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    HasChemicals = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CourseType = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    GroupCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => new { x.CourseId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Capacity", "Description", "HasComputers", "HasProjector", "HasWhiteboard", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000601"), 20, "Classroom 1", true, false, true, "Classroom 1" },
                    { new Guid("00000000-0000-0000-0000-000000000602"), 30, "Classroom 2", true, false, true, "Classroom 2" },
                    { new Guid("00000000-0000-0000-0000-000000000603"), 40, "Classroom 3", true, true, true, "Classroom 3" },
                    { new Guid("00000000-0000-0000-0000-000000000604"), 50, "Classroom 4", false, false, true, "Classroom 4" },
                    { new Guid("00000000-0000-0000-0000-000000000605"), 100, "Classroom 5", true, true, true, "Classroom 5" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Mathematics Department", "Mathematics" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Science Department", "Science" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Computer Science Department", "Computer Science" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Arts Department", "Arts" }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Brand", "Condition", "Description", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000701"), "Bunsen", "Good", "Bunsen Burner", "Bunsen Burner", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000702"), "Beaker", "Good", "Beaker", "Beaker", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000703"), "Prism", "Good", "Prism", "Prism", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000704"), "Magnets", "Good", "Magnets", "Magnets", 10 },
                    { new Guid("00000000-0000-0000-0000-000000000705"), "Computer", "Good", "Computer", "Computer", 40 },
                    { new Guid("00000000-0000-0000-0000-000000000706"), "Projector", "Good", "Projector", "Projector", 6 }
                });

            migrationBuilder.InsertData(
                table: "Furniture",
                columns: new[] { "Id", "Color", "Description", "Material", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000801"), "Brown", "Desk", "Wood", "Desk", 20 },
                    { new Guid("00000000-0000-0000-0000-000000000802"), "Black", "Chair", "Wood", "Chair", 20 },
                    { new Guid("00000000-0000-0000-0000-000000000803"), "White", "Whiteboard", "Plastic", "Whiteboard", 10 }
                });

            migrationBuilder.InsertData(
                table: "LabRooms",
                columns: new[] { "Id", "Capacity", "Description", "Equipment", "HasChemicals", "Name", "Subject" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000501"), 20, "Chemistry Lab", "Chemicals, Beakers, Bunsen Burners", true, "Chemistry Lab", "Chemistry" },
                    { new Guid("00000000-0000-0000-0000-000000000502"), 20, "Physics Lab", "Bunsen Burners, Magnets, Prisms", false, "Physics Lab", "Physics" },
                    { new Guid("00000000-0000-0000-0000-000000000503"), 20, "Computer Lab", "Computers, Projector", false, "Computer Lab", "Computer Science" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "CourseType", "Credits", "DepartmentId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000301"), "MATH", "Core", 3, new Guid("00000000-0000-0000-0000-000000000001"), "Mathematics Course", "Mathematics" },
                    { new Guid("00000000-0000-0000-0000-000000000302"), "ALG", "Core", 3, new Guid("00000000-0000-0000-0000-000000000001"), "Algebra Course", "Algebra" },
                    { new Guid("00000000-0000-0000-0000-000000000303"), "GEO", "Core", 3, new Guid("00000000-0000-0000-0000-000000000001"), "Geometry Course", "Geometry" },
                    { new Guid("00000000-0000-0000-0000-000000000304"), "MATHF", "Elective", 3, new Guid("00000000-0000-0000-0000-000000000001"), "Math Fundamentals Course", "Math Fundamentals" },
                    { new Guid("00000000-0000-0000-0000-000000000305"), "SCI", "Elective", 3, new Guid("00000000-0000-0000-0000-000000000002"), "Science Course", "Science" },
                    { new Guid("00000000-0000-0000-0000-000000000306"), "PHY", "Core", 3, new Guid("00000000-0000-0000-0000-000000000002"), "Physics Course", "Physics" },
                    { new Guid("00000000-0000-0000-0000-000000000307"), "CHEM", "Lab", 3, new Guid("00000000-0000-0000-0000-000000000002"), "Chemistry Course", "Chemistry" },
                    { new Guid("00000000-0000-0000-0000-000000000308"), "ENV", "Elective", 3, new Guid("00000000-0000-0000-0000-000000000002"), "Environmental Science Course", "Environmental Science" },
                    { new Guid("00000000-0000-0000-0000-000000000309"), "SCIF", "Elective", 3, new Guid("00000000-0000-0000-0000-000000000002"), "Science Fundamentals Course", "Science Fundamentals" },
                    { new Guid("00000000-0000-0000-0000-000000000310"), "CS", "Core", 3, new Guid("00000000-0000-0000-0000-000000000003"), "Computer Science Course", "Computer Science" },
                    { new Guid("00000000-0000-0000-0000-000000000311"), "CP", "Core", 3, new Guid("00000000-0000-0000-0000-000000000003"), "Computer Programming Course", "Computer Programming" },
                    { new Guid("00000000-0000-0000-0000-000000000312"), "CA", "Lab", 3, new Guid("00000000-0000-0000-0000-000000000003"), "Computer Applications Course", "Computer Applications" },
                    { new Guid("00000000-0000-0000-0000-000000000313"), "CSF", "Elective", 3, new Guid("00000000-0000-0000-0000-000000000003"), "Computer Science Fundamentals Course", "Computer Science Fundamentals" },
                    { new Guid("00000000-0000-0000-0000-000000000314"), "DS", "Core", 3, new Guid("00000000-0000-0000-0000-000000000003"), "Data Structures Course", "Data Structures" },
                    { new Guid("00000000-0000-0000-0000-000000000315"), "ALGR", "Core", 3, new Guid("00000000-0000-0000-0000-000000000003"), "Algorithms Course", "Algorithms" },
                    { new Guid("00000000-0000-0000-0000-000000000316"), "MUS", "Core", 3, new Guid("00000000-0000-0000-0000-000000000004"), "Music Course", "Music" },
                    { new Guid("00000000-0000-0000-0000-000000000317"), "PAINT", "Core", 3, new Guid("00000000-0000-0000-0000-000000000004"), "Painting Course", "Painting" },
                    { new Guid("00000000-0000-0000-0000-000000000318"), "PHOTO", "Core", 3, new Guid("00000000-0000-0000-0000-000000000004"), "Photography Course", "Photography" },
                    { new Guid("00000000-0000-0000-0000-000000000319"), "DANCE", "Core", 3, new Guid("00000000-0000-0000-0000-000000000004"), "Dance Course", "Dance" },
                    { new Guid("00000000-0000-0000-0000-000000000320"), "ARTH", "Elective", 3, new Guid("00000000-0000-0000-0000-000000000004"), "Art History Course", "Art History" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "DepartmentId", "Description", "GroupCode", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000101"), new Guid("00000000-0000-0000-0000-000000000001"), "Mathematics Group", "MATH", "Mathematics" },
                    { new Guid("00000000-0000-0000-0000-000000000102"), new Guid("00000000-0000-0000-0000-000000000001"), "Algebra Group", "ALG", "Algebra" },
                    { new Guid("00000000-0000-0000-0000-000000000103"), new Guid("00000000-0000-0000-0000-000000000001"), "Geometry Group", "GEO", "Geometry" },
                    { new Guid("00000000-0000-0000-0000-000000000201"), new Guid("00000000-0000-0000-0000-000000000002"), "Science Group", "SCI", "Science" },
                    { new Guid("00000000-0000-0000-0000-000000000202"), new Guid("00000000-0000-0000-0000-000000000002"), "Physics Group", "PHY", "Physics" },
                    { new Guid("00000000-0000-0000-0000-000000000203"), new Guid("00000000-0000-0000-0000-000000000002"), "Chemistry Group", "CHEM", "Chemistry" },
                    { new Guid("00000000-0000-0000-0000-000000000204"), new Guid("00000000-0000-0000-0000-000000000002"), "Environmental Science Group", "ENV", "Environmental Science" },
                    { new Guid("00000000-0000-0000-0000-000000000205"), new Guid("00000000-0000-0000-0000-000000000003"), "Computer Science Group", "CS", "Computer Science" },
                    { new Guid("00000000-0000-0000-0000-000000000206"), new Guid("00000000-0000-0000-0000-000000000003"), "Computer Programming Group", "CP", "Computer Programming" },
                    { new Guid("00000000-0000-0000-0000-000000000207"), new Guid("00000000-0000-0000-0000-000000000003"), "Computer Applications Group", "CA", "Computer Applications" },
                    { new Guid("00000000-0000-0000-0000-000000000208"), new Guid("00000000-0000-0000-0000-000000000004"), "Music Group", "MUS", "Music" },
                    { new Guid("00000000-0000-0000-0000-000000000209"), new Guid("00000000-0000-0000-0000-000000000004"), "Painting Group", "PAINT", "Painting" },
                    { new Guid("00000000-0000-0000-0000-000000000210"), new Guid("00000000-0000-0000-0000-000000000004"), "Photography Group", "PHOTO", "Photography" },
                    { new Guid("00000000-0000-0000-0000-000000000211"), new Guid("00000000-0000-0000-0000-000000000004"), "Dance Group", "DANCE", "Dance" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Bio", "DepartmentId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000401"), "John Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000001"), "john.doe@sampleschool.com", "John", "Doe", "111-111-1111" },
                    { new Guid("00000000-0000-0000-0000-000000000402"), "Jane Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000001"), "", "Jane", "Doe", "555-555-5555" },
                    { new Guid("00000000-0000-0000-0000-000000000403"), "David Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000002"), "", "David", "Doe", "123-123-1234" },
                    { new Guid("00000000-0000-0000-0000-000000000404"), "Bob Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000003"), "", "Bob", "Doe", "222-222-2222" },
                    { new Guid("00000000-0000-0000-0000-000000000405"), "Jill Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000003"), "", "Jill", "Doe", "333-333-3333" },
                    { new Guid("00000000-0000-0000-0000-000000000406"), "Adam Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000004"), "", "Adam", "Doe", "333-333-3333" },
                    { new Guid("00000000-0000-0000-0000-000000000407"), "James Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000004"), "", "James", "Doe", "444-444-4444" },
                    { new Guid("00000000-0000-0000-0000-000000000408"), "Jenny Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000004"), "", "Jenny", "Doe", "666-666-6666" },
                    { new Guid("00000000-0000-0000-0000-000000000409"), "Sara Doe is a teacher at Sample School.", new Guid("00000000-0000-0000-0000-000000000004"), "", "Sara", "Doe", "777-777-7777" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "Grade", "GroupId", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000901"), new DateOnly(2000, 1, 1), "", "John", "", new Guid("00000000-0000-0000-0000-000000000102"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000902"), new DateOnly(2000, 1, 2), "", "Jane", "", new Guid("00000000-0000-0000-0000-000000000102"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000903"), new DateOnly(2000, 1, 3), "", "David", "", new Guid("00000000-0000-0000-0000-000000000102"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000904"), new DateOnly(2000, 1, 4), "", "Bob", "", new Guid("00000000-0000-0000-0000-000000000102"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000905"), new DateOnly(2000, 1, 5), "", "Jill", "", new Guid("00000000-0000-0000-0000-000000000203"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000906"), new DateOnly(2000, 1, 6), "", "Adam", "", new Guid("00000000-0000-0000-0000-000000000203"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000907"), new DateOnly(2000, 1, 7), "", "James", "", new Guid("00000000-0000-0000-0000-000000000203"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000908"), new DateOnly(2000, 1, 8), "", "Jenny", "", new Guid("00000000-0000-0000-0000-000000000203"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000909"), new DateOnly(2000, 1, 9), "", "Sara", "", new Guid("00000000-0000-0000-0000-000000000203"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000910"), new DateOnly(2000, 1, 10), "", "Jack", "", new Guid("00000000-0000-0000-0000-000000000206"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000911"), new DateOnly(2000, 1, 11), "", "Andrew", "", new Guid("00000000-0000-0000-0000-000000000206"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000912"), new DateOnly(2000, 1, 12), "", "Thomas", "", new Guid("00000000-0000-0000-0000-000000000206"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000913"), new DateOnly(2001, 1, 13), "", "Elaine", "", new Guid("00000000-0000-0000-0000-000000000103"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000914"), new DateOnly(2001, 1, 14), "", "Eli", "", new Guid("00000000-0000-0000-0000-000000000103"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000915"), new DateOnly(2001, 1, 15), "", "Dominic", "", new Guid("00000000-0000-0000-0000-000000000103"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000916"), new DateOnly(2001, 1, 16), "", "Lily", "", new Guid("00000000-0000-0000-0000-000000000204"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000917"), new DateOnly(2001, 1, 17), "", "Liam", "", new Guid("00000000-0000-0000-0000-000000000204"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000918"), new DateOnly(2001, 1, 18), "", "Olivia", "", new Guid("00000000-0000-0000-0000-000000000204"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000919"), new DateOnly(2001, 1, 19), "", "Noah", "", new Guid("00000000-0000-0000-0000-000000000207"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000920"), new DateOnly(2002, 1, 20), "", "Emma", "", new Guid("00000000-0000-0000-0000-000000000207"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000921"), new DateOnly(2002, 1, 21), "", "Oliver", "", new Guid("00000000-0000-0000-0000-000000000207"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000922"), new DateOnly(2002, 1, 22), "", "Ava", "", new Guid("00000000-0000-0000-0000-000000000205"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000923"), new DateOnly(2002, 1, 23), "", "William", "", new Guid("00000000-0000-0000-0000-000000000205"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000924"), new DateOnly(2002, 1, 24), "", "Sophia", "", new Guid("00000000-0000-0000-0000-000000000205"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000925"), new DateOnly(2000, 1, 25), "", "Ethan", "", new Guid("00000000-0000-0000-0000-000000000208"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000926"), new DateOnly(2000, 1, 26), "", "Isabella", "", new Guid("00000000-0000-0000-0000-000000000208"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000927"), new DateOnly(2000, 1, 27), "", "James", "", new Guid("00000000-0000-0000-0000-000000000208"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000928"), new DateOnly(2003, 1, 28), "", "Lucas", "", new Guid("00000000-0000-0000-0000-000000000209"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000929"), new DateOnly(2003, 1, 29), "", "Mia", "", new Guid("00000000-0000-0000-0000-000000000209"), "Doe", null },
                    { new Guid("00000000-0000-0000-0000-000000000930"), new DateOnly(2003, 1, 30), "", "Alexander", "", new Guid("00000000-0000-0000-0000-000000000209"), "Doe", null }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourses",
                columns: new[] { "CourseId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000301"), new Guid("00000000-0000-0000-0000-000000000401") },
                    { new Guid("00000000-0000-0000-0000-000000000302"), new Guid("00000000-0000-0000-0000-000000000401") },
                    { new Guid("00000000-0000-0000-0000-000000000302"), new Guid("00000000-0000-0000-0000-000000000402") },
                    { new Guid("00000000-0000-0000-0000-000000000304"), new Guid("00000000-0000-0000-0000-000000000401") },
                    { new Guid("00000000-0000-0000-0000-000000000305"), new Guid("00000000-0000-0000-0000-000000000403") },
                    { new Guid("00000000-0000-0000-0000-000000000306"), new Guid("00000000-0000-0000-0000-000000000403") },
                    { new Guid("00000000-0000-0000-0000-000000000307"), new Guid("00000000-0000-0000-0000-000000000403") },
                    { new Guid("00000000-0000-0000-0000-000000000308"), new Guid("00000000-0000-0000-0000-000000000403") },
                    { new Guid("00000000-0000-0000-0000-000000000309"), new Guid("00000000-0000-0000-0000-000000000403") },
                    { new Guid("00000000-0000-0000-0000-000000000310"), new Guid("00000000-0000-0000-0000-000000000404") },
                    { new Guid("00000000-0000-0000-0000-000000000311"), new Guid("00000000-0000-0000-0000-000000000404") },
                    { new Guid("00000000-0000-0000-0000-000000000312"), new Guid("00000000-0000-0000-0000-000000000404") },
                    { new Guid("00000000-0000-0000-0000-000000000313"), new Guid("00000000-0000-0000-0000-000000000404") },
                    { new Guid("00000000-0000-0000-0000-000000000313"), new Guid("00000000-0000-0000-0000-000000000405") },
                    { new Guid("00000000-0000-0000-0000-000000000314"), new Guid("00000000-0000-0000-0000-000000000404") },
                    { new Guid("00000000-0000-0000-0000-000000000314"), new Guid("00000000-0000-0000-0000-000000000405") },
                    { new Guid("00000000-0000-0000-0000-000000000315"), new Guid("00000000-0000-0000-0000-000000000405") },
                    { new Guid("00000000-0000-0000-0000-000000000316"), new Guid("00000000-0000-0000-0000-000000000406") },
                    { new Guid("00000000-0000-0000-0000-000000000317"), new Guid("00000000-0000-0000-0000-000000000407") },
                    { new Guid("00000000-0000-0000-0000-000000000318"), new Guid("00000000-0000-0000-0000-000000000408") },
                    { new Guid("00000000-0000-0000-0000-000000000319"), new Guid("00000000-0000-0000-0000-000000000409") },
                    { new Guid("00000000-0000-0000-0000-000000000320"), new Guid("00000000-0000-0000-0000-000000000406") },
                    { new Guid("00000000-0000-0000-0000-000000000320"), new Guid("00000000-0000-0000-0000-000000000407") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCode",
                table: "Courses",
                column: "CourseCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DepartmentId",
                table: "Groups",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_DepartmentId",
                table: "Teachers",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Furniture");

            migrationBuilder.DropTable(
                name: "LabRooms");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
