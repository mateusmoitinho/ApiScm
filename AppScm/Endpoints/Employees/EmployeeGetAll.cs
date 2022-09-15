using AppScm.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace AppScm.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;


    [Authorize(Policy ="EmployeePolicy")]
    public static async Task <IResult> Action(int? page,int? rows, QueryAllUsersWithCLaimName query)
    {
       
     
        var result = await query.Execute(page.Value, rows.Value);
        return Results.Ok(result);
    }


}
