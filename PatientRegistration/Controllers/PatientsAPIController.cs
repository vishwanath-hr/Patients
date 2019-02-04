using System.Collections.Generic;
using System.Web.Http;
using PatientRegistration.DataAccessLayer;
using PatientRegistration.Models;


namespace PatientRegistration.Controllers
{
    public class PatientsAPIController : ApiController
    {
        IPatientRepository _repository;

        public PatientsAPIController(IPatientRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Patient> Get()
        {
        

            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var patient = _repository.GetByID(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        public IHttpActionResult Post([FromBody]Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(patient);
            return CreatedAtRoute("DefaultApi", new { id = patient.Id }, patient);
        }

        //////// GET: api/Patients1
        //////public IQueryable<Patient> GetPatients()
        //////{
        //////    return db.Patients;
        //////}

        //////// GET: api/Patients1/5
        //////[ResponseType(typeof(Patient))]
        //////public IHttpActionResult GetPatient(int id)
        //////{
        //////    Patient patient = db.Patients.Find(id);
        //////    if (patient == null)
        //////    {
        //////        return NotFound();
        //////    }

        //////    return Ok(patient);
        //////}

        //////// PUT: api/Patients1/5
        //////[ResponseType(typeof(void))]
        //////public IHttpActionResult PutPatient(int id, Patient patient)
        //////{
        //////    if (!ModelState.IsValid)
        //////    {
        //////        return BadRequest(ModelState);
        //////    }

        //////    if (id != patient.Id)
        //////    {
        //////        return BadRequest();
        //////    }

        //////    db.Entry(patient).State = EntityState.Modified;

        //////    try
        //////    {
        //////        db.SaveChanges();
        //////    }
        //////    catch (DbUpdateConcurrencyException)
        //////    {
        //////        if (!PatientExists(id))
        //////        {
        //////            return NotFound();
        //////        }
        //////        else
        //////        {
        //////            throw;
        //////        }
        //////    }

        //////    return StatusCode(HttpStatusCode.NoContent);
        //////}

        //////// POST: api/Patients1
        //////[ResponseType(typeof(Patient))]
        //////public IHttpActionResult PostPatient(Patient patient)
        //////{
        //////    if (!ModelState.IsValid)
        //////    {
        //////        return BadRequest(ModelState);
        //////    }

        //////    db.Patients.Add(patient);
        //////    db.SaveChanges();

        //////    return CreatedAtRoute("DefaultApi", new { id = patient.Id }, patient);
        //////}

        //////// DELETE: api/Patients1/5
        //////[ResponseType(typeof(Patient))]
        //////public IHttpActionResult DeletePatient(int id)
        //////{
        //////    Patient patient = db.Patients.Find(id);
        //////    if (patient == null)
        //////    {
        //////        return NotFound();
        //////    }

        //////    db.Patients.Remove(patient);
        //////    db.SaveChanges();

        //////    return Ok(patient);
        //////}

        //////protected override void Dispose(bool disposing)
        //////{
        //////    if (disposing)
        //////    {
        //////        db.Dispose();
        //////    }
        //////    base.Dispose(disposing);
        //////}

        //////private bool PatientExists(int id)
        //////{
        //////    return db.Patients.Count(e => e.Id == id) > 0;
        //////}
    }
}