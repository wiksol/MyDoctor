using System.Collections.Generic;

namespace MyDoctor.Database
{
    public interface IMedicineRepository: IRepository<Medicine>
    {
        IEnumerable<Medicine> GetAllMedicines();
    }
}
