using System.Data.SqlClient;

namespace BasicConnectivity.database;
class Country : ConnectionDatabase
{
    public int id { get; set; }
    public string? name { get; set; }
    public int region_id { get; set; }

    public List<Country> GetAll()
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        var country = new List<Country>();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_country";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    country.Add(new Country
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        region_id = reader.GetInt32(2)
                    });
                }
                return country;
            }
            else
            {
                return new List<Country>();
            }

        }
        catch (Exception)
        {
            return new List<Country>();
        }
    }

    // GET BY ID: Region
    public Country GetById(int id)
    {
        Country country = new Country();
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_country where id = @PId";
        try
        {
            command.Parameters.Add(setParameter(id, "PId"));

            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    country.id = reader.GetInt32(0);
                    country.name = reader.GetString(1);
                    country.region_id = reader.GetInt32(2);
                }
                connection.Close();
                return country;
            }
            else
            {
                connection.Close();
                return new Country();
            }


        }
        catch (Exception)
        {
            return new Country();
        }
    }

    // INSERT: Region
    public string Insert(int id, string name, int regionID)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_country VALUES (@id,@name,@regionId);";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(name, "name"));
            command.Parameters.Add(setParameter(regionID, "regionId"));

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
    public string Update(int id, string name, string regionId)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_country set name = @name, region_id= @regionId  where id = @id;";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(name, "name"));
            command.Parameters.Add(setParameter(regionId, "regionId"));

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
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "DELETE FROM tbl_country where id = @id;";

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
