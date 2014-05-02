using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
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
	}
}