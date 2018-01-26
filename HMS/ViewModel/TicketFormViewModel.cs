using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class TicketFormViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<ApplicationUser> Patients { get; set; }

    }
}