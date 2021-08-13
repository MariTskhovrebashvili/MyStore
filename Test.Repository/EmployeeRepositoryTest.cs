using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Store.Models;
using Store.Repositories;
using Xunit;

namespace Test.Repository
{
    public class EmployeeRepositoryTest : BaseRepositoryTest<EmployeeRepository, Employee>
    {
        private static string _connectionString = "server=localhost; database=Store; uid=sa; pwd=secret";


        public EmployeeRepositoryTest() : base(new EmployeeRepository(_connectionString))
        {
            
        }

        //[Theory]
        //[InlineData(_employees[0])]
        //public override void InsertTest(Employee employee) => base.InsertTest(employee);

        //private static void LoadEmployees()
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        Employee employee = new Employee();
        //        CreateEmployee(employee, i);
        //        _employees[i] = employee;
        //    }

        //    void CreateEmployee(Employee employee, int id)
        //    {
        //        employee.Id = id + 1;
        //        employee.FirstName = $"Zura{(char)(65 + id)}";
        //        employee.LastName = $"Chachava{(char)(65 + id)}";
        //        employee.Phone = $"55512332{id}";
        //        employee.PersonalId = $"5300200453{id}";
        //        employee.Email = $"zur{(char) (65 + id)}@gmail.com";
        //        employee.HomeAddress = $"Tbilisi weretlis {id}";
        //        employee.StartJob = DateTime.Now;
        //    }
        //}
    }
}