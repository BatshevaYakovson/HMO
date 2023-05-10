using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Interface
{
    public interface IEmployeeCR
    {
        bool Create(Models.Employee employeeToAdd);
        List<Models.Employee> GetEmployees(int? id);

    }
}
