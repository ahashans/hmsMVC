using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class TicketUserViewModel
    {
        public IEnumerable<ApplicationUser> Patients { get; set; }
    }
}