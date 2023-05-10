using Repositories.Repository.Interface;
using Repositories.Repository.Models;
namespace Services

    
{
    public class emplVaccinationServices : IEmplVaccinationBL
    {
        private readonly IEmplVaccinationCR dal;

        public emplVaccinationServices(IEmplVaccinationCR dal)
        {
            this.dal = dal;
        }

        public bool Create(EmplVaccination emplVaccinationToAdd)
        {
            int countEmplVaccinations =  CountEmplVaccinationsByEmployeeId(emplVaccinationToAdd.EmployeeId);
            if (countEmplVaccinations < 4)
            {
                countEmplVaccinations++;
                emplVaccinationToAdd.VaccinationNum = countEmplVaccinations;
                return dal.Create(emplVaccinationToAdd);
            }
            return false;
        }

      

        public List<EmplVaccination> GetEmplVaccinations(int? id = 0)
        {
            return dal.GetEmplVaccinations(id);
        }

        private int CountEmplVaccinationsByEmployeeId(long employeeId = 0)
        {
            return dal.CountEmplVaccinationsByEmployeeId(employeeId);
        }
    }
}
