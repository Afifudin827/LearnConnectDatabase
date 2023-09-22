using BasicConnectivity.database;
using BasicConnectivity.Views;

namespace BasicConnectivity.Controllers;
public class RegionControllers
{
    private Region _region;
    private RegionView _regionView;

    public RegionControllers(Region region  , RegionView regionView)
    {
        _region = region;
        _regionView = regionView;
    }

    public void getAll()
    {
        var results = _region.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _regionView.List(results, "regions");
        }
    }

    public void Insert()
    {
        var resultRegion = _region;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                resultRegion = _regionView.InputRegion();
                if (string.IsNullOrEmpty(resultRegion.name))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                if (resultRegion.id.Equals(null) || resultRegion.id.Equals(0))
                {
                    Console.WriteLine("Region ID cannot be empty");
                    continue;
                }
                
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Insert(new Region
        {
            id = resultRegion.id,
            name = resultRegion.name
        });

        _regionView.Transaction(result);
    }
    public void Update()
    {
        var region = new Region();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                region = _regionView.InputRegion();
                if (string.IsNullOrEmpty(region.name))
                {
                    Console.WriteLine("Region name cannot be empty");
                    continue;
                }
                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Update(region);
        _regionView.Transaction(result);
    }

    public void Delete()
    {
        var id = 0 ;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                id = _regionView.IDInput();
                if (id.Equals(null))
                {
                    Console.WriteLine("Region ID cannot be empty");
                    continue;
                }

                isTrue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var result = _region.Delete(id);

        _regionView.Transaction(result);
    }
}
