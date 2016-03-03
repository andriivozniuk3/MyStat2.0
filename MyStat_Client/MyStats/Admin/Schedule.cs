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
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
            PanelHomework.BackColor = Color.LightSlateGray;

        }
        AbstractAdmin _admin;
        ListView[] lv;
        ListView _currentLv;
        Thread thread;
        public Schedule(AbstractAdmin admin) 
        {
            InitializeComponent();
            PanelHomework.BackColor = Color.LightSlateGray;

            lv = new ListView[] { this.lvMonday, this.lvTuesday, this.lvWednesday, this.lvThursday, this.lvFriday };
            
            _admin = admin;

            lblLogin.Text = _admin.Login;
            lblName.Text = _admin.FirstName;
            lblLastname.Text = _admin.LastName;

            cbGroups.DataSource = null;
           // cbGroups.Items.Clear();
           // cbGroups.DataSource = _admin.GetGroupNames();


        }

        private void ICOPresent_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(OpenGroupForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);

        }
        #region NewForm
        private void OpenGroupForm(object obj)
        {
            Application.Run(new Group((AbstractAdmin)obj));
        }

        private void OpenNewsForm(object obj)
        {
            Application.Run(new SendNews((AbstractAdmin)obj));
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

        private void ICOLibrary_Click(object sender, EventArgs e)
        {

            this.Close();
            this.thread = new Thread(AdminRequests);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);

          
        }

        private void ICONews_Click(object sender, EventArgs e)
        {

            this.Close();
            this.thread = new Thread(OpenNewsForm);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);
           
        }



        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.thread = new Thread(Logout);
            this.thread.SetApartmentState(ApartmentState.STA);
            this.thread.Start(_admin);

          
        }



        private void cbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbGroups.SelectedIndex < 0)
                return;

            // _admin.LoadTimetableForGroup(this.cbGroups.SelectedItem.ToString());


            #region showTimetable
            Lesson monday = new Lesson("monday", "taras", null, DateTime.Now);
            Lesson tuesday = new Lesson("tuesday", "andy", null, DateTime.Now);
            Lesson wednesday = new Lesson("wednesday", "adfw", null, DateTime.Now);
            Lesson thursday = new Lesson("thursday", "taras", null, DateTime.Now);
            Lesson friday = new Lesson("friday", "taras", null, DateTime.Now);

            List<ClientCoreLibrary.DataClasses.Day> days = new List<ClientCoreLibrary.DataClasses.Day>()
                {
                  new ClientCoreLibrary.DataClasses.Day(new List<Lesson>() 
                  {
                    monday, null, null, null, null , null , null, null
                  }),
                  new ClientCoreLibrary.DataClasses.Day(new List<Lesson>() 
                  {
                    null, tuesday, null, null, null , null , null, null
                  }),
                  new ClientCoreLibrary.DataClasses.Day(new List<Lesson>() 
                  {
                    null, null, null, wednesday, null , null , null, null
                  }),
                  new ClientCoreLibrary.DataClasses.Day(new List<Lesson>() 
                  {
                    null, null, null, null, null , thursday , null, null
                  }),
                  new ClientCoreLibrary.DataClasses.Day(new List<Lesson>() 
                  {
                    null, null, null, null, null , null , friday, null
                  })
                };
            #endregion


            Timetable temp = new Timetable(days);


            ShowTimetable(temp);
        }

        private void ShowTimetable(Timetable timeTable)
        {

            for (int i = 0; i < 5; i++)
            {
                lv[i].Items.Clear();
                for (int j = 0; j < 8; j++)
                {
                    ListViewItem lvi;
                    if (timeTable.Days[i].Lessons[j] != null)
                        lvi = new ListViewItem(new string[] { timeTable.Days[i].Lessons[j].Time.ToString(), timeTable.Days[i].Lessons[j].Name, timeTable.Days[i].Lessons[j].Teacher });
                    else
                        lvi = new ListViewItem(new string[]{"","",""});

                    lv[i].Items.Add(lvi);
                }
            }
        }

        private void lvFriday_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            MessageBox.Show(((ListView)sender).Name, ((ListView)sender).SelectedItems[0].ToString());
        }

        private void lvMonday_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView day = sender as ListView;

            if (day.SelectedIndices.Count <= 0)
                return;

            tbLesson.Text = day.SelectedItems[0].SubItems[1].Text;
            tbTeacher.Text = day.SelectedItems[0].SubItems[2].Text;

            _currentLv = day;

        }

        private void btnSetTeacher_Click(object sender, EventArgs e)
        {
            _currentLv.SelectedItems[0].SubItems[2].Text = tbTeacher.Text;

            /*
            for (int i = 0; i < 5; i++) 
            {
                if (lv[i].Name == _currentLv.Name) 
                {
                    _admin.SetTeacher(i, _currentLv.SelectedIndices[0], tbTeacher.Text);
                    break;
                }
            }
            */
        }

        private void btnSetLesson_Click(object sender, EventArgs e)
        {
            _currentLv.SelectedItems[0].SubItems[1].Text = tbLesson.Text;

            /*
            for (int i = 0; i < 5; i++) 
            {
                if (lv[i].Name == _currentLv.Name) 
                {
                    _admin.SetLesson(i, _currentLv.SelectedIndices[0], tbLesson.Text);
                    break;
                }
            }*/
            
        }



        private void btnDeleteLesson_Click(object sender, EventArgs e)
        {

            _currentLv.SelectedItems[0].SubItems[0].Text = "";
            _currentLv.SelectedItems[0].SubItems[1].Text = "";
            _currentLv.SelectedItems[0].SubItems[2].Text = "";

            for (int i = 0; i < 5; i++)
            {
                if (lv[i].Name == _currentLv.Name) 
                {
                   // _admin.DeleteLesson(i, _currentLv.SelectedIndices[0]);
                    break;
                }
            
            }
        }

        private void btnCreateLesson_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbLesson.Text) || String.IsNullOrEmpty(tbTeacher.Text))
                return;
            _currentLv.SelectedItems[0].SubItems[0].Text = DateTime.Now.ToShortTimeString();
            _currentLv.SelectedItems[0].SubItems[1].Text = tbLesson.Text;
            _currentLv.SelectedItems[0].SubItems[2].Text = tbTeacher.Text;

            for (int i = 0; i < 5; i++)
            {
                if (lv[i].Name == _currentLv.Name)
                {
                    //_admin.CreateLesson(i, _currentLv.SelectedIndices[0], new Lesson(tbLesson.Text, tbTeacher.Text, cbGroups.SelectedItem.ToString(), DateTime.Now));
                    break;
                }

            }
        }

        private void ICOHomework_Click(object sender, EventArgs e)
        {

        }


       

        
    }
}
