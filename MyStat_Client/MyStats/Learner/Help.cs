﻿using System;
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
    public partial class Help : Form
    {
        private AbstractUnit user;
        Thread thread;

        public Help(AbstractUnit user)
        {
            InitializeComponent();
            this.user = user;
            this.label3.Text = this.user.FirstName;
            this.label4.Text = this.user.LastName;
            //GetRequest();
        }

        public void GetRequest()
        {
            List<Request> requests = ((AbstractStudent)this.user).GetRequests();
            textBox2.Text = null;
            for (int i = 0; i < requests.Count; i++)
            {
                textBox2.AppendText(requests[i].Date.ToString() + Environment.NewLine);
                if (requests[i].Sender.FirstName != null && requests[i].Sender.LastName != null)
                {
                    textBox2.AppendText(requests[i].Sender.FirstName + " " + requests[i].Sender.LastName + Environment.NewLine);
                }
                else
                {
                    textBox2.AppendText("Admin" + Environment.NewLine);
                }
                textBox2.AppendText(requests[i].Text + Environment.NewLine);
                textBox2.AppendText(Environment.NewLine);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            //((AbstractStudent)this.user).SendRequest(new UnitInfo(this.tbFNTeacher.Text, this.tbLNTeacher.Text), textBox1.Text);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(Logout);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start();
        }
    }
}