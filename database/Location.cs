
namespace BasicConnectivity.database;
internal class Location : ConnectionDatabase
{
    public int id { get; set; }
    public string? street_address { get; set; }
    public string? city { get; set; }
    public string? postal_code { get; set; }
    public int country_id { get; set; }
    public string? state_province { get; set; }

    public override string ToString()
    {
        return $"{id} - {street_address} - {city} - {postal_code} - {country_id} - {state_province}";
    }
    public List<Location> GetAll()
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        var location = new List<Location>();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_location";

        try
        {
            connection.Open();

            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    location.Add(new Location
                    {
                        id = reader.GetInt32(0),
                        street_address = reader.GetString(1),
                        postal_code = reader.GetString(2),
                        city = reader.GetString(3),
                        state_province = reader.GetString(4),
                        country_id = reader.GetInt32(5),
                    });
                }
                return location;
            }
            else
            {
                return new List<Location>();
            }

        }
        catch (Exception)
        {
            return new List<Location>();
        }
    }

    // GET BY ID: Region
    public Location GetById(int id)
    {
        Location location = new Location();
        using var connection = GetConnection();
        using var command = GetCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM tbl_location where id = @PId";
        try
        {
            command.Parameters.Add(setParameter(id, "PId"));
            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    location.id = reader.GetInt32(0);
                    location.street_address = reader.GetString(1);
                    location.postal_code = reader.GetString(2);
                    location.city = reader.GetString(3);
                    location.state_province = reader.GetString(4);
                    location.country_id = reader.GetInt32(5);
                }
                return location;

            }
            else
            {
                return new Location();
            }

        }
        catch (Exception)
        {
            return new Location();
        }
    }

    // INSERT: Region
    public string Insert(int id, string streetAddress, string postalCode, string city, string stateProvince, int countryID)
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        command.Connection = connection;
        command.CommandText = "INSERT INTO tbl_location VALUES (@id,@streetAddress,@postalCode, @city, @stateProvince, @countryID);";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(streetAddress, "streetAddress"));
            command.Parameters.Add(setParameter(postalCode, "postalCode"));
            command.Parameters.Add(setParameter(city, "city"));
            command.Parameters.Add(setParameter(stateProvince, "stateProvince"));
            command.Parameters.Add(setParameter(countryID, "countryID"));

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
    public string Update(int id, string streetAddress, string postalCode, string city, string stateProvince, int countryID)
    {
        using var connection = GetConnection();
        using var command = GetCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE tbl_location set street_address = @streetAddress, postal_code= @postalCode, city = @city, state_province = @StateProvince, country_id = @countryID where id = @id;";

        try
        {
            command.Parameters.Add(setParameter(id, "id"));
            command.Parameters.Add(setParameter(streetAddress, "streetAddress"));
            command.Parameters.Add(setParameter(postalCode, "postalCode"));
            command.Parameters.Add(setParameter(city, "city"));
            command.Parameters.Add(setParameter(stateProvince, "stateProvince"));
            command.Parameters.Add(setParameter(countryID, "countryID"));

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
        command.CommandText = "DELETE FROM tbl_location where id = @id;";

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
