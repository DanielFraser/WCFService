using System;
using System.Collections.Generic;
using System.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
public class EmployeeService : IEmployeeService
{
    private EmployeeWCFEntities emp = new EmployeeWCFEntities();
    public void AddEmployee(string name, DateTime hiredate, decimal salary, string deptname, string address)
    {
        Employee e = new Employee
        {
            Name = name,
            Salary = salary,
            Hiredate = hiredate,
            DepartmentID = emp.Departments.Where(a => a.DepartmentName == deptname).Select(a => a.DepartmentID).FirstOrDefault(),
            Address = address
        };
        emp.Employees.Add(e);
        emp.SaveChanges();
    }

    public void DelEmployee(int id)
    {
        Employee e = emp.Employees.Where(a => a.ID == id).FirstOrDefault();
        if (e != null)
        {
            emp.Employees.Remove(e);
            emp.SaveChanges();
        }
    }

    public void EditEmployee(int id, string name, DateTime hiredate, decimal salary, string deptname, string address)
    {
        Employee e = emp.Employees.Where(a => a.ID == id).FirstOrDefault();
        if (e != null)
        {
            e.Name = name;
            e.Salary = salary;
            e.Hiredate = hiredate;
            e.DepartmentID = emp.Departments.Where(a => a.DepartmentName == deptname).Select(a => a.DepartmentID).FirstOrDefault();
            e.Address = address;
            emp.SaveChanges();
        }
    }

    public List<EmployeeEnt> GetAll()
    {
        return emp.Employees.Select(a => new EmployeeEnt
        {
            Name = a.Name,
            Address = a.Address,
            DepartmentName = a.Department.DepartmentName,
            Hiredate = a.Hiredate,
            ID = a.ID,
            Salary = a.Salary
        }).ToList();
    }

    public List<string> GetDepts(string prefix)
    {
        return emp.Departments.Where(a => prefix == "" ? true : a.DepartmentName.Contains(prefix)).Select(a => a.DepartmentName).ToList();
    }
}
