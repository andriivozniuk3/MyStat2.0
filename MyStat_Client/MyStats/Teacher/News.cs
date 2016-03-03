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
    public partial class News : Form
    {
        AbstractUnit user;
        Thread thread;
        public News(AbstractUnit user)
        {
            InitializeComponent();
            PanelNews.BackColor = Color.LightSlateGray;
            this.user = user;

            //this.GetAllAdvertisements();    //TO DO: запускать в отдельном потоке
            //this.GetRequests();             //TO DO: запускать в отдельном потоке
        }

        private void GetAllAdvertisements()
        {
            List<Advertisement> advers = ((AbstractTeacher)user).GetAllAdvertisements();
            //advers[0].
            this.lbNews.DataSource = null;
            this.lbNews.DataSource = advers;
            this.lbNews.DisplayMember = "Title";
        }

        private void GetRequests()
        {
            List<Request> requests = ((AbstractTeacher)user).GetRequests();
            this.QuestListBox.DataSource = null;
            this.QuestListBox.DataSource = requests;
            //requests[0].Sender
            this.QuestListBox.DisplayMember = "Sender";
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

        private void lbNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbNews.SelectedItem == null)
                return;

            this.tbNews.Text = ((Advertisement)this.lbNews.SelectedItem).Info;
        }

        private void QuestListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.QuestListBox.SelectedItem == null)
                return;

            this.tbNews.Text = ((Request)this.QuestListBox.SelectedItem).Text;
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (this.QuestListBox.SelectedItem == null)
                return;

            ((AbstractTeacher)user).SendRequest(((Request)this.QuestListBox.SelectedItem).Sender as StudentInfo, this.textBox1.Text);
        }
    }
}
