using Repositories.Repository.Interface;
using Repositories.Repository.Models;


namespace Services
{
    public class DiseaseServices : IDiseaseBL
    {
        private readonly IDiseaseCR dal;

        public DiseaseServices(IDiseaseCR dal)
        {
            this.dal = dal;
        }

        public bool Create(Disease DiseaseToAdd)
        {
            return dal.Create(DiseaseToAdd);
        }

      

        public List<Disease> GetDisease(int? id = 0)
        {
            return dal.GetDiseases(id);
        }
    }
}
