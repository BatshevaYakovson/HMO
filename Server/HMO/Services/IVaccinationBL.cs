using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repository;

namespace Services
{
    public interface IVaccinationBL
    {
        bool Create(Repositories.Repository.Models.Vaccination vaccinationToAdd);
        List<Repositories.Repository.Models.Vaccination> GetVaccinations(int? id = 0);
    }
}
