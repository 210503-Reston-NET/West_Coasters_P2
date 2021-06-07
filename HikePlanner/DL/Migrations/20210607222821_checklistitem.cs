using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class checklistitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItems_ChecklistId",
                table: "ChecklistItems",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistItems_EquipmentId",
                table: "ChecklistItems",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistItems_Checklists_ChecklistId",
                table: "ChecklistItems",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistItems_Equipments_EquipmentId",
                table: "ChecklistItems",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistItems_Checklists_ChecklistId",
                table: "ChecklistItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistItems_Equipments_EquipmentId",
                table: "ChecklistItems");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistItems_ChecklistId",
                table: "ChecklistItems");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistItems_EquipmentId",
                table: "ChecklistItems");
        }
    }
}
