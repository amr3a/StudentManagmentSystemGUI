using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleStudentManagementSystemScreen
{
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }
        private void GetDefaultImage()
        {
            if (cmbNewGender.SelectedItem.ToString() == "Male" || cmbNewGender.SelectedIndex == -1)
            {
                pbNewImage.ImageLocation = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\", "Resources", "Images", "MaleStudent.jpg"));

            }
            else
            {
                pbNewImage.ImageLocation = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\", "Resources", "Images", "FemaleStudent.jpg"));
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if(ofdBrowseStudentImage.ShowDialog() == DialogResult.OK)
            {
                pbNewImage.ImageLocation = ofdBrowseStudentImage.FileName;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            GetDefaultImage();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FullName = txtNewFirstName.Text + " " + txtNewSecondName.Text + " " + txtNewThirdName.Text + " " + txtNewFourthName.Text;
            clsStudent NewStudent = new clsStudent(FullName,dtpNewBrithdate.Value,cmbNewGender.SelectedItem.ToString(),
                txtNewEmail.Text, txtNewPhoneNumber.Text, txtNewAddress.Text,cmbNewDepartments.SelectedItem.ToString(),
                cmbNewAdemicLevel.SelectedItem.ToString(), dtpNewEnrollmentDate.Value,cmbNewStatus.SelectedItem.ToString(), 
                pbNewImage.ImageLocation.ToString());

            NewStudent.AddNew();
            this.Close();
        }
    }
}
