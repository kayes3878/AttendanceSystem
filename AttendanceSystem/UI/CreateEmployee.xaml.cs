using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using AttendanceSystem.Entity;
using DATA;
namespace AttendanceSystem.UI
{
    /// <summary>
    /// Interaction logic for CreateEmployee.xaml
    /// </summary>
    public partial class CreateEmployee : Window
    {
        public CreateEmployee()
        {
            InitializeComponent();
        }
        Entity.EmployeeInfo _employeeInfoObj;
        private void choseEmployeePhoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg;
                FileStream fs;
                dlg = new OpenFileDialog();
                dlg.ShowDialog();

                if (dlg.FileName != "")
                {
                    fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                    BackGround = new byte[fs.Length].ToArray();

                    fs.Read(BackGround, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    byte[] barrImg = (byte[])BackGround;
                    string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                    FileStream fs1 = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                    fs1.Write(barrImg, 0, barrImg.Length);
                    fs1.Flush();
                    fs1.Close();
                    ImageSourceConverter imgs = new ImageSourceConverter();
                    employeePhoto.SetValue(Image.SourceProperty, imgs.ConvertFromString(strfn));


                }
            }
            catch (Exception ex)
            {
                BackGround = new byte[0];
                MessageBox.Show("Error while uploading Image File.\n" + ex.Message, "Member/Customer Setup", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public byte[] BackGround { get; set; }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (saveButton.Content.ToString() == "SAVE")
            {
                _employeeInfoObj = new Entity.EmployeeInfo();
                _employeeInfoObj.Name = NameTextbox.Text;
                _employeeInfoObj.Email = EmailTextbox.Text;
                _employeeInfoObj.Designation = DesignationTextbox.Text;
                _employeeInfoObj.DateOfBirth = DateTime.Parse(DateOfBirthDatepicker.Text);
                _employeeInfoObj.Photo = BackGround;
                _employeeInfoObj.Status =Convert.ToBoolean(1);
                SaveEmployee(_employeeInfoObj);
                MessageBox.Show("Employee Data Successfully Saved");
            }

            if (saveButton.Content.ToString() == "Update")
            {
                //_idcardInfoObj.Name = nameTextBox.Text;
                //_idcardInfoObj.FathersName = FathersNameTextBox.Text;
                //_idcardInfoObj.MothersName = MothersNameTextBox.Text;
                //_idcardInfoObj.DateOfBirth = DateTime.Parse(dateOfBirthDatePicker.Text);
                //_idcardInfoObj.BloodGroup = bloodGroupCombobox.Text;
                //_idcardInfoObj.ClassORDepartment = classOrDesignationTextbox.Text;
                //_idcardInfoObj.ContactNo = contactNoTextbox.Text;
                //_idcardInfoObj.PersonalPhoto = PersonalPhoto;

                //_idcardInfoObj.Background = BackGround;
                //_idcardInfoObj.InstituteName = instituteNameTextbox.Text;

                //idcardManagerObj.UpdateIdCard(_idcardInfoObj);
                //MessageBox.Show("Update Successfull");
                //LoadAllIdCardInfo();
                //saveButton.Content = "Save";
                //ClearTextbox();

            }
        }

        private void SaveEmployee(Entity.EmployeeInfo _employeeInfoObj)
        {
            AttendanceSystemDBEntities aSEntitiesObj = new AttendanceSystemDBEntities();
            //DateTime ServerDate = aSEntitiesObj.CreateQuery<DateTime>("CurrentDateTime()").AsEnumerable().First();
            //var dQuery = aSEntitiesObj.CreateQuery<DateTime>("CurrentDateTime() ");
            //DateTime dbDate = dQuery.AsEnumerable().First();

            var newEmployee = new DATA.EmployeeInfo
            {
                Name = _employeeInfoObj.Name,
                Email = _employeeInfoObj.Email,
                Designation = _employeeInfoObj.Designation,
                DateOfBirth = _employeeInfoObj.DateOfBirth,
                Photo = _employeeInfoObj.Photo,
                Status = _employeeInfoObj.Status,
                //CreatedDate = _employeeInfoObj.CreatedDate(nullable: false, defaultValueSql: "GETUTCDATE()"),
            };
            aSEntitiesObj.EmployeeInfoes.Add(newEmployee);
            aSEntitiesObj.SaveChanges();
        }

         
         
    }
}
