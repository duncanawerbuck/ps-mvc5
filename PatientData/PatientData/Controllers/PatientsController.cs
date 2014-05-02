using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Models;

namespace PatientData.Controllers
{
    public class PatientsController : ApiController
    {
        private MongoCollection<Patient> _patients; 

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }

        public IEnumerable<Patient> Get()
        {
            return _patients.FindAll();
        }

        public HttpResponseMessage Get(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));

            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found.");
            }

            return Request.CreateResponse(patient);
        }

        [Route("api/patients/{id}/medications")]
        public HttpResponseMessage GetMedications(string id)
        {
            var patient = _patients.FindOneById(ObjectId.Parse(id));

            if (patient == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient not found.");
            }

            return Request.CreateResponse(patient.Medications);
        }
	}
}