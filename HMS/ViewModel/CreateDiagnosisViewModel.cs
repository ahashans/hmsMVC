using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class CreateDiagnosisViewModel
    {
        public IEnumerable<ApplicationUser> Patients { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}