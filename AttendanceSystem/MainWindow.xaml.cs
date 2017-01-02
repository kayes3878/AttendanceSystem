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
using AttendanceSystem.Entity;
using DATA;

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
            //DynamicButtonCreate();
            LoadAllEmployee();

        }

        private void LoadAllEmployee()
        {
            List<AttendanceSystem.Entity.EmployeeInfo> items = new List<AttendanceSystem.Entity.EmployeeInfo>();
            //items.Add(new TodoItem() { Title = "Complete this WPF tutorial", Completion = 45 });
            //items.Add(new TodoItem() { Title = "Learn C#", Completion = 80 });
            //items.Add(new TodoItem() { Title = "Wash the car", Completion = 0 });
            //EmployeeListBox.ItemsSource = _allemployeeObjList;
            items = GetAllEmployee();
            EmployeeListBox.ItemsSource = items;
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

        public List<AttendanceSystem.Entity.EmployeeInfo> GetAllEmployee()
        {
            attendanceSystemDBEntitiesObj = new AttendanceSystemDBEntities();

            AttendanceSystem.Entity.EmployeeInfo _employeeInfoObj = new AttendanceSystem.Entity.EmployeeInfo();

            List<AttendanceSystem.Entity.EmployeeInfo> _allemployeeObjList = new List<AttendanceSystem.Entity.EmployeeInfo>();

            foreach (var s in (from p in attendanceSystemDBEntitiesObj.EmployeeInfoes select p))
            {
                AttendanceSystem.Entity.EmployeeInfo employeeInfoObj = new AttendanceSystem.Entity.EmployeeInfo();
                employeeInfoObj = new AttendanceSystem.Entity.EmployeeInfo
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

        private void EmployeeListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Entity.EmployeeInfo employeeInfoObj = new Entity.EmployeeInfo();
            int index = EmployeeListBox.SelectedIndex;
            //string name = EmployeeListBox.SelectedItem(employeeInfoObj.Name);
            MessageBox.Show(index.ToString());

        }
    }
}
