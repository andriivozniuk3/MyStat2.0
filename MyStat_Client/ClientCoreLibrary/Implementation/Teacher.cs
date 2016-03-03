using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.DataClasses;
using ClientCoreLibrary.PublicClasses;
using System.IO;
namespace ClientCoreLibrary.Implementation
{
    class Teacher : AbstractTeacher
    {
        public Teacher(Proxy proxy)
            : base(proxy)
        { }

        private static Teacher _instance;

        public static Teacher GetInstance(Proxy proxy)
        {
            if (_instance != null)
                return _instance;
            return (_instance = new Teacher(proxy));
        }

        

        public override List<Request> GetRequests() //посылаю идентификацинные данные, так как нужно получать реквесты предназначенные только для преподов/преподавателя
        {
            return (List<Request>)_proxy.SendRequest(RequestType.GetRequests, this._login);
        }

        public override void SendRequest(UnitInfo receiver, string text) //копипаст коммента: //receiver - ним може бути або адмін або студент (в залежності як ми ініціалізуємо (чи адміном чи викладачем) екземпляр класу UnitInfo
        {
            Request request = new Request(new TeacherInfo(this.FirstName, this.LastName, new List<GroupInfo>()), receiver, DateTime.Now, text);
            _proxy.SendRequest(RequestType.SendRequset, request);
        }

        public override List<GroupInfo> GetGroups() //собственно реквест на все свои группы
        {
            return (List<GroupInfo>)_proxy.SendRequest(RequestType.TGetGroups, this._login);
        }

        public override List<HomeWorkInfo> GetNonDoneHomeWorks() //учителя не должны волновать уже сделаные домашки, нужно возращать только те, к которым есть файл и нету поставленной оценки
        {
            return (List<HomeWorkInfo>)_proxy.SendRequest(RequestType.TGetNonDoneHomeWorks, this.Login);
        }

        public override void SetScoreForHomeWork(HomeWorkInfo hwi, int score) //обновляю хоумворк инфо и посылаю на сервис уже с оценкой, для добавки её в бд
        {
            hwi.Mark = score;
            _proxy.SendRequest(RequestType.TSetScoreForHomeWork, hwi);
        }

        public override void AddHomeWork(HomeWorkInfo hwi) //преподаватель просто вылаживает тему и описание задания (без файла), хфи класс который содержит инфу кому, кто и когда выложил
        {
            _proxy.SendRequest(RequestType.TAddHomeWork, hwi);
        }

        public override List<Advertisement> GetAllAdvertisements() //ну тут надеюсь понятно, просто вся объявления берем
        {
            return (List<Advertisement>)_proxy.SendRequest(RequestType.GetAllAdvertisements, null);
        }

        public override Stream DownLoadHomeWorkFromService(int? fileIdx) //fileIdx - це індекс файла в таблиці //UPD у нас есть специальный класс со всей инфой, но разработчик студента решил отправлять только один индекс с него, я делаю так же чоб логика сохранялась
        {
            return (Stream)_proxy.SendRequest(RequestType.SDownloadHomeWork, fileIdx);
        }

        public override Stream DownloadStudyMaterialFromService(int? fileIdx) //fileIdx - це індекс файла в таблиці //UPD у нас есть специальный класс со всей инфой, но разработчик студента решил отправлять только один индекс с него, я делаю так же чоб логика сохранялась
        {
            return (Stream)_proxy.SendRequest(RequestType.SGetFileStudyMaterials, fileIdx);
        }

        public override byte[] DownLoadHomeWorkFromServiceInBytes(int? fileIdx)                        //оверрайднутая версия, для работы с массивом байтов 1
        {
            return (byte[])_proxy.SendRequest(RequestType.SDownloadHomeWork, fileIdx);
        }

        public override byte[] DownloadStudyMaterialFromServiceInBytes(int? fileIdx)                   //оверрайднутая версия, для работы с массивом байтов 2
        {
            return (byte[])_proxy.SendRequest(RequestType.SGetFileStudyMaterials, fileIdx);
        }


        public override void UploadStudyMaterialToSevice(StudyMaterialInfo smi, CustomFile file) //отправляю файл учёбного материала вместе со всей инфой по нём в бд
        {
            _proxy.SendRequest(RequestType.TUploadStudyMaterial, new object[] { smi, file });
        }

        public override void UploadStudyMaterialToSeviceInBytes(StudyMaterialInfo smi, byte[] file) //Оверрайднутая версия, где посылаем массив байтов
        {
            _proxy.SendRequest(RequestType.TUploadStudyMaterial, new object[] { smi, file });
        }

        public override Timetable TGetTimetable()       //получаем расписание для учителя по его логину
        {
            return (Timetable)_proxy.SendRequest(RequestType.TGetTimetable, this.Login);
        }

        public override List<Lesson> GetTodayLessons() //вощем получаем все сегодняшние уроки для этого учителя
        {
            return (List<Lesson>)_proxy.SendRequest(RequestType.TGetTodayLessons, this.Login);
        }

        public override void MarkAsPresent(Lesson lesson, Dictionary<StudentInfo, bool> journal) //отправляем в бд информацию по уроке, а так же массив со списком учеников на нём с пометкой кто был/отсутствовал
        {
            _proxy.SendRequest(RequestType.TMarkAsPresent, new object[] {lesson, journal, this.Login}); //логин чоб было понятно кто вел урок
        }

        //я знаю, что некоторого функционала может не хватать, но я выбрал на свой взгляд самый важный, ибо время поджимает
    }
}
