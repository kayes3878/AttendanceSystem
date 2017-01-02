using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AttendanceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AttendanceSystemDBEntities attendanceSystemDBEntitiesObj;
        public MainWindow()
        {
            InitializeComponent();
            DynamicButtonCreate();
        }

        private void DynamicButtonCreate()
        {
            for (int i = 0; i < 10; ++i)
            {
                Button button = new Button()
                {
                    Content = string.Format("Button for {0}", i),
                    Tag = i,
                };
                button.Name = "button" + i;
                button.Click += new RoutedEventHandler(button_Click);
                this.grid.Children.Add(button);
            }
        }
        void button_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender;
            MessageBox.Show("Button's name is: " + clicked.Name);
            Console.WriteLine(string.Format("You clicked on the {0}. button.", (sender as Button).Tag));
        }

        public List<EmployeeInfo> GetAllEmployee()
        {
            attendanceSystemDBEntitiesObj = new AttendanceSystemDBEntities();

            //EmployeeInfo _employeeInfoObj = new EmployeeInfo();

            List<EmployeeInfo> _allemployeeObjList = new List<EmployeeInfo>();

            foreach (var s in (from p in attendanceSystemDBEntitiesObj.EmployeeInfoes select p))
            {
                EmployeeInfo employeeInfoObj = new EmployeeInfo();

                employeeInfoObj = new EmployeeInfo
                {
                    Name = s.Name,
                    Email = s.Email,
                    Mobile = s.Mobile,
                    Designation = s.Designation,
                    DateOfBirth = s.DateOfBirth,
                    CreatedDate = s.CreatedDate,
                    Photo = s.Photo,
                    Status = s.Status,
                };

                _allemployeeObjList.Add(employeeInfoObj);
            }
            return _allemployeeObjList;
        }
    }
}
