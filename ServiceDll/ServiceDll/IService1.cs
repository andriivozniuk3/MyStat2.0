using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceDll
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        bool AuthentificateAdmin(string login, string pass);
        
        [OperationContract]
        bool AuthentificateUser(string login, string pass);

        [OperationContract]
        void AddNews(string AdminLogin, string theme, string text);
        [OperationContract]
        int GetIdUser(string login);
        [OperationContract]
        int GetIdGroup(string login);
        [OperationContract]
        int GetIdAdmin(string login);
        [OperationContract]
        List<object> GetScheduleGroup(string Name);
        [OperationContract]
        List<object> GetScheduleTeacher(string login);
        [OperationContract]
        bool CreateTeacher(string firstName, string lastName, string midleName, DateTime birthDate, 
            string phoneNum, string eMail, string login, string pass);
        [OperationContract]
        bool CreateStudent(string firstName, string lastName, string midleName, DateTime birthDate, 
            string phoneNum, string eMail, string login, string pass);
        [OperationContract]
        bool CreateGroup(string name, string curSubject);
        [OperationContract]
        void AddUserToGroup(int idUser, int idGroup);
        [OperationContract]
        void AddHomeworkForGroup(string login, int idGroup, string subject, string theme);
        [OperationContract]
        void AddSchedule(string group, string teacher, DateTime date, string subj);
        [OperationContract]
        void DelSchedule(string group, DateTime date);

        [OperationContract]
        void UploadHomework(byte[] file, string filename, string login, int idHomework);
        
        [OperationContract]
        byte[] DownloadHomework(string filename, string login, int idHomework);

        [OperationContract]
        string GetUser(string login);

        [OperationContract]
        byte[] DownloadTrainingMaterial(int idTrainingMatherial);

        [OperationContract]
        void AddTrainingMaterial(byte[] file, string _Name, string _Subject, string fileName);

        [OperationContract]
        List<string> GetGroupsForTeacher(string login);

        [OperationContract]
        List<int> GetStudents(string group);

        [OperationContract]
        void AddFeedback(string login, string theme, string text);

        [OperationContract]
        List<string> GetFeedback();
    }
}
