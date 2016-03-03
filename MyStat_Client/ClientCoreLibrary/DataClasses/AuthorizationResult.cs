using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientCoreLibrary.DataClasses
{
    class AuthorizationResult
    {
        private bool _isAllowed;
        private string _firstName;
        private string _lastName;

        public AuthorizationResult(bool isAllowed, string firstname, string lastname)
        {
            _isAllowed = isAllowed;
            _firstName = firstname;
            _lastName = lastname;
        }

        public string FirstName 
        {
            set { _firstName = value; }
            get { return _firstName; }
        }

        public string LastName
        {
            set { _lastName = value; }
            get { return _lastName; }
        }

        public bool IsAllowed 
        {
            set { _isAllowed = value; }
            get { return _isAllowed;  }
        }

       

    }
}
