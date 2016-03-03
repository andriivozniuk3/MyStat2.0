using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//FOR SHA1
using System.Security.Cryptography;
using System.IO;

namespace ServiceDll
{
    public class Service : IService
    {
        MyStatEntities cont = new MyStatEntities();

        public bool AuthentificateAdmin(string login, string pass)
        {
            if(cont.tbl_Administrator.Any(x => x.Login == login && x.PassHash == Hash(pass)))
            {
                return true;
            }
            return false;
        }

        public bool AuthentificateUser(string login, string pass)
        {
            if (cont.tbl_User.Any(x => x.Login == login && x.PassHash == Hash(pass)))
            {
                return true;
            }
            return false;
        }

        public bool CreateTeacher(string firstName, string lastName, string midleName, DateTime birthDate, string phoneNum, string eMail, string login, string pass)
        {
            tbl_User tu = new tbl_User();
            tu.FirstName = firstName;
            tu.LastName = lastName;
            tu.MidleName = midleName;
            tu.BirthDate = birthDate;
            tu.PhoneNum = phoneNum;
            tu.EMail = eMail;
            tu.Login = login;
            tu.PassHash = Hash(pass);
            tu.Role = "Teacher";
            cont.tbl_User.Add(tu);
            if(cont.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool CreateStudent(string firstName, string lastName, string midleName, DateTime birthDate, string phoneNum, string eMail, string login, string pass)
        {
            tbl_User tu = new tbl_User();
            tu.FirstName = firstName;
            tu.LastName = lastName;
            tu.MidleName = midleName;
            tu.BirthDate = birthDate;
            tu.PhoneNum = phoneNum;
            tu.EMail = eMail;
            tu.Login = login;
            tu.PassHash = Hash(pass);
            tu.Role = "Student";
            cont.tbl_User.Add(tu);
            if (cont.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool CreateGroup(string name, string curSubject)
        {
            tbl_Group tg = new tbl_Group();
            tg.Name = name;
            tg.CurrentSubject = curSubject;
            cont.tbl_Group.Add(tg);
            if (cont.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public void AddUserToGroup(int idUser, int idGroup)
        {
            tbl_ConGroup tcg = new tbl_ConGroup();
            tcg.IdUser = idUser;
            tcg.IdGroup = idGroup;
            cont.tbl_ConGroup.Add(tcg);
            cont.SaveChanges();

        }

        public void AddHomeworkForGroup(string login, int idGroup, string subject, string theme)
        {
            tbl_Homework th = new tbl_Homework();
            th.DateAdded = DateTime.Now;
            th.IdUser = GetIdUser(login);
            th.IdGroup = idGroup;
            th.Subject = subject;
            th.Theme = theme;
            cont.tbl_Homework.Add(th);
            cont.SaveChanges();
        }

        public string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        public void AddNews(string AdminLogin, string theme, string text)
        {
            tbl_News news = new tbl_News();
            news.IdAdministrator = GetIdAdmin(AdminLogin);
            news.DateAdded = DateTime.Now;
            news.Theme = theme;
            news.Text = text;
            cont.tbl_News.Add(news);
            cont.SaveChanges();
        }

        

        public int GetIdAdmin(string login)
        {
            return cont.tbl_Administrator.Where(x => x.Login == login).Select(x => x.IdAdministrator).ToArray()[0];
        }

        public int GetIdGroup(string login)
        {
            return cont.tbl_Group.Where(x => x.Name == login).Select(x => x.IdGroup).ToArray()[0];
        }

        public int GetIdUser(string login)
        {
            return cont.tbl_User.Where(x => x.Login == login).Select(x => x.IdUser).ToArray()[0];
        }

        public List<object> GetScheduleGroup(string Name)
        {
            List<object> list = new List<object>();
            List<tbl_AdminDaybook> ll = cont.tbl_AdminDaybook.Where(x => x.IdGroup == GetIdGroup(Name)).ToList();
            foreach (var i in ll)
            {
                list.Add((object)i);
            }
            return list;
        }

        public List<object> GetScheduleTeacher(string login)
        {
            List<object> list = new List<object>();
            List<tbl_AdminDaybook> ll = cont.tbl_AdminDaybook.Where(x => x.IdTeacher == GetIdUser(login)).ToList();
            foreach (var i in ll)
            {
                list.Add((object)i);
            }
            return list;
        }
        public void AddSchedule(string group, string teacher, DateTime date, string subj)
        {
            tbl_AdminDaybook ad = new tbl_AdminDaybook();
            ad.IdGroup = GetIdGroup(group);
            ad.IdTeacher = GetIdUser(teacher);
            ad.LessonsDate = date;
            ad.Subject = subj;
            cont.tbl_AdminDaybook.Add(ad);
            cont.SaveChanges();
        }

        public void DelSchedule(string group, DateTime date)
        {
            cont.tbl_AdminDaybook.Remove(cont.tbl_AdminDaybook.Where(x => x.IdGroup == GetIdGroup(group) && x.LessonsDate == date).ToList()[0]);
            cont.SaveChanges();
        }

        public List<object> GetStatus(string group)
        {
            List<object> myList = new List<object>();

            foreach (var dayBook in cont.tbl_Daybook)
            {
                if (dayBook.IdGroup == GetIdGroup(group))
                myList.Add((object)dayBook);
            }
            return myList;
        }

        public List<string> GetNews()
        {
            return cont.tbl_News.Select(VARIABLE => VARIABLE.Theme + "%" + VARIABLE.Text + "%" + VARIABLE.DateAdded).ToList(); //
        }

        public void UploadHomework(byte[] file, string filename, string login, int idHomework)
        {
            tbl_DoneHomework tdh = new tbl_DoneHomework();
            tdh.DateAdded = DateTime.Now;
            tdh.IdUser = GetIdUser(login);
            tdh.Mark = 0;
            tdh.zipFile = "HW//" + login + tdh.IdDoneHomework + filename;
            FileStream fs = new FileStream("HW//" + login + tdh.IdDoneHomework + filename, FileMode.Create, FileAccess.Write);
            fs.Write(file, 0, file.Length);
            fs.Close();
            cont.tbl_DoneHomework.Add(tdh);
            cont.SaveChanges();
        }

        public byte[] DownloadHomework(string logTeacher, string logStudent, int idHomework)
        {
            string path = cont.tbl_DoneHomework.Where(x => x.IdUser == GetIdUser(logStudent) && x.IdHomework == idHomework).Select(
                x => x.zipFile).ToList().First();
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);

            byte[] buff = new byte[file.Length];
            file.Read(buff, 0, buff.Length);

            file.Close();
            return buff;

        }

        public void AddTrainingMaterial(byte[] file,  string _Name, string _Subject, string fileName)
        {
            tbl_TrainingMaterial TRM = new tbl_TrainingMaterial();
            
            TRM.Name = _Name;
            TRM.Subject = _Subject;
            TRM.DateAdded = DateTime.Now;

            FileStream UPLOAD = new FileStream("TrainingMatherials//" + fileName, FileMode.Create, FileAccess.Write);
            UPLOAD.Write(file, 0, file.Length);
            UPLOAD.Close();

            TRM.zipFile = "TrainingMatherials//" + fileName;

            cont.tbl_TrainingMaterial.Add(TRM);
            cont.SaveChanges();
        }

        public byte[] DownloadTrainingMaterial( int idTrainingMatherial )
        {

            string path = cont.tbl_TrainingMaterial.Where(x => x.IdTrainingMaterial == idTrainingMatherial).Select(
                x => x.zipFile).ToList().First();
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);

            byte[] buff = new byte[file.Length];
            file.Read(buff, 0, buff.Length);

            file.Close();
            return buff;
        }

        public string GetUser(string login)
        {
            try
            {
                return cont.tbl_User.Where(x => x.IdUser == GetIdUser(login)).Select(x => x.FirstName + "%" + x.MidleName + "%" +
                    x.LastName + "%" + x.BirthDate.ToString() + "%" + x.EMail + "%" + x.PhoneNum).ToList().First();
            }
            catch
            {
                return "";
            }
        }

        public List<string> GetGroupsForTeacher(string login)
        {
            List<string> res = new List<string>();
            List<int?> idxs = cont.tbl_ConGroup.Where(x => x.IdUser == GetIdUser(login)).Select(y => y.IdGroup).ToList();
            foreach(int n in idxs)
            {
               res.Add( cont.tbl_Group.Where(x => x.IdGroup == n).Select(x => x.Name).ToList()[0]);
            }
            return res;
        }

        public List<string> GetGroupsForAdmin(string login)
        {
            return cont.tbl_Group.Select(x => x.Name).ToList();
        }

        public List<int> GetStudents(string group)
        {
            List<int> res = new List<int>();
           foreach( int n in cont.tbl_ConGroup.Where(x => x.IdGroup == GetIdGroup(group)).Select(x => x.IdUser).ToList())
            {
               res.Add( cont.tbl_User.Where(x => x.IdUser == n && x.Role == "Student").Select(x => x.IdUser).ToList().First());
            }
            return res;
        }

        public void AddFeedback(string login, string theme, string text)
        {
            tbl_Feedback tf = new tbl_Feedback();
            tf.DateAdded = DateTime.Now;
            tf.IdUser = GetIdUser(login);
            tf.Theme = theme;
            tf.Text = text;
            cont.tbl_Feedback.Add(tf);
            cont.SaveChanges();
        }

        public List<string> GetFeedback()
        {
            List<string> res = new List<string>();
            foreach(var i in cont.tbl_Feedback)
            {
                res.Add(i.Theme + "%" + i.Text + "%" + i.DateAdded.ToString());
            }
            return res;
        }


    }
}
