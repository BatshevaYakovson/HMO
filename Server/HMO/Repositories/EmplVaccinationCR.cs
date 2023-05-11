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
    public class EmplVaccinationCR : IEmplVaccinationCR
    {
        //create
     public bool Create(EmplVaccination emplVaccinationToAdd)
        {
            try
            {
                using (HmoDbContext ctx = new())
                {
                    ctx.EmplVaccinations.Add(emplVaccinationToAdd);
                    ctx.SaveChanges();
                    return true;
                }
            }

            catch (Exception e)
            {
                return false;

            }
        }



        //read
      public  List<EmplVaccination> GetEmplVaccinations(int? id)
        {

            try
            {
                using (HmoDbContext ctx = new())
                {
                    return id != null && id != 0 ?
                        ctx.EmplVaccinations.Where(a => a.EmplVaccinationId == id)
                        .Join(ctx.Vaccinations,
                              emplVaccination=> emplVaccination.VaccinationId,
                              vaccination=> vaccination.VaccinationId,
                              (emplVaccination, vaccination) => 
                                        new EmplVaccination{ 
                                            EmployeeId = emplVaccination.EmployeeId,
                                            EmplVaccinationId = emplVaccination.EmplVaccinationId,
                                            VaccinationNum = emplVaccination.VaccinationNum,
                                            Date = emplVaccination.Date,
                                            VaccinationId = emplVaccination.VaccinationId,
                                            Vaccination = emplVaccination.Vaccination,
                                        }).ToList() :
                        ctx.EmplVaccinations.Join(ctx.Vaccinations,
                              emplVaccination => emplVaccination.VaccinationId,
                              vaccination => vaccination.VaccinationId,
                              (emplVaccination, vaccination) =>
                                        new EmplVaccination
                                        {
                                            EmployeeId = emplVaccination.EmployeeId,
                                            EmplVaccinationId = emplVaccination.EmplVaccinationId,
                                            VaccinationNum = emplVaccination.VaccinationNum,
                                            Date = emplVaccination.Date,
                                            VaccinationId = emplVaccination.VaccinationId,
                                            Vaccination = emplVaccination.Vaccination,
                                        }).ToList();
                }
            }

            catch (Exception)
            {
                throw;
            }

        }

        public int CountEmplVaccinationsByEmployeeId(long id)
        {
            try
            {
                using (HmoDbContext ctx = new())
                {
                    return ctx.EmplVaccinations.Count(a => a.EmployeeId == id);
                }
            }

            catch (Exception)
            {
                throw;
            }
        }


    }
   
}
