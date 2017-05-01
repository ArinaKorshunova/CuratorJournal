using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuratorJournal.DataBase.Models;

namespace DepersonilizeData
{
    public class Depersonilize
    {
        private const int WorkingGroupSize = 10; //размер группы в рамках которой производится деперсонализация

        private const int LastNameBias = 4; //смещение по фамилии
        private const int FirstNameBias = 3; //смещение по имени
        private const int FatherNameBias = 5; //смещение по отчеству
        private const int PhoneBias = 6; //смещение по телефону
        private const int EmailBias = 3; //смещение по email

        public List<Student> Depersonilized(List<Student> students)
        {
            List<Student> result = new List<Student>();
            
            var male = DepersonilizedGroup(students.Where(x => x.GenderId == Gender.Male.Id).ToList());
            var female = DepersonilizedGroup(students.Where(x => x.GenderId == Gender.Female.Id).ToList());

            result = male.Concat(female).ToList();

            return result.OrderBy(x => x.Id).ToList();
        }

        public void SaveNewStudent(DataBaseContext DbContext, Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> Undepersonilized(List<Student> students)
        {
            List<Student> result = new List<Student>();

            var male = UnepersonilizedGroup(students.Where(x => x.GenderId == Gender.Male.Id).ToList());
            var female = UnepersonilizedGroup(students.Where(x => x.GenderId == Gender.Female.Id).ToList());

            result = male.Concat(female).ToList();

            return result;
        }

        // применение алгоритма деперсонализации к выбранной группе
        private List<Student> DepersonilizedGroup(List<Student> students)
        {
            List<Student> result = new List<Student>();

            for(int i = 0; i <= students.Count()/WorkingGroupSize; i++)
            {
                result = result.Concat(DepersonilizeAlghoritm(students.OrderBy(x => x.Id).Skip(i* WorkingGroupSize).Take(WorkingGroupSize).ToArray())).ToList();
            }

            return result;
        }

        // применение алгоритма обратного деперсонализации к выбранной группе
        private List<Student> UnepersonilizedGroup(List<Student> students)
        {
            List<Student> result = new List<Student>();
            
            for (int i = 0; i <= students.Count() / WorkingGroupSize; i++)
            {
                result = result.Concat(UndepersonilizeAlghoritm(students.OrderBy(x => x.Id).Skip(i * WorkingGroupSize).Take(WorkingGroupSize).ToArray())).ToList();
            }

            return result;

            return result;
        }


        // алгоритм деперсонализации
        private List<Student> DepersonilizeAlghoritm(Student[] students)
        {
            int last = students.Count() - 1;
            Student[] newStudents = new Student[students.Count()];
            for (int i = 0; i < students.Count(); i++)
            {
                newStudents[i] = new Student();
            }

            int lastNameBias = GetBias(LastNameBias, students.Count());
            int firstNameBias = GetBias(FirstNameBias, students.Count());
            int fatherNameBias = GetBias(FatherNameBias, students.Count());
            int phoneBias = GetBias(PhoneBias, students.Count());
            int emailBias = GetBias(EmailBias, students.Count());

            for (int i = 0; i < students.Count(); i++)
            {
                newStudents[i].Id = students[i].Id;
                newStudents[i].GenderId = students[i].GenderId;
                newStudents[i].GroupId = students[i].GroupId;

                int lastNameIndex = i + lastNameBias >= students.Count() ? (i + lastNameBias) - students.Count() : i + lastNameBias;
                newStudents[lastNameIndex].LastName = students[i].LastName;

                int firstNameIndex = i + firstNameBias >= students.Count() ? (i + firstNameBias) - students.Count() : i + firstNameBias;
                newStudents[firstNameIndex].FirstName = students[i].FirstName;

                int fatherNameIndex = i + fatherNameBias >= students.Count() ? (i + fatherNameBias) - students.Count() : i + fatherNameBias;
                newStudents[fatherNameIndex].FatherName = students[i].FatherName;

                int phoneIndex = i + phoneBias >= students.Count() ? (i + phoneBias) - students.Count() : i + phoneBias;
                newStudents[phoneIndex].Phone = students[i].Phone;

                int emailIndex = i + emailBias >= students.Count() ? (i + emailBias) - students.Count() : i + emailBias;
                newStudents[emailIndex].Email = students[i].Email;
            }
            
            return newStudents.ToList();
        }



        // алгоритм обратный деперсонализации
        private List<Student> UndepersonilizeAlghoritm(Student[] students)
        {
            int last = students.Count() - 1;
            Student[] newStudents = new Student[students.Count()];
            for (int i = 0; i < students.Count(); i++)
            {
                newStudents[i] = new Student();
            }

            int lastNameBias = GetBias(LastNameBias, students.Count());
            int firstNameBias = GetBias(FirstNameBias, students.Count());
            int fatherNameBias = GetBias(FatherNameBias, students.Count());
            int phoneBias = GetBias(PhoneBias, students.Count());
            int emailBias = GetBias(EmailBias, students.Count());

            for (int i = 0; i < students.Count(); i++)
            {
                newStudents[i].Id = students[i].Id;
                newStudents[i].GenderId = students[i].GenderId;
                newStudents[i].GroupId = students[i].GroupId;

                int lastNameIndex = i - lastNameBias < 0  ? students.Count() + (i - lastNameBias) : i - lastNameBias;
                newStudents[lastNameIndex].LastName = students[i].LastName;

                int firstNameIndex = i - firstNameBias < 0 ? students.Count() + (i - firstNameBias) : i - firstNameBias;
                newStudents[firstNameIndex].FirstName = students[i].FirstName;

                int fatherNameIndex = i - fatherNameBias < 0 ? students.Count() + (i - fatherNameBias) : i - fatherNameBias;
                newStudents[fatherNameIndex].FatherName = students[i].FatherName;

                int phoneIndex = i - phoneBias < 0 ? students.Count() + (i - phoneBias) : i - phoneBias;
                newStudents[phoneIndex].Phone = students[i].Phone;

                int emailIndex = i - emailBias < 0 ? students.Count() + (i - emailBias) : i - emailBias;
                newStudents[emailIndex].Email = students[i].Email;
            }
            
            return newStudents.ToList();
        }

        private int GetBias(int bias, int count)
        {
            if(bias > count)
            {
                int result = bias;
                for(int i = 0; i < bias/count; i++)
                {
                    result = result - count;
                }
                return result;
            }
            return bias;
        }
    }
}
