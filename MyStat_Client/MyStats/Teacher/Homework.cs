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
    public partial class Homework : Form
    {
        private AbstractUnit user;
        Thread thread;
        public Homework(AbstractUnit user)
        {
            InitializeComponent();
            PanelHomework.BackColor = Color.LightSlateGray;
            this.user = user;

            //this.GetHomeWorks();
        }

        private void GetHomeWorks()
        {
            List<HomeWorkInfo> homeworks = ((AbstractTeacher)this.user).GetNonDoneHomeWorks(); //TO DO: исправить на получение в другом потоке

            for (int i = 0; i < homeworks.Count; i++)
            {
                Panel p = new Panel();
                p.BackColor = Color.RoyalBlue;
                p.Size = new Size(530, 43);

                PictureBox pb = new PictureBox();
                pb.Cursor = Cursors.Hand;
                pb.Size = new Size(36, 36);
                pb.ImageLocation = @"C:\Users\denis\Desktop\MyStat_WithInterface\MyStats\Resources\donwl.png";
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

                ComboBox cbScore = new ComboBox();
                cbScore.Size = new Size(85, 21);
                cbScore.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
                cbScore.DropDownStyle = ComboBoxStyle.DropDownList;
                p.Controls.Add(cbScore);
                p.Controls[4].Location = new Point(405, 9);

                Button btnSetScore = new Button();
                btnSetScore.Text = "Ok";
                btnSetScore.Size = new Size(30, 26);
                btnSetScore.Click += btnSetScore_Click;
                p.Controls.Add(btnSetScore);
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

            DownloadByteHomeWork(hwi);                  //TODO вызывать в потоке
        }

        private void DownloadByteHomeWork(HomeWorkInfo hwi)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = hwi.Name;
            saveFileDialog1.RestoreDirectory = true;
 
            byte[] buf = ((AbstractTeacher)user).DownLoadHomeWorkFromServiceInBytes(hwi.FileIdx);

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Write(buf, 0, buf.Count());
                    myStream.Close();
                }
            }
        }


        void btnSetScore_Click(object sender, EventArgs e)
        {
            Panel p = ((Button)sender).Parent as Panel;
            int score = (int)((ComboBox)p.Controls[4]).SelectedItem;
            HomeWorkInfo hwi = (HomeWorkInfo)p.Tag;
            ((AbstractTeacher)this.user).SetScoreForHomeWork(hwi, score);

            int idx = this.MainPanel.Controls.IndexOf(p);
            this.MainPanel.Controls.Remove(p);
            for(int i = idx; i < this.MainPanel.Controls.Count; i++)
            {
                this.MainPanel.Controls[i].Location = new Point(this.MainPanel.Controls[i].Location.X, this.MainPanel.Controls[i].Location.Y - 50);
            }
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

    }
}
