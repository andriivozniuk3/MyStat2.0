using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientCoreLibrary.DataClasses;
using ClientCoreLibrary.PublicClasses;
using System.Threading;

namespace MyStats.Admin
{
    public partial class Group : Form
    {
        public Group()
        {
            InitializeComponent();
            PanelPresent.BackColor = Color.LightSlateGray;
        }

        public Group(AbstractAdmin admin)
        {
            InitializeComponent();
            PanelPresent.BackColor = Color.LightSlateGray;

            _admin = admin;

            lblLogin.Text = _admin.Login;
            lblName.Text = _admin.FirstName;
            lblSurname.Text = _admin.LastName;

            cbEditGroups.DataSource = null;
            // cbEditGroups.Items.Clear();
            // cbEditGroups.DataSource = _admin.GetGroupNames();
        }

        AbstractAdmin _admin;
        List<StudentInfo> _currentStudents;
        Thread thread;

        #region NewForm
        private void OpenNewsForm(object obj)
        {
            Application.Run(new SendNews((AbstractAdmin)obj));
        }

        private void OpenShaduleForm(object obj)
        {
            Application.Run(new Schedule((AbstractAdmin)obj));
        }
        private void AdminRequests(object obj)
        {
            Application.Run(new Req((AbstractAdmin)obj));
        }
        private void Logout(object obj)
        {
            Application.Run(new Login());
        }
        #endregion

        private void ICOHomework_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenShaduleForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);
        }

        private void ICOLibrary_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(AdminRequests);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);
        }

        private void ICONews_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenNewsForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);
        }

        private void cbEditGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbEditGroups.SelectedIndex < 0)
                return;

            // _currentStudents = _admin.GetStudentsByGroupName(cbEditGroups.SelectedItem.ToString());
            #region testStudents

            List<StudentInfo> stud = new List<StudentInfo>()
            {
                new StudentInfo("1","2", "sd", "sdf", "sdf"),
                new StudentInfo("3","4", "sd", "sdf", "sdf"),
                new StudentInfo("5","6", "sd", "sdf", "sdf"),
                new StudentInfo("7","8", "sd", "sdf", "sdf"),
                new StudentInfo("9","10", "sd", "sdf", "sdf"),
                new StudentInfo("11","12", "sd", "sdf", "sdf"),
                new StudentInfo("13","14", "sd", "sdf", "sdf")
            };

            _currentStudents = stud;

            #endregion
            
            

            ShowStudents(_currentStudents);
        }

        void ShowStudents(List<StudentInfo> students)
        {
            lvStudents.Items.Clear();

            for (int i = 0; i < students.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(new string[] {students[i].FirstName, students[i].LastName });
                lvStudents.Items.Add(lvi);
            }
        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbLogin.Text) || String.IsNullOrEmpty(tbPasword.Text) || String.IsNullOrEmpty(tbName.Text) || String.IsNullOrEmpty(tbSurname.Text))
                return;

            _currentStudents.Add(new StudentInfo(tbName.Text, tbSurname.Text, tbLogin.Text, tbPasword.Text, cbEditGroups.SelectedItem.ToString()));

            lvStudents.Items.Add(new ListViewItem(new string[] { tbName.Text, tbSurname.Text }));
          //  _admin.AddStudent(tbName.Text, tbSurname.Text, tbLogin.Text, tbPasword.Text, cbEditGroups.SelectedItem.ToString());
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (lvStudents.SelectedIndices[0] <= 0)
                return;

            //_admin.RemoveStudent(cbEditGroups.SelectedItem.ToString(), lvStudents.SelectedItems[0].SubItems[0].Text, lvStudents.SelectedItems[0].SubItems[1].Text);
            lvStudents.Items.Remove(lvStudents.SelectedItems[0]);
        }

        private void ICOPresent_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(Logout);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start();
        }
    }
}
