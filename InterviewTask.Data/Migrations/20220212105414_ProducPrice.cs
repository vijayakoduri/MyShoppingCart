using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewTask.Data.Migrations
{
    public partial class ProducPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Product",
                type: "float",
                nullable: true);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            
        }
    }
}
