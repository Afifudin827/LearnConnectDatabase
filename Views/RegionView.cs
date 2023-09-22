using BasicConnectivity.database;
using BasicConnectivity.Menu;

namespace BasicConnectivity.Views;
public class RegionView : GeneralMenu
{

    public Region InputRegion()
    {
        Console.WriteLine("Insert region id");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Insert region name");
        var name = Console.ReadLine();

        return new Region
        {
            id = id,
            name = name
        };
    }
}
