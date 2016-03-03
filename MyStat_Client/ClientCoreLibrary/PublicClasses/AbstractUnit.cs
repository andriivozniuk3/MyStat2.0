using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.DataClasses;

namespace ClientCoreLibrary.PublicClasses
{
   
    
    public abstract class AbstractUnit
    {
        public AbstractUnit(Proxy proxy) 
        {
            _proxy = proxy;
        }       
        public bool Authorization() 
        {
            AuthorizationInfo authorizationInfo = new AuthorizationInfo(_login, _password, _userType);
            AuthorizationResult result = (AuthorizationResult)_proxy.SendRequest(RequestType.Authorization , authorizationInfo);
            
            if (result.IsAllowed)
            {
                _firstName = result.FirstName;
                _lastName = result.LastName;
                return result.IsAllowed;
            }
            else 
            {
                return result.IsAllowed;
            }
        }
        public abstract List<Request> GetRequests();
        public abstract void SendRequest(UnitInfo receiver, string text);

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
        public UnitType UnitType 
        {
            set { _userType = value; }
            get { return _userType; }
        }


        protected Proxy _proxy;
        protected UnitType _userType;
        protected string _login;
        protected string _password;
        protected string _firstName;
        protected string _lastName;
    }
}
