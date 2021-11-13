using System.Collections.Generic;

namespace MyDoctor.Database
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptions();
    }
}
