using System.Collections.Generic;
using PatientRegistration.DataAccessLayer;

namespace PatientRegistration.Models
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient GetByID(int id);
        void Add(Patient patient);
    }
}
