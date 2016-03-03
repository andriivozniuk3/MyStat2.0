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

namespace MyStats.Learner
{
    public partial class News : Form
    {
        private AbstractUnit user;
        Thread thread;

        public News(AbstractUnit user)
        {
            InitializeComponent();
            this.user = user;
            this.label3.Text = this.user.FirstName;
            this.label4.Text = this.user.LastName;
            //this.GetNews();
        }

        private void GetNews()
        {
            List<Advertisement> adv = ((AbstractStudent)this.user).GetAllAdvertisements();
            this.MainPanel.Controls.Clear();

            for (int i = 0; i < adv.Count; i++)
            {
                Panel p = new Panel();
                p.BackColor = Color.RoyalBlue;
                p.Size = new Size(555, 105);

                TextBox tb = new TextBox();
                tb.Size = new Size(545, 105);
                tb.BackColor = Color.RoyalBlue;
                tb.Multiline = true;
                tb.AppendText(adv[i].TimePublication.ToString() + Environment.NewLine);
                tb.AppendText(adv[i].Title + Environment.NewLine);
                tb.AppendText(adv[i].Info + Environment.NewLine);
                tb.ReadOnly = true;
                p.Controls.Add(tb);

                this.panelFillNews.Controls.Add(p);

                if (i == 0)
                    this.panelFillNews.Controls[i].Location = new Point(0, 0);
                else
                    this.panelFillNews.Controls[i].Location = new Point(this.panelFillNews.Controls[i - 1].Location.X, this.panelFillNews.Controls[i - 1].Location.Y + 110);
            }
        }

        #region NewForm
        private void OpenHomeWForm(object obj)
        {
            Application.Run(new Homework((AbstractStudent)obj));
        }

        private void OpenNewsForm(object obj)
        {
            Application.Run(new News((AbstractStudent)obj));
        }

        private void OpenShaduleForm(object obj)
        {
            Application.Run(new Schedule((AbstractStudent)obj));
        }
        private void OpenStatsForm(object obj)
        {
            Application.Run(new Stats((AbstractStudent)obj));
        }

        private void OpenLibraryForm(object obj)
        {
            Application.Run(new Library((AbstractStudent)obj));
        }

        private void OpenHelpForm(object obj)
        {
            Application.Run(new Help((AbstractStudent)obj));
        }

        private void Logout(object obj)
        {
            Application.Run(new Login());
        }
        #endregion

        private void ICOHomeW_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenHomeWForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(user);
        }

        private void ICONews_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenNewsForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(user);
        }

        private void ICOSchedule_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenShaduleForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(user);
        }

        private void ICOStats_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenStatsForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(user);
        }

        private void ICOLibrary_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenLibraryForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(user);
        }

        private void ICOHelp_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenHelpForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(user);
        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(Logout);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start();
        }
    }
}
