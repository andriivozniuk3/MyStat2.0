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

namespace MyStats
{
    public partial class Present : Form
    {
        AbstractUnit user;
        List<Lesson> lessons;
        List<GroupInfo> groups;
        Thread thread;
        public Present(AbstractUnit user)
        {
            InitializeComponent();
            PanelPresent.BackColor = Color.LightSlateGray;
            this.user = user;
            //CreatePanels();

            //lessons = GetTodayLessons();        //TODO в отдельном потоке вызываем
            //groups = GetGroups();               //TODO в отдельном потоке вызываем

            //this.cbTodaysLessons.DataSource = lessons;
            //this.cbTodaysLessons.DisplayMember = "Name";
        }

        private List<Lesson> GetTodayLessons()
        {
            return ((AbstractTeacher)this.user).GetTodayLessons();
        }

        private List<GroupInfo> GetGroups()
        {
            return ((AbstractTeacher)this.user).GetGroups();
        }

        private void CreatePanels(GroupInfo gi)
        {
            for (int i = 0; i < gi.Students.Count(); i++)
            {
                Panel p = new Panel();
                p.BackColor = Color.RoyalBlue;
                p.Size = new Size(463, 43);
                p.Tag = gi.Students[i];

                Label lName = new Label();
                lName.Text = gi.Students[i].FirstName + " " + gi.Students[i].LastName;
                p.Controls.Add(lName);
                p.Controls[0].Location = new Point(20, 15);

                RadioButton rbYes = new RadioButton();
                rbYes.Text = "YES";
                p.Controls.Add(rbYes);
                p.Controls[1].Location = new Point(185, 10);

                RadioButton rbNo = new RadioButton();
                rbNo.Text = "NO";
                rbNo.Checked = true;
                p.Controls.Add(rbNo);
                p.Controls[2].Location = new Point(300, 10);


                this.MainPanel.Controls.Add(p);
                if (i == 0)
                    this.MainPanel.Controls[i].Location = new Point(37, 17);
                else
                    this.MainPanel.Controls[i].Location = new Point(this.MainPanel.Controls[i - 1].Location.X, this.MainPanel.Controls[i - 1].Location.Y + 50);
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

        private void cbTodaysLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lesson lesson = cbTodaysLessons.SelectedItem as Lesson;
            foreach(var group in groups)
            {
                if(group.Name == lesson.Group)
                {
                    CreatePanels(group);
                    break;
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (cbTodaysLessons.SelectedItem == null)
                return;

            Lesson lesson = cbTodaysLessons.SelectedItem as Lesson;
            Dictionary<StudentInfo, bool> journal = new Dictionary<StudentInfo, bool>();
            foreach(var p in this.MainPanel.Controls)
            {
                journal.Add(((StudentInfo)((Panel)p).Tag), ((RadioButton)((Panel)p).Controls[1]).Checked);
            }
            ((AbstractTeacher)this.user).MarkAsPresent(lesson, journal);
        }
    }
}
