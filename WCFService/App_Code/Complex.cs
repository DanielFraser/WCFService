using System;
using System.Runtime.Serialization;
using System.ServiceModel;

/// <summary>
/// Summary description for Complex
/// </summary>
[DataContract]
public class Complex
{
    [DataMember]
    public int Real { get; set; }

    [DataMember]
    public int Imag { get; set; }
}

[DataContract]
public class EmployeeEnt
{
    [DataMember]
    public int ID { get; set; }
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public Nullable<System.DateTime> Hiredate { get; set; }
    [DataMember]
    public Nullable<decimal> Salary { get; set; }
    [DataMember]
    public int DepartmentID { get; set; }
    [DataMember]
    public string Address { get; set; }
}


public class Program
{
    static void Main()
    {
        ServiceHost sh = new ServiceHost(typeof(EmployeeService));
        sh.Open();
        Console.WriteLine("Server Started");
        Console.WriteLine("Press any key to terminate server");
        System.Threading.Thread.CurrentThread.Join();
    }
}