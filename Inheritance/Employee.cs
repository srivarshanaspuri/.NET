using System;

using System;
namespace Inheritance
{
    public class Employee
    {
        // Instance variables
        private long employeeId;
        private string employeeName;
        private string employeeAddress;
        private long employeePhone;
        protected double basicSalary; // Protected to allow access in derived classes
        private double specialAllowance = 250.80;
        private double hra = 1000.50;

        // Overloaded constructor
        public Employee(long id, string name, string address, long phone, double salary)
        {
            employeeId = id;
            employeeName = name;
            employeeAddress = address;
            employeePhone = phone;
            basicSalary = salary;
        }

        public virtual double CalculateSalary()
        {
            return basicSalary + specialAllowance + hra;
        }

        public virtual double CalculateTravelAllowance()
        {
            return basicSalary * 0.10;
        }
    }
}