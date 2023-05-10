using Repositories.Repository.Interface;
using Repositories.Repository.Models;


namespace Services
{
    public class VaccinationServices : IVaccinationBL
    {
        private readonly IVaccinationCR dal;

        public VaccinationServices(IVaccinationCR dal)
        {
            this.dal = dal;
        }

        public bool Create(Vaccination vaccinationToAdd)
        {
            return dal.Create(vaccinationToAdd);
        }

        public List<Vaccination> GetVaccinations(int? id = 0)
        {
            return dal.GetVaccinations(id);
        }
    }
}
