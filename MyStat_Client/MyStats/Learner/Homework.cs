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

namespace MyStats.Learner
{
    public partial class Homework : Form
    {
        private AbstractUnit user;
        Thread thread;

        public Homework(AbstractUnit user)
        {
            InitializeComponent();
            PanelHomework.BackColor = Color.LightSlateGray;
            this.user = user;
            this.label3.Text = this.user.FirstName;
            this.label4.Text = this.user.LastName;

            //this.GetHomeWorks();
        }

        private void GetHomeWorks()
        {
            List<HomeWorkInfo> homeworks = ((AbstractStudent)this.user).SGetHomeWorkInfo();
            this.MainPanel.Controls.Clear();
            for (int i = 0; i < homeworks.Count; i++)
            {
                Panel p = new Panel();
                p.BackColor = Color.RoyalBlue;
                p.Size = new Size(530, 43);

                PictureBox pb = new PictureBox();
                pb.Cursor = Cursors.Hand;
                pb.Size = new Size(36, 36);
                pb.ImageLocation = @"..\Resources\upload123.png";
                pb.Click += pb_Click;
                p.Controls.Add(pb);
                p.Controls[0].Location = new Point(16, 3);

                Label lDate = new Label();
                lDate.Text = homeworks[i].DatePublic.ToShortDateString();
                p.Controls.Add(lDate);
                p.Controls[1].Location = new Point(75, 15);

                Label lTheme = new Label();
                lTheme.Text = homeworks[i].Theme;
                p.Controls.Add(lTheme);
                p.Controls[2].Location = new Point(155, 11);

                Label lName = new Label();
                lName.Text = homeworks[i].Student.FirstName + " " + homeworks[i].Student.LastName;
                p.Controls.Add(lName);
                p.Controls[3].Location = new Point(305, 12);

                Label lblScore = new Label();
                lblScore.Size = new Size(85, 21);
                lblScore.Text = homeworks[i].Mark.ToString();
                p.Controls.Add(lblScore);
                p.Controls[4].Location = new Point(405, 9);

                PictureBox pb2 = new PictureBox();
                pb2.Cursor = Cursors.Hand;
                pb2.Size = new Size(36, 36);
                pb2.ImageLocation = @"..\Resources\donwl.png";
                pb2.Click += pb2_Click;
                p.Controls.Add(pb2);
                p.Controls[5].Location = new Point(495, 7);

                this.MainPanel.Controls.Add(p);
                if (i == 0)
                    this.MainPanel.Controls[i].Location = new Point(6, 20);
                else
                    this.MainPanel.Controls[i].Location = new Point(this.MainPanel.Controls[i - 1].Location.X, this.MainPanel.Controls[i - 1].Location.Y + 50);

                this.MainPanel.Controls[i].Tag = homeworks[i];
            }
        }

        void pb_Click(object sender, EventArgs e)
        {
            HomeWorkInfo hwi = ((Panel)((PictureBox)sender).Parent).Tag as HomeWorkInfo;
            DownloadHomeWork(hwi);
        }

        void pb2_Click(object sender, EventArgs e)
        {
            HomeWorkInfo hwi = ((Panel)((PictureBox)sender).Parent).Tag as HomeWorkInfo;
            DownloadHomeWork(hwi);
        }

        private void DownloadHomeWork(HomeWorkInfo hwi)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = hwi.Name;
            saveFileDialog1.RestoreDirectory = true;

            byte[] buf = ((AbstractStudent)user).SDownLoadHomeWorkFromSeverInBytes(hwi.FileIdx);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Write(buf, 0, buf.Count());
                    myStream.Close();
                }
            }
        }

        private void UploadHomeWork(HomeWorkInfo hwi)
        {
            Stream myStream = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|rar files (*.rar)|*.rar|All files (*.*)|*.*";
            ofd.FilterIndex = 2;
            ofd.OpenFile();

            byte[] bytes;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ofd.OpenFile()) != null)
                    {
                        using (var streamReader = new MemoryStream())
                        {
                            myStream.CopyTo(streamReader);
                            bytes = streamReader.ToArray();
                            ((AbstractStudent)user).SUploadHomeWorkToSever(new CustomFile(bytes, hwi.FileIdx as int?));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
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
