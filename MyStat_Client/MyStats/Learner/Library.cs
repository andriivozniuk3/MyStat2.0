using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientCoreLibrary.DataClasses;
using ClientCoreLibrary.PublicClasses;
using System.IO;
using System.Threading;

namespace MyStats.Learner
{
    public partial class Library : Form
    {
        private AbstractUnit user;
        Thread thread;

        public Library(AbstractUnit user)
        {
            InitializeComponent();
            this.user = user;
            this.label3.Text = this.user.FirstName;
            this.label4.Text = this.user.LastName;
        }

        private void GetLibrary(string theme)
        {
            List<StudyMaterialInfo> requests = ((AbstractStudent)this.user).SGetStudyMaterials(theme);

            for (int i = 0; i < requests.Count; i++)
            {
                ListViewItem newList = new ListViewItem(requests[i].Theme);
                newList.SubItems.Add(requests[i].Name);
                newList.SubItems.Add(requests[i].Description);
                newList.Tag = requests[i].FileIdx;
                MainListView.Items.Add(newList);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetLibrary(tbTheme.Text);
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = MainListView.SelectedItems[0].SubItems[1].Text;
            saveFileDialog1.RestoreDirectory = true;

            byte[] buf = ((AbstractStudent)this.user).SGetFileStudyMaterialsInBytes(MainListView.SelectedItems[0].Tag as int?);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Write(buf, 0, buf.Count());
                    myStream.Close();
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
