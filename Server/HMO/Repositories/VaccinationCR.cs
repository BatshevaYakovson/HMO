using Microsoft.Identity.Client;
using Repositories.Repository;
using Repositories.Repository.Interface;
using Repositories.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class VaccinationCR : IVaccinationCR
    {
        //create
        public bool Create(Vaccination vaccinationToAdd)
        {
            try
            {
                using (Repository.HmoDbContext ctx = new())
                {
                    ctx.Vaccinations.Add(vaccinationToAdd);
                    ctx.SaveChanges();
                    return true;
                }
            }

            catch (Exception)
            {
                return false;

            }
        }



        //read
        public List<Vaccination> GetVaccinations(int? id = 0)
        {

            try
            {
                using (HmoDbContext ctx = new())
                {
                    return id != null && id != 0 ?
                        ctx.Vaccinations.Where(a => a.VaccinationId == id).ToList() :
                        ctx.Vaccinations.ToList();
                }
            }

            catch (Exception)
            {
                throw;
            }

        }


    }
}
