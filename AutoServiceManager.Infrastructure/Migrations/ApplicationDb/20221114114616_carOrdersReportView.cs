using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoServiceManager.Infrastructure.Migrations.ApplicationDb
{
    public partial class carOrdersReportView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    CREATE VIEW [dbo].CarOrdersReportView
                                        AS SELECT 
		                                co.Id as CarOrderId, 
	                                    co.Date as CarOrderDate, 
	                                    (c.Make + ' / ' + c.Color + ' / ' + c.Plate) as CarData,
	                                    co.Description as CarOrderDescription,
	                                    (u.FirstName + ' ' + u.LastName) as UserFullName, 
		                                u.Email as UserEmail
		                                    FROM [AutoServiceManager].[dbo].[CarOrders] co 
			                                INNER JOIN [AutoServiceManager].[Identity].[Users] u
					                                    ON co.CreatedBy = u.Id
			                                INNER JOIN [AutoServiceManager].[dbo].[Cars] c 
					                                    ON co.CarId = c.Id; 
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql(@"DROP VIEW [dbo].CarOrdersReportView;");
        }
    }
}
