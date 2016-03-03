using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientCoreLibrary;
using ClientCoreLibrary.DataClasses;
using ClientCoreLibrary.PublicClasses;
using System.Threading;




namespace MyStats
{
    public partial class Login : Form
    {
        private Thread thread;
        Proxy _proxy;
        AbstractFactory _factory;

        public Login()
        {
            InitializeComponent();
            this.cbUser.SelectedIndex = 2;

            _proxy = new Proxy();
            _factory = UniversityFactory.CreateFactory(_proxy);



        }




        private void EnterLogin(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(tbLogin.Text) || String.IsNullOrEmpty(tbPassword.Text))
                return;

            UnitType type = (UnitType)this.cbUser.SelectedIndex;

            AbstractUnit unit;

            switch (type)
            {
                case UnitType.Student:
                    unit = _factory.CreateStudent();
                    break;
                case UnitType.Teacher:
                    unit = _factory.CreateTeacher();
                    break;
                default:
                    unit = _factory.CreateAdmin();
                    break;
            }

            unit.UnitType = type;
            unit.Login = this.tbLogin.Text;
            unit.Password = this.tbPassword.Text;

            /*
              if (!unit.Authorization())
                return;
            */
            switch (type)
            {
                case UnitType.Student:
                    this.Close();
                        this.thread = new Thread(OpenStudentForm);
                        this.thread.SetApartmentState(ApartmentState.STA);
                        this.thread.Start(unit);
                    break;
                case UnitType.Teacher:
                     this.Close();
                        this.thread = new Thread(OpenTeacherForm);
                        this.thread.SetApartmentState(ApartmentState.STA);
                        this.thread.Start(unit);
                  
                    break;

                default:
                        this.Close();
                        this.thread = new Thread(OpenAdminForm);
                        this.thread.SetApartmentState(ApartmentState.STA);
                        this.thread.Start(unit);
                    break;
            }





        }

        private void OpenTeacherForm(object obj)
        {
            Application.Run(new Homework((AbstractTeacher)obj));
        }


        private void OpenAdminForm(object obj)
        {
            Application.Run(new Admin.Schedule((AbstractAdmin)obj));
        }
        private void OpenStudentForm(object obj)
        {
            Application.Run(new Learner.News((AbstractStudent)obj));
        }
    }
}
