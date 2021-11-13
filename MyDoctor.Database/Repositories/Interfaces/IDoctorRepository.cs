using System.Collections.Generic;

namespace MyDoctor.Database
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();

    }
}
