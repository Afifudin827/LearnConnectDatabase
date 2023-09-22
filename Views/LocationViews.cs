using BasicConnectivity.database;
using BasicConnectivity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Views;
public class LocationViews : GeneralMenu
{
    public Location inputLocation()
    {
        Console.Write("Insert location id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Insert street address");
        var streetAddress = Console.ReadLine();
        Console.Write("Insert postal code");
        var postalCode = Console.ReadLine();
        Console.Write("Insert city");
        var city = Console.ReadLine();
        Console.Write("Insert state province");
        var stateProvince = Console.ReadLine();
        Console.Write("Insert country ID");
        var countryID = Convert.ToInt32(Console.ReadLine());


        return new Location
        {
            id = id,
            street_address = streetAddress,
            postal_code = postalCode,
            city = city,    
            state_province = stateProvince,
            country_id = countryID
            
        };
    }
}
