using Repositories.Repository.Interface;
using Repositories.Repository.Models;


namespace Services
{
    public class EmployeeServices : IEmployeeBL
    {
        private readonly IEmployeeCR dal;

        public EmployeeServices(IEmployeeCR dal)
        {
            this.dal = dal;
        }

        public bool Create(Employee employeeToAdd)
        {
            return dal.Create(employeeToAdd);
        }

        public List<Employee> GetEmployees(int? id = 0)
        {
            return dal.GetEmployees(id);
        }
    }
}
