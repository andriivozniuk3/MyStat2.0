
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.PublicClasses;
using ClientCoreLibrary.DataClasses;
using System.IO;

namespace ClientCoreLibrary.Implementation
{
    class Student : AbstractStudent
    {
        public Student(Proxy proxy)
            : base(proxy)
        {}

        private static Student _instance;

        public static Student GetInstance(Proxy proxy)
        {
            if (_instance != null)
                return _instance;
            return (_instance = new Student(proxy));
        }

        public override List<Advertisement> GetAllAdvertisements()
        {
            return (List<Advertisement>)_proxy.SendRequest(RequestType.GetAllAdvertisements, null);
        }

        public override List<Request> GetRequests()
        {
            return (List<Request>)_proxy.SendRequest(RequestType.GetRequests, null);
        }

        public override void SendRequest(UnitInfo receiver, string text)//receiver - ним може бути або адмін або студент (в залежності як ми ініціалізуємо (чи адміном чи викладачем) екземпляр класу UnitInfo
        {
            Request request = new Request(new StudentInfo(this.FirstName, this.LastName, null, null, null), receiver, DateTime.Now, text);
            _proxy.SendRequest(RequestType.SendRequset, request);
        }

        public override GroupInfo SGetMyGroup()
        {
            return (GroupInfo)_proxy.SendRequest(RequestType.SGetMyGroup, this._login);//Хочу отримати групу поточного студента за його логіном
        }

        public override Timetable SGetTimetable()//Хочу отримати розклад занять за групою студента
        {
            return (Timetable)_proxy.SendRequest(RequestType.SGetTimetable, SGetMyGroup().Name);
        }

        public override Statistic SGetMyStatistic()
        {
            return (Statistic)_proxy.SendRequest(RequestType.SGetMyStatistic, this._login);//Хочу отримати статистику студента за його логіном
        }

        public override List<HomeWorkInfo> SGetHomeWorkInfo()
        {
            return (List<HomeWorkInfo>)_proxy.SendRequest(RequestType.SGetHomeWorkInfo, this._login);//Хочу отримати список домашок студента за його логіном
        }

        public override List<StudyMaterialInfo> SGetStudyMaterials(string theme)
        {
            return (List<StudyMaterialInfo>)_proxy.SendRequest(RequestType.SGetStudyMaterials, theme);//Хочу отримати список навчальних матеріалів за назвою теми(предмета)
        }

        public override Stream SGetFileStudyMaterials(int? fileIdx)//fileIdx - це індекс файла в таблиці
        {
            return (Stream)_proxy.SendRequest(RequestType.SGetFileStudyMaterials, fileIdx); //Хочу отримати(скачати) файл що містить навчальний матеріал
        }

        public override Stream SDownLoadHomeWorkFromSever(int? fileIdx)//fileIdx - це індекс файла (з скачати домашньої) в таблиці
        {
            return (Stream)_proxy.SendRequest(RequestType.SDownloadHomeWork, fileIdx);//Хочу отримати(скачати) файл з завданням домашньої
        }

        public override void SUploadHomeWorkToSever(CustomFile fileHomeWork)//fileIdx в класі CustomFile - це індекс файла (з відповіддю домашньої), який має співпадати з індексом файла (з завданянм домашньої) в таблиці, тобто вони в одному рядку мають бути
        {
            _proxy.SendRequest(RequestType.SUploadHomeWork, fileHomeWork);//Хочу відправити на сервер файл зі своєю домашкою
        }

        public override byte[] SGetFileStudyMaterialsInBytes(int? fileIdx)                        //оверрайднутая версия, для работы с массивом байтов 1
        {
            return (byte[])_proxy.SendRequest(RequestType.SGetFileStudyMaterials, fileIdx);
        }

        public override byte[] SDownLoadHomeWorkFromSeverInBytes(int? fileIdx)                        //оверрайднутая версия, для работы с массивом байтов 1
        {
            return (byte[])_proxy.SendRequest(RequestType.SDownloadHomeWork, fileIdx);
        }
    }
}
