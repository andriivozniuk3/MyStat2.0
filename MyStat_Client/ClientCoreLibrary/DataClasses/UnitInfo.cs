using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    public class UnitInfo
    {
        public UnitInfo(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
        public string FirstName 
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName ; }
            set { _lastName = value; }
        }
        private string _firstName;
        private string _lastName;
    }

}
