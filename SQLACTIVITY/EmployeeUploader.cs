using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace EmployeeUploaderApp
{
    class Program
    {
        // SQL Server Connection String (Replace with your actual details)
        private static string connectionString = "Server=localhost\\SQLEXPRESS;Database=EmployeeDB;Integrated Security=True";

        static void Main(string[] args)
        {
            try
            {
                // Insert Department Data
                StoreDepartmentDetails(1, "Accounts", "Ramesh", "Handles company accounts");
                StoreDepartmentDetails(2, "Admin", "Vijay", "Administrative operations");
                StoreDepartmentDetails(3, "Sales", "Vinod", "Handles sales operations");
                StoreDepartmentDetails(4, "HR", "Mahesh", "Human resources management");

                // Insert Employee Data
                StoreEmployeeDetails(87, "Vikram", 12000, "9878761212", "Address 1", 2);
                StoreEmployeeDetails(110, "ARY", 18000, "9654376143", "Address 2", 1);
                StoreEmployeeDetails(98, "Rajesh", 11000, "9965322212", "Address 3", 4);
                StoreEmployeeDetails(67, "Ram", 19000, "8078343732", "Address 4", 3);
                StoreEmployeeDetails(45, "Vimalm", 27000, "80783783732", "Address 5", 4);
                StoreEmployeeDetails(987, "Kiram", 21000, "8078343732", "Address 6", 2);

                Console.WriteLine("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
        }

        // Method to Insert Department Details
        static void StoreDepartmentDetails(int deptId, string deptName, string deptHead, string deptDesc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Department (Department_ID, Department_Name, Department_Head, Department_Description) VALUES (@DeptId, @DeptName, @DeptHead, @DeptDesc)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptId", deptId);
                    cmd.Parameters.AddWithValue("@DeptName", deptName);
                    cmd.Parameters.AddWithValue("@DeptHead", deptHead);
                    cmd.Parameters.AddWithValue("@DeptDesc", deptDesc);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Department {0} inserted successfully.", deptName);
                }
            }
        }

        // Method to Insert Employee Details
        static void StoreEmployeeDetails(int empId, string empName, decimal empSalary, string empContact, string empAddress, int deptId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Employee (Employee_ID, Employee_Name, Employee_Salary, Employee_Contact_No, Employee_Address, Department_ID) VALUES (@EmpId, @EmpName, @EmpSalary, @EmpContact, @EmpAddress, @DeptId)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.Parameters.AddWithValue("@EmpName", empName);
                    cmd.Parameters.AddWithValue("@EmpSalary", empSalary);
                    cmd.Parameters.AddWithValue("@EmpContact", empContact);
                    cmd.Parameters.AddWithValue("@EmpAddress", empAddress);
                    cmd.Parameters.AddWithValue("@DeptId", deptId);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Employee {0} inserted successfully.", empName);
                }
            }
        }
    }
}
