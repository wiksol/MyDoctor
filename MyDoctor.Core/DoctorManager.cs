using MyDoctor.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctor.Core
{

    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepository mDoctorReposiotory;
        private readonly IPrescriptionRepository mPrescriptionReposiotory;
        private readonly IMedicineRepository mMedicineReposiotory;
        private readonly DtoMapper mDtoMapper;

        public DoctorManager(IDoctorRepository doctorRepository, IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository, DtoMapper dtoMapper)
        {
            mDoctorReposiotory = doctorRepository;
            mPrescriptionReposiotory = prescriptionRepository;
            mMedicineReposiotory = medicineRepository;
            mDtoMapper = dtoMapper;
        }

        public List<DoctorDto> GetAllDoctors(string filterString)
        {
            var doctorEntities = mDoctorReposiotory.GetAllDoctors().ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                doctorEntities = doctorEntities
                    .Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(doctorEntities);
        }

        public List<PrescriptionDto> GetAllPrescriptionForADoctor(int doctorId, string filterString)
        {
            var prescriptionEntities = mPrescriptionReposiotory.GetAllPrescriptions().Where(x => x.DoctorId == doctorId).ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                prescriptionEntities = prescriptionEntities
                    .Where(x => x.Name.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(prescriptionEntities);
        }

        public List<MedicineDto> GetAllMedicineForADoctorAndPrescription(int prescriptionId, string filterString)
        {
            var medicineEntities = mMedicineReposiotory.GetAllMedicines().Where(x => x.PrescriptionId == prescriptionId).ToList();

            if (!string.IsNullOrEmpty(filterString))
            {
                medicineEntities = medicineEntities
                    .Where(x => x.ActiveSubstance.Contains(filterString) ||
                                x.Name.Contains(filterString) ||
                                x.CompanyName.Contains(filterString)).ToList();
            }

            return mDtoMapper.Map(medicineEntities);
        }

        public void AddNewMedicine(MedicineDto medicine, int prescriptionId)
        {
            var entity = mDtoMapper.Map(medicine);
            entity.PrescriptionId = prescriptionId;
            mMedicineReposiotory.AddNew(entity);
        }

        public void AddNewPrescription(PrescriptionDto prescription, int doctorId)
        {
            var entity = mDtoMapper.Map(prescription);
            entity.DoctorId = doctorId;
            mPrescriptionReposiotory.AddNew(entity);
        }

        public void AddNewDoctor(DoctorDto doctor)
        {
            var entity = mDtoMapper.Map(doctor);
            mDoctorReposiotory.AddNew(entity);
        }

        public bool DeleteMedicine(MedicineDto medicine)
        {
            var entity = mDtoMapper.Map(medicine);
            return mMedicineReposiotory.Delete(entity);
        }

        public bool DeletePrescription(PrescriptionDto prescription)
        {
            var entity = mDtoMapper.Map(prescription);
            return mPrescriptionReposiotory.Delete(entity);
        }

        public bool DeleteDoctor(DoctorDto doctor)
        {
            var entity = mDtoMapper.Map(doctor);
            return mDoctorReposiotory.Delete(entity);
        }
    }
}
