using System.Collections.Generic;
using HMS.Models;

namespace HMS.ViewModel
{
    public class AdminIndexViewModel
    {
        public IEnumerable<UserListViewModel> UserList { get; set; }
    }
}
