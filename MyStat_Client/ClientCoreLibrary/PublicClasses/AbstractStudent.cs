using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientCoreLibrary.DataClasses;
using System.IO;

namespace ClientCoreLibrary.PublicClasses
{
    public abstract class AbstractStudent : AbstractUnit
    {
        public AbstractStudent(Proxy proxy) : base(proxy) 
        {}

        public abstract List<Advertisement> GetAllAdvertisements();
        public abstract GroupInfo SGetMyGroup();
        public abstract Timetable SGetTimetable();
        public abstract List<StudyMaterialInfo> SGetStudyMaterials(string theme);
        public abstract Stream SGetFileStudyMaterials(int? fileIdx);
        public abstract Statistic SGetMyStatistic();
        public abstract List<HomeWorkInfo> SGetHomeWorkInfo();
        public abstract Stream SDownLoadHomeWorkFromSever(int? fileIdx);
        public abstract void SUploadHomeWorkToSever(CustomFile fileHomeWork);

        public abstract byte[] SGetFileStudyMaterialsInBytes(int? fileIdx);
        public abstract byte[] SDownLoadHomeWorkFromSeverInBytes(int? fileIdx); 
    }
}
