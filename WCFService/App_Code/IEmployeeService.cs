using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
[ServiceContract]
public interface IEmployeeService
{
    [OperationContract]
    void AddEmployee(string name, DateTime hiredate, decimal salary, string deptname, string address);

    [OperationContract]
    void DelEmployee(int id);

    [OperationContract]
    void EditEmployee(int id, string name, DateTime hiredate, decimal salary, string deptname, string address);

    [OperationContract]
    List<EmployeeEnt> GetAll();
}
