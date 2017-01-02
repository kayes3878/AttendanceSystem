using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Entity
{
    public class User
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRoll { get; set; }
        public bool Status { get; set; }

       

    }
}
