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
    public class DiseaseCR :   IDiseaseCR
    {
        //create
        public bool Create(Disease DiseaseToAdd)
        {
            try
            {
                using (HmoDbContext ctx=new())
                {
                    ctx.Diseases.Add(DiseaseToAdd);
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
        public List<Disease> GetDiseases(int? id = 0)
        {

            try
            {
                using (HmoDbContext ctx = new())
                {
                    return id != null && id != 0 ?
                        ctx.Diseases.Where(a => a.EmployeeId == id).ToList() :
                        ctx.Diseases.ToList();
                }
            }

            catch (Exception)
            {
                throw;
            }

        }

       
    }
}
