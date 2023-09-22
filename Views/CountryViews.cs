using BasicConnectivity.database;
using BasicConnectivity.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Views;
class CountryViews : GeneralMenu
{
    public Country InputCountry()
    {
        Console.WriteLine("Insert country id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert country name");
        var name = Console.ReadLine();
        Console.WriteLine("Insert region id");
        var idRegion = Convert.ToInt32(Console.ReadLine());

        return new Country
        {
            id = id,
            name = name,
            region_id = idRegion
        };
    }
}
