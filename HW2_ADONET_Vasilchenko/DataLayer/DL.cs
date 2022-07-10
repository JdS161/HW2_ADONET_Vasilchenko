using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HW2_ADONET_Vasilchenko.Models;
using System.Configuration;

namespace HW2_ADONET_Vasilchenko.DataLayer
{
    internal class DL
    {
        public static string сonnectionString { get; set; } = ConfigurationManager.ConnectionStrings["CompanyDB"].ConnectionString;

        public static class Employee
        {
           
            public static void EmployeeAdd()
            {
                Console.Write("Employee's FIRST NAME: ");
                string employeeFN = Console.ReadLine();

                Console.Write("Employee's LAST NAME: ");
                string employeeLN = Console.ReadLine();

                Console.Write("Employee's DATE OF BIRTH: ");
                DateTime employeeDoB = DateTime.Parse(Console.ReadLine());

                Console.Write("Employee's POSITION ID: ");
                int employeePosID= Convert.ToInt32(Console.ReadLine());

                
                using (SqlConnection conn = new SqlConnection(сonnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("stp_EmployeeAdd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("FirstName", employeeFN);
                    cmd.Parameters.AddWithValue("LastName", employeeLN);
                    cmd.Parameters.AddWithValue("BirthDate", employeeDoB);
                    cmd.Parameters.AddWithValue("PositionID", employeePosID);
                    cmd.Parameters.Add("EmployeeID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data loaded successfully ");                                       
                }
            }

            public static void EmployeeDelete()
            {
                Console.Write("Employee's ID you want to delete: ");
                int employeeID = Convert.ToInt32(Console.ReadLine());


                using (SqlConnection conn = new SqlConnection(сonnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("stp_EmployeeDelete", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("Result", 0);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Employee deleted successfully");
                }
            }

            public static void EmployeeUpdate()
            {
                Console.Write("Employee's ID you want to modify: ");
                string employeeID = Console.ReadLine();

                Console.Write("Employee's new FIRST NAME: ");
                string employeeFN = Console.ReadLine();

                Console.Write("Employee's new LAST NAME: ");
                string employeeLN = Console.ReadLine();

                Console.Write("Employee's new DATE OF BIRTH: ");
                DateTime employeeDoB = DateTime.Parse(Console.ReadLine());

                Console.Write("Employee's new POSITION ID: ");
                int employeePosID = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(сonnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("stp_EmployeeUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("FirstName", employeeFN);
                    cmd.Parameters.AddWithValue("LastName", employeeLN);
                    cmd.Parameters.AddWithValue("BirthDate", employeeDoB);
                    cmd.Parameters.AddWithValue("PositionID", employeePosID);
                    cmd.Parameters.AddWithValue("Result", 0);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Employee updated successfully");
                }
            }                 
        }
    }
}
