using Microsoft.Identity.Client;
using Repositories.Repository;
using Repositories.Repository.Interface;
using Repositories.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeCR :IEmployeeCR
    {
        //create
        public bool Create(Employee employeeToAdd)
        {
            try
            {
                using (HmoDbContext ctx=new())
                {
                    ctx.Employees.Add(employeeToAdd);
                    ctx.SaveChanges();
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;

            }
        }



        //read
        public List<Employee> GetEmployees(int? id = 0)
        {

            try
            {
                using (HmoDbContext ctx = new())
                {
                    return id != null && id != 0 ?
                        ctx.Employees.Where(a => a.EmployeeId == id).ToList() :
                        ctx.Employees.ToList();
                }
            }

            catch (Exception)
            {
                throw;
            }

        }

       
    }
}
