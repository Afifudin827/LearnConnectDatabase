using BasicConnectivity.database;
using BasicConnectivity.Menu;
using BasicConnectivity.model;

namespace BasicConnectivity;

class Program
{
    public static void Main()
    {

        var choice = true;
        while (choice)
        {
            Console.WriteLine("1. List all regions");
            Console.WriteLine("2. List all countries");
            Console.WriteLine("3. List all locations");
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

    public static bool Menu(string input)
    {
        switch (input)
        {
            case "1":
                Console.Clear();
                var region = new Region();
                var regions = region.GetAll();
                GeneralMenu.List(regions, "regions");
                break;
            case "2":
                Console.Clear();
                var country = new Country();
                var countries = country.GetAll();
                GeneralMenu.List(countries, "countries");
                break;
            case "3":
                Console.Clear();
                var location = new Location();
                var locations = location.GetAll();
                GeneralMenu.List(locations, "locations");
                break;
            case "4":
                Console.Clear();
                var departement = new Departement();
                var departements = departement.GetAll();
                GeneralMenu.List(departements, "departemen");
                break;
            case "5":
                Console.Clear();
                var job = new Jobs();
                var jobs = job.GetAll();
                GeneralMenu.List(jobs, "job");
                break;
            case "6":
                Console.Clear();
                var jobHistory = new JobHistories();
                var jobHistories = jobHistory.GetAll();
                GeneralMenu.List(jobHistories, "job history");
                break;
            case "7":
                Console.Clear();
                var employee = new Employees();
                var employees = employee.GetAll();
                GeneralMenu.List(employees, "employees");
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

        GeneralMenu.List(resultEmployeesDetail, "Employees Detail");

    }

    public static void CountingEmployees()
    {
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

        GeneralMenu.List(resultEmployeesCount, "Employees Departement Count");
    }
}