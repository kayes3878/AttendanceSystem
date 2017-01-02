using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Entity
{
    public class Attandence
    {
        public int Id { get; set; }
        public int EmployeId { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public DateTime DateOfAttandence { get; set; }
        public bool Status { get; set; }
        public bool CheckOutStatus { get; set; }

    }
}
