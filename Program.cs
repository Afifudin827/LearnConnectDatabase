using BasicConnectivity.Controllers;
using BasicConnectivity.database;
using BasicConnectivity.Menu;
using BasicConnectivity.model;
using BasicConnectivity.Views;

namespace BasicConnectivity;

class Program
{
    public static void Main()
    {

        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. Regions");
            Console.WriteLine("2. Countries");
            Console.WriteLine("3. Locations");
            Console.WriteLine("4. List all departements");
            Console.WriteLine("5. List all job");
            Console.WriteLine("6. List all job histories");
            Console.WriteLine("7. List all employees");
            Console.WriteLine("8. Employees Detail");
            Console.WriteLine("10. Exit");
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            choice = Menu(input);
        }
    }

    public static bool Menu(string input)
    {
        switch (input)
        {
            case "1":
                Console.Clear();
                RegionMenu();
                break;
            case "2":
                CountryMenu();
                Console.Clear();
                break;
            case "3":
                Console.Clear();
                LocationMenu();
                break;
            case "4":
                Console.Clear();
                break;
            case "5":
                Console.Clear();
                break;
            case "6":
                break;
            case "7":
                Console.Clear();
                break;
            case "8":
                Console.Clear();
                EmployeesDetail();
                break;
            case "9":
                Console.Clear();
                CountingEmployees();
                break;
            case "10":
                return false;
            default:
                Console.WriteLine();
                Console.WriteLine("Invalid choice");
                break;
        }
        return true;
    }

    public static void EmployeesDetail()
    {
        var generalMenu = new GeneralMenu();

        var employee = new Employees();
        var departemen = new Departement();
        var location = new Location();
        var region = new Region();
        var country = new Country();

        var getEmployees = employee.GetAll();
        var getDepartements = departemen.GetAll();
        var getLocations = location.GetAll();
        var getRegions = region.GetAll();
        var getCountry = country.GetAll();

        var resultEmployeesDetail = getEmployees.Join(
            getDepartements,
            e => e.departemen_id,
            d => d.id,
            (e, d) => new { e, d }).Join(
                getLocations,
                ed => ed.d.location_id,
                l => l.id,
                (ed, l) => new { ed, l }).Join(
                    getCountry,
                    edl => edl.l.country_id,
                    c => c.id,
                    (edl, c) => new { edl, c }).Join(
                        getRegions,
                        edlc => edlc.c.region_id,
                        r => r.id,
                        (edlc, r) => new EmployeesVM
                        {
                            employeeID = edlc.edl.ed.e.id,
                            fullName = edlc.edl.ed.e.first_name + " " + edlc.edl.ed.e.last_name,
                            email = edlc.edl.ed.e.email,
                            phone = edlc.edl.ed.e.phone_number,
                            salary = edlc.edl.ed.e.salary,
                            departementName = edlc.edl.ed.d.name,
                            streetAddress = edlc.edl.l.street_address,
                            countryName = edlc.c.name,
                            regionName = r.name

                        }).ToList();

        generalMenu.List(resultEmployeesDetail, "Employees Detail");

    }

    public static void CountingEmployees()
    {
        var generalMenu = new GeneralMenu();
        var employee = new Employees();
        var departemen = new Departement();

        var getEmployees = employee.GetAll();
        var getDepartements = departemen.GetAll();

        var resultEmployeesCount =
            (from d in getDepartements
             join e in getEmployees on d.id equals e.departemen_id
             group e by d.name into g
             where g.Count() > 3
             select new EmployeesCountingVM
             {
                 departementName = g.Key,
                 totalEmployees = g.Count(),
                 minSalary = g.Min(e => e.salary),
                 maxSalary = g.Max(e => e.salary),
                 avarageSalary = g.Average(e => e.salary)
             }).ToList();

        generalMenu.List(resultEmployeesCount, "Employees Departement Count");
    }

    public static void RegionMenu()
    {
        var region = new Region();
        var regionView = new RegionView();

        var regionController = new RegionControllers(region, regionView);

        bool program = true;
        while (program)
        {
            Console.WriteLine("1. Select all regions");
            Console.WriteLine("2. Insert new region");
            Console.WriteLine("3. Update region");
            Console.WriteLine("4. Delete region");
            Console.WriteLine("10. Back");
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    Console.Clear();
                    regionController.getAll();
                    break;
                case "2":
                    Console.Clear();
                    regionController.Insert();
                    break;
                case "3":
                    Console.Clear();
                    regionController.Update();
                    break;
                case "4":
                    Console.Clear();
                    regionController.Delete();
                    break;
                case "10":
                    program = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    public static void CountryMenu()
    {
        var country = new Country();
        var countryView = new CountryViews();

        var countryControllers = new CountryControllers(country, countryView);

        bool program = true;
        while (program)
        {
            Console.WriteLine("1. Select all country");
            Console.WriteLine("2. Insert new country");
            Console.WriteLine("3. Update country");
            Console.WriteLine("4. Delete country");
            Console.WriteLine("10. Back");
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    Console.Clear();
                    countryControllers.getAll();
                    break;
                case "2":
                    Console.Clear();
                    countryControllers.Insert();
                    break;
                case "3":
                    Console.Clear();
                    countryControllers.Update();
                    break;
                case "4":
                    Console.Clear();
                    countryControllers.Delete();
                    break;
                case "10":
                    program = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }









        /*Manage Data Region*/
        //Region region = new Region();
        //show All Data Region
        /*foreach (var item in region.GetAll())
        {
            Console.WriteLine("ID   : " + item.id);
            Console.WriteLine("Name : " + item.name);
        }*/

        //Get Data Region By ID
        /*Console.WriteLine("ID   : " + region.GetById(4).id);
        Console.WriteLine("Name : " + region.GetById(4).name);*/

        //Insert Data Region
        /*var insertResult = region.Insert(6, "Antartika");
        int.TryParse(insertResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Insert Success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
            Console.WriteLine(insertResult);
        }*/

        //Delete Data Region
        /*var deleteResult = region.Delete(6);
        int.TryParse(deleteResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Delete Success");
        }
        else
        {
            Console.WriteLine("Delete Failed");
            Console.WriteLine(deleteResult);
        }*/


        /*Manage data Country*/
        //Country country = new Country();
        /*Show All Data*/
        /*foreach (var item in country.GetAll())
        {
            Console.WriteLine("ID   : " + item.id);
            Console.WriteLine("Name : " + item.name);
            Console.WriteLine("Name : " + item.region_id);
        }*/

        /*Get Data By ID*/
        /*Console.WriteLine("ID   : " + country.GetById(10).id);
        Console.WriteLine("Name : " + country.GetById(10).name);*/

        /*Inset Data To Country*/
        /*var insertResult = country.Insert(11, "China", 2);
        int.TryParse(insertResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Insert Success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
            Console.WriteLine(insertResult);
        }*/

        /*Delete data from Country*/
        /*var deleteResult = country.Delete(11);
        int.TryParse(deleteResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Delete Success");
        }
        else
        {
            Console.WriteLine("Delete Failed");
            Console.WriteLine(deleteResult);
        }*/


        /*Manage data location*/
        //Location location = new Location();
        /*Show All Data*/
        /*foreach (var item in location.GetAll())
        {
            Console.WriteLine("ID               : " + item.id);
            Console.WriteLine("Street Address   : " + item.street_address);
            Console.WriteLine("Postal Code      : " + item.postal_code);
            Console.WriteLine("City             : " + item.city);
            Console.WriteLine("State Province   : " + item.state_province);
            Console.WriteLine("Country ID       : " + item.country_id);
        }*/

        /*Get Data By ID*/
        /*Console.WriteLine("ID               : " + location.GetById(4).id);
        Console.WriteLine("Street Address   : " + location.GetById(4).street_address);
        Console.WriteLine("Postal Code      : " + location.GetById(4).postal_code);
        Console.WriteLine("City             : " + location.GetById(4).city);
        Console.WriteLine("State Province   : " + location.GetById(4).state_province);
        Console.WriteLine("Country ID       : " + location.GetById(4).country_id);*/

        /*Inset Data To Location*/
        /*var insertResult = location.Insert(11, "Jl. Imam Bonjol", "3513131", "Pemalang", "Jawa Tengah", 1);
        int.TryParse(insertResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Insert Success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
            Console.WriteLine(insertResult);
        }*/

        /*Delete data from Country*/
        /*var deleteResult = location.Delete(11);
        int.TryParse(deleteResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Delete Success");
        }
        else
        {
            Console.WriteLine("Delete Failed");
            Console.WriteLine(deleteResult);
        }*/


        /*Manage data jobs*/
        //Jobs jobs = new Jobs();
        /*Show All Data*/
        /*foreach (var item in jobs.GetAll())
        {
            Console.WriteLine("ID           : " + item.id);
            Console.WriteLine("Title        : " + item.title);
            Console.WriteLine("Min Salary   : " + item.min_salary);
            Console.WriteLine("Max Salary   : " + item.max_salary);
        }*/

        /*Get Data By ID*/
        /*Console.WriteLine("ID           : " + jobs.GetById(2).id);
        Console.WriteLine("Title        : " + jobs.GetById(2).title);
        Console.WriteLine("Min Salary   : " + jobs.GetById(2).min_salary);
        Console.WriteLine("Max Salary   : " + jobs.GetById(2).max_salary);*/

        /*Inset Data To Jobs*/
        /*var insertResult = jobs.Insert(11, "IT Conditional", 5600000, 7000000);
        int.TryParse(insertResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Insert Success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
            Console.WriteLine(insertResult);
        }*/

        /*Delete data from Country*/
        /*var deleteResult = jobs.Delete(11);
        int.TryParse(deleteResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Delete Success");
        }
        else
        {
            Console.WriteLine("Delete Failed");
            Console.WriteLine(deleteResult);
        }*/


        /*Manage data jobs History*/
        //JobHistories jobHistories = new JobHistories();
        /*Show All Data*/
        /*foreach (var item in jobHistories.GetAll())
        {
            Console.WriteLine("Employees ID : " + item.empolyees_id);
            Console.WriteLine("Start Date   : " + item.start_dates);
            Console.WriteLine("End Date     : " + item.end_dates);
            Console.WriteLine("Job ID       : " + item.jobs_id);
            Console.WriteLine("Departemen ID: " + item.departements_id);
        }*/

        /*Get Data By ID*/
        /*Console.WriteLine("Employee ID: " + jobHistories.GetById(20, "2021-01-04").empolyees_id);
        Console.WriteLine("Start Date   : " + jobHistories.GetById(20, "2021-01-04").start_dates);
        Console.WriteLine("End Date     : " + jobHistories.GetById(20, "2021-01-04").end_dates);
        Console.WriteLine("Job ID       : " + jobHistories.GetById(20, "2021-01-04").jobs_id);
        Console.WriteLine("Departemen ID: " + jobHistories.GetById(20, "2021-01-04").departements_id);*/

        //Inset Data To Jobs
        /*var insertResult = jobs.Insert(11, "IT Conditional", 5600000, 7000000);
        int.TryParse(insertResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Insert Success");
        }
        else
        {
            Console.WriteLine("Insert Failed");
            Console.WriteLine(insertResult);
        }*/

        /*Delete data from Country*/
        /*var deleteResult = jobs.Delete(11);
        int.TryParse(deleteResult, out int result);
        if (result > 0)
        {
            Console.WriteLine("Delete Success");
        }
        else
        {
            Console.WriteLine("Delete Failed");
            Console.WriteLine(deleteResult);
        }*/
    }

    public static void LocationMenu()
    {
        var location = new Location();
        var locationView = new LocationViews();

        var locationControllers = new LocationControllers(location, locationView);

        bool program = true;
        while (program)
        {
            Console.WriteLine("1. Select all location");
            Console.WriteLine("2. Insert new location");
            Console.WriteLine("3. Update location");
            Console.WriteLine("4. Delete location");
            Console.WriteLine("10. Back");
            Console.Write("Enter your choice: ");
            var input2 = Console.ReadLine();
            switch (input2)
            {
                case "1":
                    Console.Clear();
                    locationControllers.getAll();
                    break;
                case "2":
                    Console.Clear();
                    locationControllers.Insert();
                    break;
                case "3":
                    Console.Clear();
                    locationControllers.Update();
                    break;
                case "4":
                    Console.Clear();
                    locationControllers.Delete();
                    break;
                case "10":
                    program = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
}