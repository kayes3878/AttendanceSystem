using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Entity
{
    public class EmployeeInfo : INotifyPropertyChanged
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Designation { get; set; }
        public string Imagelink { get; set; }
        public DateTime ? DateOfBirth { get; set; }
        public DateTime ? CreatedDate { get; set; }
        public byte[] Photo { get; set; }
        public bool ? Status { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(System.String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
