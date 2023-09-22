using BasicConnectivity.database;
using BasicConnectivity.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.Controllers;
class CountryControllers
{
    private Country _country;
    private CountryViews _countryView;

    public CountryControllers(Country country, CountryViews countryViews)
    {
        _country= country;
        _countryView = countryViews;
    }

    public void getAll()
    {
        var results = _country.GetAll();
        if (!results.Any())
        {
            Console.WriteLine("No data found");
        }
        else
        {
            _countryView.List(results, "country");
        }
    }

    public void Insert()
    {
        var resultRegion = _country;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                resultRegion = _countryView.InputCountry();
                if (string.IsNullOrEmpty(resultRegion.name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                if (resultRegion.id.Equals(null) || resultRegion.id.Equals(0))
                {
                    Console.WriteLine("Country ID cannot be empty");
                    continue;
                }
                if (resultRegion.region_id.Equals(null) || resultRegion.region_id.Equals(0))
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

        var result = _country.Insert(new Country
        {
            id = resultRegion.id,
            name = resultRegion.name,
            region_id = resultRegion.region_id,
        });

        _countryView.Transaction(result);
    }
    public void Update()
    {
        var country = new Country();
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                country = _countryView.InputCountry();
                if (string.IsNullOrEmpty(country.name))
                {
                    Console.WriteLine("Country name cannot be empty");
                    continue;
                }
                if (country.region_id.Equals(null) || country.region_id.Equals(0))
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

        var result = _country.Update(country);
        _countryView.Transaction(result);
    }

    public void Delete()
    {
        var id = 0;
        var isTrue = true;
        while (isTrue)
        {
            try
            {
                id = _countryView.IDInput();
                if (id.Equals(null))
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

        var result = _country.Delete(id);

        _countryView.Transaction(result);
    }
}
