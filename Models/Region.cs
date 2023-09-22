using System.Data;
using System.Data.SqlClient;

namespace BasicConnectivity.database;
public class Region : ConnectionDatabase
{
    public int id { get; set; }
    public string? name { get; set; }

    public override string ToString()
    {
        return $"{id} - {name}";
    }

    // GET ALL: Region
    public List<Region> GetAll()
    {
        using var connection = GetConnection();
        using var command = GetCommand();

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
        using var connection = GetConnection();
        using var command = GetCommand();

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
    public string Insert(Region region)
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_regions VALUES (@id,@name);";

        try
        {
            command.Parameters.Add(setParameter(region.id, "id"));
            command.Parameters.Add(setParameter(region.name, "name"));

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
    public string Update(Region region)
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_regions set name = @name where id = @id;";

        try
        {
            var pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.Value = region.name;
            pName.SqlDbType = SqlDbType.VarChar;
            command.Parameters.Add(pName);

            var pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.Value = region.id;
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
        using var connection = GetConnection();
        using var command = GetCommand();

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
