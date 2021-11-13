using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDoctor.Database
{
    public class MyDoctorAppDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public MyDoctorAppDbContext(DbContextOptions options) : base (options)
        {

        }
    }
}
