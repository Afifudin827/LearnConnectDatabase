using BasicConnectivity.database;
using BasicConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers;
public class LocationControllers
{
    private Location _location;
    private LocationViews _locationView;

    public LocationControllers(Location location, LocationViews locationViews)
    {
        _location = location;
        _locationView = locationViews;
    }

    public void getAll()
    {
        var results = _location.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _locationView.List(results, "location");
        }
    }

    public void Insert()
    {
        var resultlocation = _location;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                resultlocation = _locationView.inputLocation();
                if (string.IsNullOrEmpty(resultlocation.street_address))
                {
                    Console.WriteLine("Location street address cannot be empty");
                    continue;
                }
                if (string.IsNullOrEmpty(resultlocation.postal_code))
                {
                    Console.WriteLine("Location postal code cannot be empty");
                    continue;
                }
                if (string.IsNullOrEmpty(resultlocation.city))
                {
                    Console.WriteLine("Location city cannot be empty");
                    continue;
                }
                if (string.IsNullOrEmpty(resultlocation.state_province))
                {
                    Console.WriteLine("Location state province cannot be empty");
                    continue;
                }
                if (resultlocation.id.Equals(null) || resultlocation.id.Equals(0))
                {
                    Console.WriteLine("Location ID cannot be empty");
                    continue;
                }
                if (resultlocation.country_id.Equals(null) || resultlocation.country_id.Equals(0))
                {
                    Console.WriteLine("Country ID cannot be empty");
                    continue;
                }

                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Insert(new Location
        {
            id = resultlocation.id,
            street_address = resultlocation.street_address,
            postal_code = resultlocation.postal_code,
            city = resultlocation.city,
            state_province = resultlocation.state_province,
            country_id = resultlocation.country_id
        });

        _locationView.Transaction(result);
    }
    public void Update()
    {
        var location = new Location();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                location = _locationView.inputLocation();
                if (string.IsNullOrEmpty(location.street_address))
                {
                    Console.WriteLine("Location street address cannot be empty");
                    continue;
                }
                if (string.IsNullOrEmpty(location.postal_code))
                {
                    Console.WriteLine("Location postal code cannot be empty");
                    continue;
                }
                if (string.IsNullOrEmpty(location.city))
                {
                    Console.WriteLine("Location city cannot be empty");
                    continue;
                }
                if (string.IsNullOrEmpty(location.state_province))
                {
                    Console.WriteLine("Location state province cannot be empty");
                    continue;
                }
                if (location.country_id.Equals(null) || location.country_id.Equals(0))
                {
                    Console.WriteLine("Country ID cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Update(location);
        _locationView.Transaction(result);
    }

    public void Delete()
    {
        var id = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                id = _locationView.IDInput();
                if (id.Equals(null))
                {
                    Console.WriteLine("Location ID cannot be empty");
                    continue;
                }

                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _location.Delete(id);

        _locationView.Transaction(result);
    }
}
