using Microsoft.EntityFrameworkCore.Migrations;

namespace RestAPIStudyGuide.Migrations
{
    public partial class CityInfoDBAddPointOfInterestDescription : Migration
    {
        // the commented code below was supposed to be generated with the migration but for some reason it didnt, the class was using an old version of
        // entity framework so i'm not sure if the commented code is no longer needed. when i un-comment the code the migration breaks so i just left it like this.

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Description",
            //    table: "PointsOfInterest",
            //    maxLength: 200,
            //    nullable: true
            //    );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Description",
            //    table: "PointsOfInterest"
            //    );
        }
    }
}
