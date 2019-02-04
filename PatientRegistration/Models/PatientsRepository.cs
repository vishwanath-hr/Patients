using System;
using System.Collections.Generic;
using System.Linq;
using PatientRegistration.DataAccessLayer;

namespace PatientRegistration.Models
{
    public class PatientRepository : IDisposable, PatientRegistration.Models.IPatientRepository
    {
        private PatientsEntities db = new PatientsEntities();
        
        public IEnumerable<Patient> GetAll()
        {
            //db.Configuration.ProxyCreationEnabled = false;
            var cc = db.Patients.ToList();

            IEnumerable<Patient> patients = db.Patients;
            foreach (Patient p in patients)
            {
                ICollection<PatientPhone> pPhone = db.PatientPhones.Where(r => r.PatientId == p.Id).ToList();
                p.PatientPhones = pPhone;
            }
            return patients;
        }
        public Patient GetByID(int id)
        {
           // db.Configuration.ProxyCreationEnabled = false;
            Patient pt =  db.Patients.FirstOrDefault(p => p.Id == id);
            pt.PatientPhones = db.PatientPhones.Where(r => r.PatientId == pt.Id).ToList();
            return pt;
        }

       

        public void Add(Patient product)
        {
          //  db.Configuration.ProxyCreationEnabled = false;
            db.Patients.Add(product);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}