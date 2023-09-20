using BasicConnectivity.database;

namespace BasicConnectivity;

class Program
{
    public static void Main()
    {
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
        JobHistories jobHistories = new JobHistories();
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
        Console.WriteLine("ID           : " + jobHistories.GetById(8, Convert.ToDateTime("11/03/2021")).departements_id);
        Console.WriteLine("Title        : " + jobHistories.GetById(8, Convert.ToDateTime("11/03/2021")).start_dates);
        Console.WriteLine("Min Salary   : " + jobHistories.GetById(8, Convert.ToDateTime("11/03/2021")).end_dates);
        Console.WriteLine("Max Salary   : " + jobHistories.GetById(8, Convert.ToDateTime("11/03/2021")).jobs_id);
        Console.WriteLine("Max Salary   : " + jobHistories.GetById(8, Convert.ToDateTime("11/03/2021")).departements_id);

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


}