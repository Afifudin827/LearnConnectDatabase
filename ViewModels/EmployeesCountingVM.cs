using BasicConnectivity.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BasicConnectivity.model;
class EmployeesCountingVM
{
    public string departementName {  get; set; }
    public int totalEmployees { get; set;}
    public int minSalary { get; set; }
    public int maxSalary {  get; set; }
    public double avarageSalary { get; set; }

    public override string ToString()
    {
        return $"{departementName} - {totalEmployees} - {minSalary} - {maxSalary} - {avarageSalary}";
    }
}
