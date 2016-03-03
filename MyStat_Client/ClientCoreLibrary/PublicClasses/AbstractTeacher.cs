using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.DataClasses;
using ClientCoreLibrary.PublicClasses;
using System.IO;

namespace ClientCoreLibrary.PublicClasses
{
    public abstract class AbstractTeacher : AbstractUnit
    {
        public AbstractTeacher(Proxy proxy) : base(proxy) 
        { }

       // public abstract List<Request> GetRequests();

       // public abstract void SendRequest(UnitInfo receiver, string text);

        public abstract List<GroupInfo> GetGroups();

        public abstract List<HomeWorkInfo> GetNonDoneHomeWorks();

        public abstract void SetScoreForHomeWork(HomeWorkInfo hwi, int score);

        public abstract void AddHomeWork(HomeWorkInfo hwi);

        public abstract List<Advertisement> GetAllAdvertisements();

        public abstract Stream DownLoadHomeWorkFromService(int? fileIdx);                                   //работа с файлами закачка стрим

        public abstract Stream DownloadStudyMaterialFromService(int? fileIdx);                              //работа с файлами закачка стрим

        public abstract byte[] DownLoadHomeWorkFromServiceInBytes(int? fileIdx);                            //работа с файлами закачка байт

        public abstract byte[] DownloadStudyMaterialFromServiceInBytes(int? fileIdx);                       //работа с файлами закачка байт

        public abstract void UploadStudyMaterialToSevice(StudyMaterialInfo smi, CustomFile file);           //работа с файлами скачка кастом

        public abstract void UploadStudyMaterialToSeviceInBytes(StudyMaterialInfo smi, byte[] file);               //работа с файлами скачка байт

        public abstract Timetable TGetTimetable();

        public abstract List<Lesson> GetTodayLessons();

        public abstract void MarkAsPresent(Lesson lesson, Dictionary<StudentInfo, bool> journal);
    }
}
