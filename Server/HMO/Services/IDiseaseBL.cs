using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repository;

namespace Services
{
    public interface IDiseaseBL
    {
        bool Create(Repositories.Repository.Models.Disease diseaseToAdd);
        List<Repositories.Repository.Models.Disease> GetDisease(int? id = 0);
    }
}
