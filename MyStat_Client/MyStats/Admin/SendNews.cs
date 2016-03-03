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
    public partial class SendNews : Form
    {
        public SendNews()
        {
            InitializeComponent();
            PanelNews.BackColor = Color.LightSlateGray;
        }

        public SendNews(AbstractAdmin admin)
        {
            InitializeComponent();
            PanelNews.BackColor = Color.LightSlateGray;

            _admin = admin;
            
            lblLogin.Text = _admin.Login;
            lblName.Text = _admin.FirstName;
            lblSurname.Text = _admin.LastName;

        }




        AbstractAdmin _admin;
        Thread thread;
        #region NewForm
        private void OpenGroupForm(object obj)
        {
            Application.Run(new Group((AbstractAdmin)obj));
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

        private void ICOPresent_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenGroupForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbTitle.Text) || String.IsNullOrEmpty(tbMessage.Text))
                return;

            //_admin.AddAdvertisement(tbTitle.Text, tbMessage.Text, dtpDate.Value);
            tbMessage.Text = "";
            tbTitle.Text = "";
            dtpDate.Value = DateTime.Now;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void ICONews_Click(object sender, EventArgs e)
        {

        }
    }
}
