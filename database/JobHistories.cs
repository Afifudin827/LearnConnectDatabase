using System.Data;
using System.Data.SqlClient;

namespace BasicConnectivity.database;
class JobHistories : ConnectionDatabase
{
    public int empolyees_id { get; set; }
    public int jobs_id { get; set; }
    public int departements_id { get; set; }
    public DateTime start_dates { get; set; }
    public DateTime end_dates { get; set; }

    public List<JobHistories> GetAll()
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        var jobHistory = new List<JobHistories>();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_jobs_history";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    jobHistory.Add(new JobHistories
                    {
                        empolyees_id = reader.GetInt32(0),
                        start_dates = reader.GetDateTime(1),
                        end_dates = reader.GetDateTime(2),
                        jobs_id = reader.GetInt32(3),
                        departements_id = reader.GetInt32(4),
                    });
                }
                reader.Close();
                connection.Close();
                return jobHistory;
            }
            else
            {
                reader.Close();
                connection.Close();
                return new List<JobHistories>();
            }

        }
        catch (Exception)
        {
            return new List<JobHistories>();
        }
    }

    // GET BY ID: Region
    public JobHistories GetById(int id, DateTime startDates)
    {
        JobHistories jobHistories = new JobHistories();
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_job_history where employees_id = @PId and start_dates = @startDates";
        try
        {
            command.Parameters.Add(setParameter(id, "PId"));
            command.Parameters.Add(setParameter(startDates, "startDates"));
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    jobHistories.empolyees_id = reader.GetInt32(0);
                    jobHistories.start_dates = reader.GetDateTime(1);
                    jobHistories.end_dates = reader.GetDateTime(2);
                    jobHistories.jobs_id = reader.GetInt32(3);
                    jobHistories.departements_id = reader.GetInt32(4);
                }
                reader.Close();
                connection.Close();
                return jobHistories;

            }
            else
            {
                reader.Close();
                connection.Close();
                return new JobHistories();
            }

        }
        catch (Exception)
        {
            return new JobHistories();
        }
    }

    // INSERT: Region
    public string Insert(int employeesID, string startDates, string endDates, int jobsID, int departementsID)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_departements VALUES (@employeesID , @startDates, @endDates ,@jobID, @departementsID);";

        try
        {
            command.Parameters.Add(setParameter(employeesID, "employeesID"));
            command.Parameters.Add(setParameter(startDates, "startDates"));
            command.Parameters.Add(setParameter(endDates, "endDates"));
            command.Parameters.Add(setParameter(jobsID, "jobID"));
            command.Parameters.Add(setParameter(departementsID, "departementsID"));

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
    public string Update(int employeesID, string startDates, string endDates, int jobsID, int departementsID)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_departements set end_dates = @endDates, jobs_id= @jobID, departemens_id= @departemenID where employees_id = @employeesID and start_dates = @startDates;";

        try
        {
            command.Parameters.Add(setParameter(employeesID, "employeesID"));
            command.Parameters.Add(setParameter(startDates, "startDates"));
            command.Parameters.Add(setParameter(endDates, "endDates"));
            command.Parameters.Add(setParameter(jobsID, "jobID"));
            command.Parameters.Add(setParameter(departementsID, "departemenID"));

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
    public string Delete(int id, string startDates)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "DELETE FROM tbl_departements where employees_id = @id and start_dates = @startDates;";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(startDates, "startDates"));

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
