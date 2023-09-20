using System.Data.SqlClient;

namespace BasicConnectivity.database;
class Employees : ConnectionDatabase
{
    public int id { get; set; }
    public string? first_name { get; set; }
    public string? last_name { get; set; }
    public string? email { get; set; }
    public string? phone_number { get; set; }
    public string? hire_date { get; set; }
    public int jobs_id { get; set; }
    public int salary { get; set; }
    public int commission_pct { get; set; }
    public int manager_id { get; set; }
    public int departemen_id { get; set; }

    public List<Employees> GetAll()
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        var employees = new List<Employees>();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_employees";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    employees.Add(new Employees
                    {
                        id = reader.GetInt32(0),
                        first_name = reader.GetString(1),
                        last_name = reader.GetString(2),
                        email = reader.GetString(3),
                        phone_number = reader.GetString(3),
                        hire_date = reader.GetString(3),
                        jobs_id = reader.GetInt32(3),
                        salary = reader.GetInt32(3),
                        commission_pct = reader.GetInt32(3),
                        manager_id = reader.GetInt32(3),
                        departemen_id = reader.GetInt32(3),
                    });
                }
                reader.Close();
                connection.Close();
                return employees;
            }
            else
            {
                reader.Close();
                connection.Close();
                return new List<Employees>();
            }

        }
        catch (Exception)
        {
            return new List<Employees>();
        }
    }

    // GET BY ID: Region
    public Employees GetById(int id)
    {
        Employees employees = new Employees();
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_employees where id = @PId";
        try
        {
            command.Parameters.Add(setParameter(id, "PId"));
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    employees.id = reader.GetInt32(0);
                    employees.first_name = reader.GetString(1);
                    employees.last_name = reader.GetString(2);
                    employees.email = reader.GetString(3);
                    employees.phone_number = reader.GetString(4);
                    employees.hire_date = reader.GetString(5);
                    employees.jobs_id = reader.GetInt32(6);
                    employees.salary = reader.GetInt32(7);
                    employees.commission_pct = reader.GetInt32(8);
                    employees.manager_id = reader.GetInt32(9);
                    employees.departemen_id = reader.GetInt32(10);
                }
                reader.Close();
                connection.Close();
                return employees;

            }
            else
            {
                reader.Close();
                connection.Close();
                return new Employees();
            }

        }
        catch (Exception)
        {
            return new Employees();
        }
    }

    // INSERT: Region
    public string Insert(int id, string firstName, string lastName, string email, string phoneNumber, string hireDate, int jobID, int salary, int commissionPCT, int managerID, int departemenID)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_employees VALUES (@id,@firstName,@lastName, @email, @phoneNumber, @hireDate, @jobID, @salary, @commissionPCT, @managerID, @departemenID);";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(firstName, "firstName"));
            command.Parameters.Add(setParameter(lastName, "lastName"));
            command.Parameters.Add(setParameter(email, "email"));
            command.Parameters.Add(setParameter(phoneNumber, "phoneNumber"));
            command.Parameters.Add(setParameter(hireDate, "hairDate"));
            command.Parameters.Add(setParameter(jobID, "jobID"));
            command.Parameters.Add(setParameter(salary, "salary"));
            command.Parameters.Add(setParameter(commissionPCT, "commissionPCT"));
            command.Parameters.Add(setParameter(managerID, "managerID"));
            command.Parameters.Add(setParameter(departemenID, "departemenID"));

            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                command.Transaction = transaction;

                var result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result.ToString();
            }
            catch (Exception ex)
            {
                connection.Close();
                transaction.Rollback();
                return $"Error Transaction: {ex.Message}";
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    // UPDATE: Region
    public string Update(int id, string firstName, string lastName, string email, string phoneNumber, string hireDate, int jobID, int salary, int commissionPCT, int managerID, int departemenID)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_employees set fisrt_name = @firstName,last_name = @lastName, email = @email, phone_number = @phoneNumber, hire_date = @hireDate, job_id = @jobID, salary = @salary, commission_pct = @commissionPCT, manager_id = @managerID, departements_id = @departemenID  where id = @id;";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(firstName, "firstName"));
            command.Parameters.Add(setParameter(lastName, "lastName"));
            command.Parameters.Add(setParameter(email, "email"));
            command.Parameters.Add(setParameter(phoneNumber, "phoneNumber"));
            command.Parameters.Add(setParameter(hireDate, "hairDate"));
            command.Parameters.Add(setParameter(jobID, "jobID"));
            command.Parameters.Add(setParameter(salary, "salary"));
            command.Parameters.Add(setParameter(commissionPCT, "commissionPCT"));
            command.Parameters.Add(setParameter(managerID, "managerID"));
            command.Parameters.Add(setParameter(departemenID, "departemenID"));

            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                command.Transaction = transaction;

                var result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result.ToString();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                return $"Error Transaction: {ex.Message}";
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    // DELETE: Region
    public string Delete(int id)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "DELETE FROM tbl_employees where id = @id;";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));

            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                command.Transaction = transaction;

                var result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

                return result.ToString();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                return $"Error Transaction: {ex.Message}";
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}

