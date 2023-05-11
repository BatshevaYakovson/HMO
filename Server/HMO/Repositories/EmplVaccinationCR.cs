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
                        ctx.EmplVaccinations.Where(a => a.EmplVaccinationId == id).ToList() :
                        ctx.EmplVaccinations.ToList();
                }
            }

            catch (Exception)
            {
                throw;
            }

        }




    }
   
}
