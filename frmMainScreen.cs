using SimpleStudentManagementSystemScreen.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SimpleStudentManagementSystemScreen
{
    public partial class frmMainScreen : Form
    {
        public frmAddNewStudent FrmAddNewStudent = new frmAddNewStudent();
   
        public frmMainScreen()
        {
            InitializeComponent();
            FrmAddNewStudent.StartPosition = FormStartPosition.CenterParent;
         
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            Image RefreshIcon = Properties.Resources.RefreshIcon;
            btnRefresh.Image = new Bitmap(RefreshIcon, 16, 16);

            Image PlusIcon_20x20 = Properties.Resources.PlusIcon_20x20;

            btnAddNewStudent.Image = new Bitmap(PlusIcon_20x20, 15, 15);

            
        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            FrmAddNewStudent.ShowDialog(this);
        }
    }
}
