using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class StudentInfo: UnitInfo
    {
        public StudentInfo(string firstName, string lastName,string login, string password,  string group)
            :base(firstName, lastName)
        {
            _groupName = group;
            _login = login;
            _password = password;
        }
        
        public string PersonalGroup
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _login;
        private string _password;
        private string _groupName;
    }
}
