using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MyDoctor.Database
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {
        protected override DbSet<Medicine> DbSet => mDbContext.Medicines;

        public MedicineRepository(MyDoctorAppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return DbSet.Select(x => x);
        }

    }
}
