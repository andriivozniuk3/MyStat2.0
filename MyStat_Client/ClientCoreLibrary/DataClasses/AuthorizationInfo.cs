using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.PublicClasses;

namespace ClientCoreLibrary.DataClasses
{

    public enum RequestType
    {
        Authorization,
        ANewAdvertisement,
        GetAllAdvertisements,//спільний
        SGetTimetableForGroup,
        ASetLesson,
        ASetTeacher,
        GetGroupNames,
        AAddNewStudent,
        ARemoveStudent,
        GetRequests,
        SendRequset,
        AGetStudentsByGroupName,
        ADeleteLesson,
        ACreateLesson,

        //Реквести Studenta 
        SGetMyGroup,
        SGetTimetable,
        SGetStudyMaterials,
        SGetFileStudyMaterials, //общий с переподавателем, препод тоже его использует
        SGetMyStatistic,
        SGetHomeWorkInfo,
        SDownloadHomeWork,
        SUploadHomeWork,
        //Реквести Studenta
 
        //Teacher requests
        TGetGroups,
        TGetNonDoneHomeWorks,
        TSetScoreForHomeWork,
        TGetFileStudyMaterials,
        TAddHomeWork,
        TUploadStudyMaterial,
        TGetTimetable,
        TGetTodayLessons,
        TMarkAsPresent
        //END Teacher requests
    };

    public class AuthorizationInfo
    {
        public AuthorizationInfo(string login, string password, UnitType type)
        {
            _login = login;
            _password = password;
            _type = type;
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
        public UnitType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _login;
        private string _password;
        private UnitType _type;
    }
}