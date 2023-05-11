using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        private readonly IEmplVaccinationCR emplVaccinationCR;
        public EmployeeCR(IEmplVaccinationCR emplVaccinationCR)
        {
            this.emplVaccinationCR = emplVaccinationCR; 
        }
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
                    Dictionary<long, EmplVaccination[]> emplVaccinationsDic = emplVaccinationCR.GetEmplVaccinations(null).ToList()
                        .GroupBy(x=>x.EmployeeId)
                        .ToDictionary(e=> e.Key, e=> e.ToArray());
                    return
                        (from e in ctx.Employees
                         join d in ctx.Diseases on e.EmployeeId equals d.EmployeeId into ps
                         from d in ps.DefaultIfEmpty()
                         select new Employee()
                         {
                             Disease = d,
                             Address = e.Address,
                             BornDate = e.BornDate,
                             CellPhone = e.CellPhone,
                             Phone = e.Phone,
                             EmployeeId = e.EmployeeId,
                             FullName = e.FullName,
                             EmplVaccinations = emplVaccinationsDic.ContainsKey(e.EmployeeId) ? emplVaccinationsDic[e.EmployeeId] : null
                         }).ToList();
                       
                }
            }

            catch (Exception)
            {
                throw;
            }

        }

       
    }
}
