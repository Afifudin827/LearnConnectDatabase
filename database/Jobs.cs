using System.Xml.Linq;

namespace BasicConnectivity.database;
class Jobs : ConnectionDatabase
{
    public int id { get; set; }
    public string? title { get; set; }
    public int min_salary { get; set; }
    public int max_salary { get; set; }

    public override string ToString()
    {
        return $"{id} - {title} - {min_salary} - {max_salary}";
    }
    public List<Jobs> GetAll()
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        var job = new List<Jobs>();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_jobs";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    job.Add(new Jobs
                    {
                        id = reader.GetInt32(0),
                        title = reader.GetString(1),
                        min_salary = reader.GetInt32(2),
                        max_salary = reader.GetInt32(3)
                    });
                }
                return job;
            }
            else
            {
                return new List<Jobs>();
            }

        }
        catch (Exception)
        {
            return new List<Jobs>();
        }
    }

    // GET BY ID: Region
    public Jobs GetById(int id)
    {
        Jobs job = new Jobs();
        using var connection = GetConnection();
        using var command = GetCommand();
        Jobs jobs = new Jobs();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_jobs where id = @PId";
        try
        {
            command.Parameters.Add(setParameter(id, "PId"));
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    job.id = reader.GetInt32(0);
                    job.title = reader.GetString(1);
                    job.min_salary = reader.GetInt32(2);
                    job.max_salary = reader.GetInt32(3);
                }
                return job;

            }
            else
            {
                return new Jobs();
            }

        }
        catch (Exception)
        {
            return new Jobs();
        }
    }

    // INSERT: Region
    public string Insert(int id, string title, int minSalary, int maxSalary)
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_jobs VALUES (@id,@title,@minSalary, @maxSalary);";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(title, "title"));
            command.Parameters.Add(setParameter(minSalary, "minSalary"));
            command.Parameters.Add(setParameter(maxSalary, "maxSalary"));

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
                return $"Error Transaction: {ex.Message}";
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    // UPDATE: Region
    public string Update(int id, string title, int minSalary, int maxSalary)
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_jobs set name = @title, min_salary= @minSalary, max_salary = @maxSalary  where id = @id;";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(title, "title"));
            command.Parameters.Add(setParameter(minSalary, "minSalary"));
            command.Parameters.Add(setParameter(maxSalary, "maxSalary"));

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
        using var connection = GetConnection();
        using var command = GetCommand();

        command.Connection = connection;
        command.CommandText = "DELETE FROM tbl_jobs where id = @id;";

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
                return $"Error Transaction: {ex.Message}";
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }



}
