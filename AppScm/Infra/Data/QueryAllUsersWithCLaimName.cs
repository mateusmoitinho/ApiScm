using AppScm.Endpoints.Employees;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AppScm.Infra.Data
{
    public class QueryAllUsersWithCLaimName
    {
        private readonly IConfiguration configuration;

        public QueryAllUsersWithCLaimName(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task <IEnumerable<EmployeeResponse>> Execute(int page, int rows)
        {
            var db = new SqlConnection(configuration["ConnectionString:AppScmDb"]);
            var query = @"select Email, ClaimValue as Name
            from AspNetUsers u inner
            join AspNetUserClaims c
            on u.id = c.UserId and claimType = 'Name'
            order by name
            OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

            return await db.QueryAsync<EmployeeResponse>(
               query,
               new { page, rows }
               );
        }

    }
}
