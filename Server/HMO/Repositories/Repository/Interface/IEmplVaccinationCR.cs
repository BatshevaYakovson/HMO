using Repositories.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Interface
{
    public interface IEmplVaccinationCR
    {
        bool Create(EmplVaccination emplVaccinationToAdd);
        List<EmplVaccination> GetEmplVaccinations(int? id);
        int CountEmplVaccinationsByEmployeeId(long id);

    }
}
