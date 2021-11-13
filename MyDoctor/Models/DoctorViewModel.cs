﻿using System.Collections.Generic;

namespace MyDoctor
{
    public class DoctorViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int WorkYears { get; set; }

        public bool IsAbleToMakePrescriptions { get; set; }

        public IEnumerable<PrescriptionViewModel> Prescriptions { get; set; }
    }
}
