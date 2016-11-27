using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2.Models;
using MongoDB.Driver.Linq;

namespace WebApi2
{
    public static class MongoConfig
    {
        public async static void Seed()
        {
            var patients = PatientDb.Open();

            //if(!((IEnumerable<Patient>)patients).AsQueryable().Any(p => p.Name == "Scoot"))
            //{
                //var data = new List<Patient>()
                //{
                //    new Patient
                //    {
                //        Name = "Scott",
                //        Ailment = new List<Ailment>() { new Ailment { Name = "Crazy" } },
                //        Medications = new List<Medication>() { new Medication { Name = "Crazy" } }
                //    },

                //    new Patient
                //    {
                //        Name = "Alex",
                //        Ailment = new List<Ailment>() { new Ailment { Name = "Crazy" } },
                //        Medications = new List<Medication>() { new Medication { Name = "Crazy" } }
                //    }
                //};

                //patients.InsertMany(data);
            //}

        }
    }
}