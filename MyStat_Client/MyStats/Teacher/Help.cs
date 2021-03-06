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

namespace MyStats
{
    public partial class Help : Form
    {
        private AbstractUnit user;
        Thread thread;
        public Help(AbstractUnit user)
        {
            InitializeComponent();
            this.user = user;
        }

        #region NewForm
        private void OpenHomeWForm(object obj)
        {
            Application.Run(new Homework((AbstractTeacher)obj));
        }

        private void OpenNewsForm(object obj)
        {
            Application.Run(new News((AbstractTeacher)obj));
        }

        private void OpenPresentForm(object obj)
        {
            Application.Run(new Present((AbstractTeacher)obj));
        }

        private void OpenLibraryForm(object obj)
        {
            Application.Run(new Library((AbstractTeacher)obj));
        }

        private void OpenHelpForm(object obj)
        {
            Application.Run(new Help((AbstractTeacher)obj));
        }

        private void Logout(object obj)
        {
            Application.Run(new Login());
        }
        #endregion

        private void ICOHomework_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenHomeWForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(user);

        }

        private void ICOPresent_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenPresentForm);
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

        private void ICOHelp_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenHelpForm);
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

        private void LabelExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(Logout);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (this.MainTextBox.Text.Length < 10)
                return;

            ((AbstractTeacher)this.user).SendRequest(new UnitInfo("", ""), this.MainTextBox.Text);
        }

    }
}
