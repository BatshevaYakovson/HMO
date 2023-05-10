using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository.Interface
{
    public interface IDiseaseCR
    {
        bool Create(Models.Disease diseaseToAdd);
        List<Models.Disease> GetDiseases(int? id);

    }
}
