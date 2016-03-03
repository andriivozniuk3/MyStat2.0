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
using System.IO;
using System.Threading;

namespace MyStats
{
    public partial class Library : Form
    {
        AbstractUnit user;
        Thread thread;
        public Library(AbstractUnit user)
        {
            InitializeComponent();
            PanelLibrary.BackColor = Color.LightSlateGray;
            //ListViewItem lvi = new ListViewItem("some book");
            //lvi.SubItems.Add("some author");
            //lvi.SubItems.Add("some language");
            //MainListView.Items.Add(lvi);
            this.user = user;
            //((AbstractTeacher)user).Ge
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

        private void DelButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete selected item");
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (tbTheme.Text.Length < 10 || tbDesc.Text.Length < 10)
                return;

            Stream myStream = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|rar files (*.rar)|*.rar|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.OpenFile();

            byte[] bytes;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StudyMaterialInfo smi = new StudyMaterialInfo(this.tbTheme.Text, ofd.FileName, this.tbDesc.Text, null);
                try
                {
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (var streamReader = new MemoryStream())
                        {
                            myStream.CopyTo(streamReader);
                            bytes = streamReader.ToArray();
                            ((AbstractTeacher)user).UploadStudyMaterialToSeviceInBytes(smi, bytes);
                        }
                    }            
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
    }
}
