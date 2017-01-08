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
using Microsoft.AspNet.SignalR.Client;



namespace AttendanceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AttendanceSystemDBEntities attendanceSystemDBEntitiesObj;

        public String UserName { get; set; }
        public IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080/signalr";
        public HubConnection Connection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //this.right = SystemParameters.PrimaryScreenWidth - this.Width;
           
            //DynamicButtonCreate();
            LoadAllEmployee();

        }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            Connection.Closed += Connection_Closed;
            HubProxy = Connection.CreateHubProxy("MyHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            HubProxy.On<string, string>("AddMessage", (name, message) =>
                this.Dispatcher.Invoke(() =>
                    //RichTextBoxConsole.AppendText(String.Format("{0}: {1}\r", name, message))
                )
            );
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                //StatusText.Content = "Unable to connect to server: Start server before connecting clients.";
                //No connection: Don't enable Send button or show chat UI
                return;
            }

            //Show chat UI; hide login UI
            //SignInPanel.Visibility = Visibility.Collapsed;
            //ChatPanel.Visibility = Visibility.Visible;
            //ButtonSend.IsEnabled = true;
            //TextBoxMessage.Focus();
            //RichTextBoxConsole.AppendText("Connected to server at " + ServerURI + "\r");
        }
        void Connection_Closed()
        {
            //Hide chat UI; show login UI
            //var dispatcher = Application.Current.Dispatcher;
            //dispatcher.Invoke(() => ChatPanel.Visibility = Visibility.Collapsed);
            //dispatcher.Invoke(() => ButtonSend.IsEnabled = false);
            //dispatcher.Invoke(() => StatusText.Content = "You have been disconnected.");
            //dispatcher.Invoke(() => SignInPanel.Visibility = Visibility.Visible);
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
                    //CreatedDate = s.CreatedDate,
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
