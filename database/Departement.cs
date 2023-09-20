using System.Data.SqlClient;

namespace BasicConnectivity.database;
class Departement : ConnectionDatabase
{
    public int id { get; set; }
    public string? name { get; set; }
    public int manager_id { get; set; }
    public int location_id { get; set; }

    public List<Departement> GetAll()
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        var departements = new List<Departement>();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_departements";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    departements.Add(new Departement
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        manager_id = reader.GetInt32(2),
                        location_id = reader.GetInt32(3)
                    });
                }
                reader.Close();
                connection.Close();
                return departements;
            }
            else
            {
                reader.Close();
                connection.Close();
                return new List<Departement>();
            }


        }
        catch (Exception)
        {
            return new List<Departement>();
        }
    }

    // GET BY ID: Region
    public Departement GetById(int id)
    {
        Departement departement = new Departement();
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_departements where id = @PId";
        try
        {
            command.Parameters.Add(setParameter(id, "PId"));
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    departement.id = reader.GetInt32(0);
                    departement.name = reader.GetString(1);
                    departement.manager_id = reader.GetInt32(2);
                    departement.location_id = reader.GetInt32(3);
                }
                reader.Close();
                connection.Close();
                return departement;

            }
            else
            {
                reader.Close();
                connection.Close();
                return new Departement();
            }

        }
        catch (Exception)
        {
            return new Departement();
        }
    }

    // INSERT: Region
    public string Insert(int id, string name, int departemenID, int locationID)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_departements VALUES (@id,@name,@departemenID, @locationID);";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(name, "name"));
            command.Parameters.Add(setParameter(departemenID, "departemenID"));
            command.Parameters.Add(setParameter(locationID, "locationID"));

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
    public string Update(int id, string name, int departemenID, int locationID)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_departements set name = @name, departemen_id= @departemenID , location_id= @locationID  where id = @id;";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(name, "name"));
            command.Parameters.Add(setParameter(departemenID, "departemenID"));
            command.Parameters.Add(setParameter(locationID, "locationID"));

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
        command.CommandText = "DELETE FROM tbl_departements where id = @id;";

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
