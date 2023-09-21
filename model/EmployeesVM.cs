using BasicConnectivity.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.model;
class EmployeesVM
{
    public int employeeID { get; set; }
    public string fullName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public int salary { get; set; }
    public string departementName { get; set; }
    public string streetAddress { get; set; }
    public string countryName { get; set; }
    public string regionName { get; set; }


    public override string ToString()
    {
        return $"{employeeID} - {fullName} - {email} - {phone} - {salary} - {departementName} - {streetAddress} - {countryName} - {regionName}";
    }
}
