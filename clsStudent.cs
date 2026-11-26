using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
namespace SimpleStudentManagementSystemScreen
{
   
    internal class clsStudent
    {
        private string FilePath = "E:\\Users\\amr7a\\Desktop\\ProgrammingAdviceCourse\\Course14\\SimpleStudentManagementSystemScreen\\Resources\\Data\\StudentsData.json";

        public enum enGender 
        { 
            UnSpecified = 0,
            Male = 1,
            Female = 2
        }
        public enum enDepartment
        {
            UnSpecified = 0,
            AllDepartments,
            ComputerScience,
            InformationTechnology,
            SoftwareEngineering,
            ElectricalEngineering,
            BusinessAdministration,
            Architecture
        }
        public enum enAcdemicLevel
        {
            UnSpecified = 0,
            AllLevels,
            FirstLevel,
            SecondLevel,
            ThirdLevel,
            FourthLevel,
            Postgraduated,
        }
        public enum enStatus 
        {
            UnSpecified =0,
            Active = 1,
            Inactive,
            Suspended,
            Graduated,
        }

        public string _ID { get; set; }
        public string _Name { get; set; }
        public DateTime _Brithdate { get; set; }
        public string _Gender { get; set; }
        public string _Email { get; set; }
        public string _PhoneNumber { get; set; }
        public string _Address { get; set; }
        public string _Department { get; set; }
        public string _AcademicLevel { get; set; }
        public DateTime _EnrollmentDate { get; set; }
        public string _Status { get; set; }
        public string _PhotoLocation { get; set; }
        
        private clsStudent()
        {
            this._ID = "ST-000";
            this._Name = "";
            this._Brithdate = DateTime.Today;
            this._Email = "";
            this._PhoneNumber = "";
            this._Address = "";
            this._Department = "";
            this._AcademicLevel = "";
            this._EnrollmentDate = DateTime.Today;
            this._Status = "";
            this._PhotoLocation = "";
        }
        public clsStudent(string name,DateTime brithdate, string gender, string email, 
            string phoneNumber, string address, string department, string academicLevel,
            DateTime enrollmentData, string status, string photoLocation)
        {
            this._ID = "ST-000";
            this._Name = name;
            this._Brithdate = brithdate;
            this._Gender = gender;
            this._Email = email;
            this._PhoneNumber = phoneNumber;
            this._Address = address;
            this._Department = department;
            this._AcademicLevel = academicLevel;
            this._EnrollmentDate = enrollmentData;
            this._Status = status;
            this._PhotoLocation = photoLocation;
          
        }
        private void GenerateID(string PreStudentID)
        {
            int Num = Convert.ToInt32(PreStudentID.Remove(0, 6)) + 1;

            this._ID += Num;
        }
        public void AddNew()
        {
            string ReadJson = File.ReadAllText(FilePath);
            List<clsStudent> students = new List<clsStudent>();

            if(string.IsNullOrEmpty(ReadJson))
            {
              this._ID += "1";
            }
            else
            {
                students = JsonConvert.DeserializeObject<List<clsStudent>>(ReadJson);
                GenerateID(students.Last()._ID);
            }

            students.Add(this);

            string WriteJson = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(FilePath, WriteJson);
        }

    }
}
