using bookapi.Data;
using bookapi.Model;
using Dapper;

namespace bookapi.Service
{
    public interface IBookService
    {
        public bool Addemployees(employees organization);
    }

    public class BookService : BookServiceBase, IBookService
    {
        private readonly RPayDBContext context;
        private string id;

        public BookService(RPayDBContext context)
        {
            this.context = context;
        }
        public bool Addemployees(employees organization)
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                var query_insert = "INSERT INTO employees (employees_name,employees_code,employees_dept,employees_address," +
                    "employees_phone_number,date_of_birth,employees_salary) VALUES (" + organization.employee_name + "," +
                    "" + organization.employee_code + "," + organization.employee_dept + "," + organization.employee_address + "," +
                    "" + organization.employee_phone_number + "," + organization.date_of_birth + "," + organization.employee_salary + ");";
                var executed_rows = connection.Execute(query_insert);
                connection.Close();
                if (executed_rows > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
            }
        }

        public  List<employees> GetOrganization(employees organization)
        {
            using (var connection = context.CreateConnection())
            {
                connection.Open();
                try
                {
                    var query = "SELECT employee_name,employee_code FROM Organization WHERE employee_code=" + id + " AND is_active='1' ORDER BY employee_name Asc;";
                    return connection.Query<employees>(query).ToList();
                }
                catch
                {
                   
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
