using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Interface
{
    public interface IVaccinationCR
    {
        bool Create(Models.Vaccination vaccinatioinToAdd);
        List<Models.Vaccination> GetVaccinations(int? id);

    }
}
