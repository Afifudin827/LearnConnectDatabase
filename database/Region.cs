using System.Data;
using System.Data.SqlClient;

namespace BasicConnectivity.database;
class Region : ConnectionDatabase
{
    public int id { get; set; }
    public string? name { get; set; }


    // GET ALL: Region
    public List<Region> GetAll()
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        var regions = new List<Region>();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_regions";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    regions.Add(new Region
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1)
                    });
                }
                return regions;
            }
            else
            {
                return new List<Region>();
            }

        }
        catch (Exception)
        {
            return new List<Region>();
        }
    }

    // GET BY ID: Region
    public Region GetById(int id)
    {
        Region region = new Region();
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_regions where id = @PId";
        try
        {
            command.Parameters.Add(setParameter(id, "PId"));

            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    region.id = reader.GetInt32(0);
                    region.name = reader.GetString(1);
                }
                reader.Close();
                connection.Close();
                return region;
            }
            else
            {
                reader.Close();
                connection.Close();
                return new Region();
            }

        }
        catch (Exception)
        {
            return new Region();
        }
    }

    // INSERT: Region
    public string Insert(int id, string name)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_regions VALUES (@id,@name);";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(name, "name"));

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
    public string Update(int id, string name)
    {
        using var connection = new SqlConnection(dbString);
        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_regions set name = @name where id = @id;";

        try
        {
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = name;
            pName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pName);

            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pId);

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
        command.CommandText = "DELETE FROM tbl_regions where id = @id;";

        try
        {
            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = id;
            pId.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pId);

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
