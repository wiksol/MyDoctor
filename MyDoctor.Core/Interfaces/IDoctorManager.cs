using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Core
{
    public interface IDoctorManager
    {

        void AddNewMedicine(MedicineDto medicine, int prescriptionId);
        void AddNewDoctor(DoctorDto doctor);
        void AddNewPrescription(PrescriptionDto prescription, int doctorId);
        bool DeleteMedicine(MedicineDto medicine);
        bool DeleteDoctor(DoctorDto doctor);
        bool DeletePrescription(PrescriptionDto prescription);
        List<DoctorDto> GetAllDoctors(string filterString);
        List<MedicineDto> GetAllMedicineForADoctorAndPrescription(int prescriptionId, string filterString);
        List<PrescriptionDto> GetAllPrescriptionForADoctor(int doctorId, string filterString);
    }
}
