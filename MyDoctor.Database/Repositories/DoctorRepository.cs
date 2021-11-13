using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MyDoctor.Database
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        protected override DbSet<Doctor> DbSet => mDbContext.Doctors;

        public DoctorRepository(MyDoctorAppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return DbSet/*.Include(x=>x.Prescriptions).ThenInclude(x => x.Medicines)*/.Select(x => x);
        }

       
    }
}
