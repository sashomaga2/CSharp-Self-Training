using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class PatientsController : ApiController
    {
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        [Authorize]
        [EnableCors(/*origin, headers, methods*/"*", "*", "GET")]
        public IEnumerable<Patient> Get()
        {
            return _patients.Find(_ => true).ToList();
        }

        public IHttpActionResult Get(string id)
        {
            var patient = new Patient { Name = "Pesho", Medications = new List<Medication> { new Medication { Name = "Viagra" }, new Medication { Name = "Anaglgin" } } };
            //return NotFound();
            //return Request.CreateResponse(patient);
            return Ok(patient);
        }

        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var patient = new Patient { Name = "Pesho", Medications = new List<Medication> { new Medication { Name = "Viagra" }, new Medication { Name = "Anaglgin" } } };
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found!");
            //return Request.CreateResponse(patient.Medications);
            return Ok(patient.Medications);
        }
    }
}
