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
    public partial class Schedule : Form
    {
        private AbstractUnit user;
        Thread thread;

        public Schedule(AbstractUnit user)
        {
            InitializeComponent();
            this.user = user;
            this.label3.Text = this.user.FirstName;
            this.label4.Text = this.user.LastName;
            //this.GetSchedule();
        }

        void GetSchedule()
        {
            Timetable schedule = ((AbstractStudent)this.user).SGetTimetable();

            for (int i = 0; i < panel8.Controls.Count; i++)
            {
                ((ListView)panel8.Controls[i]).Clear();
            }

            for (int i = 0; i < schedule.Days.Count; i++)
            {
                for (int j = 0; j < schedule.Days[i].Lessons.Count; j++)
                {
                    ListViewItem newList = new ListViewItem(schedule.Days[i].Lessons[j].Time.ToString());
                    newList.SubItems.Add(schedule.Days[i].Lessons[j].Name);
                    newList.SubItems.Add(schedule.Days[i].Lessons[j].Teacher);
                    ((ListView)panel8.Controls[i]).Items.Add(newList);
                }
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
