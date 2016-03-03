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
    public partial class Req : Form
    {
        public Req()
        {
            InitializeComponent();
            PanelLibrary.BackColor = Color.LightSlateGray;
        }

        AbstractAdmin _admin;
        Thread thread;

        public Req(AbstractAdmin admin)
        {
            InitializeComponent();
            PanelLibrary.BackColor = Color.LightSlateGray;

            _admin = admin;

            lblLogin.Text = _admin.Login;
            lblName.Text = _admin.FirstName;
            lblSurname.Text = _admin.LastName;

            //requests = _admin.GetRequests();
            #region requests
            requests = new List<Request>()
            {
                new Request(new TeacherInfo("nameteacher1", "lastnameteacher1", null), new ClientCoreLibrary.DataClasses.AdminInfo(),DateTime.Now, "message 1 "),
                new Request(new TeacherInfo("nameteacher2", "lastnameteacher2", null), new ClientCoreLibrary.DataClasses.AdminInfo(),DateTime.Now, "message 2 "),
                new Request(new StudentInfo("namestudent1", "lastnamestudent1", null,null, null), new ClientCoreLibrary.DataClasses.AdminInfo(),DateTime.Now, "message 3 "),
                new Request(new StudentInfo("namestudent2", "lastnamestudent2", null,null, null), new ClientCoreLibrary.DataClasses.AdminInfo(),DateTime.Now, "message 4 "),
            };
             #endregion
            ShowMessages(requests);
        }


        void ShowMessages(List<Request> reqs) 
        {
            lvMessages.Items.Clear();
            for (int i = 0; i < requests.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(new string[] { requests[i].Sender.FirstName + " " + requests[i].Sender.LastName, requests[i].Date.ToLongTimeString(), requests[i].Text });
                lvMessages.Items.Add(lvi);
            }
        }


        private void ICOPresent_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenGroupForm);
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

        private void ICOHomework_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenScheduleForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);
        }

        #region NewForm
        private void OpenGroupForm(object obj)
        {
            Application.Run(new Group((AbstractAdmin)obj));
        }

        private void OpenNewsForm(object obj)
        {
            Application.Run(new SendNews((AbstractAdmin)obj));
        }
        private void OpenScheduleForm(object obj)
        {
            Application.Run(new Schedule((AbstractAdmin)obj));
        }
        private void Logout(object obj)
        {
            Application.Run(new Login());
        }
        #endregion

        List<Request> requests;

        private void btnSendAnswer_Click(object sender, EventArgs e)
        {
            if (lvMessages.SelectedIndices.Count < 0 || String.IsNullOrEmpty(tbMessage.Text))
                return;

            //_admin.SendRequest(requests[lvMessages.SelectedIndices[0]].Sender, tbMessage.Text);
            requests.Remove(requests[lvMessages.SelectedIndices[0]]);
            lvMessages.Items.Remove(lvMessages.SelectedItems[0]);



        }

        private void ICOLibrary_Click(object sender, EventArgs e)
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
