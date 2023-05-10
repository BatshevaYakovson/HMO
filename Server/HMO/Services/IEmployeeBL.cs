using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repository;

namespace Services
{
    public interface IEmployeeBL
    {
        bool Create(Repositories.Repository.Models.Employee employeeToAdd);
        List<Repositories.Repository.Models.Employee> GetEmployees(int? id=0);
    }
}
