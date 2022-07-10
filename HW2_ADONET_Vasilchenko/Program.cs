using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using HW2_ADONET_Vasilchenko.Models;
using HW2_ADONET_Vasilchenko.DataLayer;

namespace HW2_ADONET_Vasilchenko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DL.Employee.EmployeeAdd();
            DL.Employee.EmployeeDelete();
            DL.Employee.EmployeeUpdate();

            ReadKey();
        }
    }
}
