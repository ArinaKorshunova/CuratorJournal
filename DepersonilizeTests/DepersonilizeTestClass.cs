using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CuratorJournal.DataBase.Models;
using System.Linq;
using DepersonilizeData;
using System.Collections.Generic;

namespace DepersonilizeTests
{
    [TestClass]
    public class DepersonilizeTestClass
    {
        private List<Student> students;

        [TestInitialize]
        public void Initial()
        {
            students = new List<Student>();
            students.Add(new Student { Id = 1, LastName = "Иванов", FirstName = "Максим", FatherName = "Александрович", Phone = "+7978143568", Email = "ivanovtt@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 2, LastName = "Петров", FirstName = "Виталий", FatherName = "Викторович", Phone = "+73217895432", Email = "rrrrdf@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 3, LastName = "Маслова", FirstName = "Анжелика", FatherName = "Аркадьевна", Phone = "+79871236578", Email = "angel@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 4, LastName = "Корнилов", FirstName = "Станислав", FatherName = "Мартынович", Phone = "+72589631485", Email = "stanis@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 5, LastName = "Сидоров", FirstName = "Николай", FatherName = "Николаевич", Phone = "+76541239865", Email = "sidor@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 6, LastName = "Уваров", FirstName = "Денис", FatherName = "Александрович", Phone = "+74568723689", Email = "uvar@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 7, LastName = "Спицина", FirstName = "Элеонора", FatherName = "Валеревна", Phone = "+79873218536", Email = "elspic@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 8, LastName = "Ермакова", FirstName = "Лидия", FatherName = "Анатольевна", Phone = "+76549873245", Email = "ermak@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 9, LastName = "Нестерова", FirstName = "Анна", FatherName = "Николаевна", Phone = "+77418529663", Email = "nnann@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 10, LastName = "Матвиенко", FirstName = "Максим", FatherName = "Всеволодович", Phone = "+73219874598", Email = "maximvs@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 11, LastName = "Рзаева", FirstName = "Агата", FatherName = "Тимофеевна", Phone = "+77412589635", Email = "agata@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 12, LastName = "Матвеева", FirstName = "Виктория", FatherName = "Варламовна", Phone = "+74563218965", Email = "vikka@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 13, LastName = "Фадеева", FirstName = "Алла", FatherName = "Всеволодовна", Phone = "+76512789625", Email = "alla@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 14, LastName = "Селиверстова", FirstName = "Евпраксия", FatherName = "Матвеевна", Phone = "+79816573245", Email = "evp@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 15, LastName = "Шарапова", FirstName = "Мария", FatherName = "Аркадьевна", Phone = "+79651482635", Email = "marry@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 16, LastName = "Константинов", FirstName = "Лукьян", FatherName = "Матвеевич", Phone = "+71458963278", Email = "luka@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 17, LastName = "Карпов", FirstName = "Лаврентий", FatherName = "Даниилович", Phone = "+72589631474", Email = "lavr@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 18, LastName = "Кулагин", FirstName = "Алексей", FatherName = "Вадимович", Phone = "+74598672563", Email = "alex@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 19, LastName = "Денисов", FirstName = "Вадим", FatherName = "Викторович", Phone = "+78520120603", Email = "vadik@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 20, LastName = "Маркова", FirstName = "Полина", FatherName = "Денисовна", Phone = "+78563214957", Email = "polya@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 21, LastName = "Абрамова", FirstName = "Екатерина", FatherName = "Валентиновна", Phone = "+74589630102", Email = "kate@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 22, LastName = "Ковалёв", FirstName = "Валерьян", FatherName = "Яковович", Phone = "+78469573212", Email = "valera@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 23, LastName = "Лукина", FirstName = "Клавдия", FatherName = "Дмитрьевна", Phone = "+79781468789", Email = "klava@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 24, LastName = "Тетерин", FirstName = "Вячеслав", FatherName = "Протасьевич", Phone = "+76548523719", Email = "slavik@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 25, LastName = "Николаева", FirstName = "Варвара", FatherName = "Анатольевна", Phone = "+71520367854", Email = "varya@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
            students.Add(new Student { Id = 26, LastName = "Ефимов", FirstName = "Василий", FatherName = "Антонинович", Phone = "+75689241378", Email = "vasya@mail.ru", GenderId = Gender.Male.Id, GroupId = 1 });
            students.Add(new Student { Id = 27, LastName = "Андреева", FirstName = "Раиса", FatherName = "Георгьевна", Phone = "+78523697410", Email = "raya@mail.ru", GenderId = Gender.Female.Id, GroupId = 1 });
        }

        [TestMethod]
        public void LastNameDepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var result = dep.Depersonilized(students);
            
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 1).LastName, result.FirstOrDefault(x => x.Id == 6).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 3).LastName, result.FirstOrDefault(x => x.Id == 11).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 21).LastName, result.FirstOrDefault(x => x.Id == 21).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 10).LastName, result.FirstOrDefault(x => x.Id == 19).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 9).LastName, result.FirstOrDefault(x => x.Id == 14).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 22).LastName, result.FirstOrDefault(x => x.Id == 24).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 20).LastName, result.FirstOrDefault(x => x.Id == 9).LastName);
        }

        [TestMethod]
        public void FirstNameDepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var result = dep.Depersonilized(students);
            
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 3).FirstName, result.FirstOrDefault(x => x.Id == 9).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 9).FirstName, result.FirstOrDefault(x => x.Id == 13).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 6).FirstName, result.FirstOrDefault(x => x.Id == 17).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 2).FirstName, result.FirstOrDefault(x => x.Id == 6).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 23).FirstName, result.FirstOrDefault(x => x.Id == 21).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 24).FirstName, result.FirstOrDefault(x => x.Id == 24).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 19).FirstName, result.FirstOrDefault(x => x.Id == 4).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 15).FirstName, result.FirstOrDefault(x => x.Id == 7).FirstName);
        }

        [TestMethod]
        public void FatherNameDepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var result = dep.Depersonilized(students);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 7).FatherName, result.FirstOrDefault(x => x.Id == 13).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 10).FatherName, result.FirstOrDefault(x => x.Id == 1).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 6).FatherName, result.FirstOrDefault(x => x.Id == 19).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 2).FatherName, result.FirstOrDefault(x => x.Id == 16).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 26).FatherName, result.FirstOrDefault(x => x.Id == 24).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 25).FatherName, result.FirstOrDefault(x => x.Id == 27).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 18).FatherName, result.FirstOrDefault(x => x.Id == 5).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 14).FatherName, result.FirstOrDefault(x => x.Id == 8).FatherName);
        }

        [TestMethod]
        public void PhoneDepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var result = dep.Depersonilized(students);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 8).Phone, result.FirstOrDefault(x => x.Id == 15).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 4).Phone, result.FirstOrDefault(x => x.Id == 18).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 18).Phone, result.FirstOrDefault(x => x.Id == 6).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 14).Phone, result.FirstOrDefault(x => x.Id == 9).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 22).Phone, result.FirstOrDefault(x => x.Id == 22).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 23).Phone, result.FirstOrDefault(x => x.Id == 27).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 26).Phone, result.FirstOrDefault(x => x.Id == 26).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 21).Phone, result.FirstOrDefault(x => x.Id == 25).Phone);
        }

        [TestMethod]
        public void EmailDepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var result = dep.Depersonilized(students);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 17).Email, result.FirstOrDefault(x => x.Id == 1).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 5).Email, result.FirstOrDefault(x => x.Id == 16).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 9).Email, result.FirstOrDefault(x => x.Id == 13).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 21).Email, result.FirstOrDefault(x => x.Id == 27).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 27).Email, result.FirstOrDefault(x => x.Id == 25).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 15).Email, result.FirstOrDefault(x => x.Id == 7).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 22).Email, result.FirstOrDefault(x => x.Id == 22).Email);
        }



        [TestMethod]
        public void LastNameUndepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var depersonilized = dep.Depersonilized(students);
            var undepersonilized = dep.Undepersonilized(depersonilized);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 1).LastName, undepersonilized.FirstOrDefault(x => x.Id == 1).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 3).LastName, undepersonilized.FirstOrDefault(x => x.Id == 3).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 21).LastName, undepersonilized.FirstOrDefault(x => x.Id == 21).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 10).LastName, undepersonilized.FirstOrDefault(x => x.Id == 10).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 9).LastName, undepersonilized.FirstOrDefault(x => x.Id == 9).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 22).LastName, undepersonilized.FirstOrDefault(x => x.Id == 22).LastName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 20).LastName, undepersonilized.FirstOrDefault(x => x.Id == 20).LastName);
        }

        [TestMethod]
        public void FirstNameUndepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var depersonilized = dep.Depersonilized(students);
            var undepersonilized = dep.Undepersonilized(depersonilized);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 3).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 3).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 9).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 9).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 6).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 6).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 2).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 2).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 23).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 23).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 24).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 24).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 19).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 19).FirstName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 15).FirstName, undepersonilized.FirstOrDefault(x => x.Id == 15).FirstName);
        }

        [TestMethod]
        public void FatherNameUndepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var depersonilized = dep.Depersonilized(students);
            var undepersonilized = dep.Undepersonilized(depersonilized);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 7).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 7).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 10).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 10).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 6).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 6).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 2).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 2).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 26).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 26).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 25).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 25).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 18).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 18).FatherName);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 14).FatherName, undepersonilized.FirstOrDefault(x => x.Id == 14).FatherName);
        }

        [TestMethod]
        public void PhoneUndepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var depersonilized = dep.Depersonilized(students);
            var undepersonilized = dep.Undepersonilized(depersonilized);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 8).Phone, undepersonilized.FirstOrDefault(x => x.Id == 8).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 4).Phone, undepersonilized.FirstOrDefault(x => x.Id == 4).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 18).Phone, undepersonilized.FirstOrDefault(x => x.Id == 18).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 14).Phone, undepersonilized.FirstOrDefault(x => x.Id == 14).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 22).Phone, undepersonilized.FirstOrDefault(x => x.Id == 22).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 23).Phone, undepersonilized.FirstOrDefault(x => x.Id == 23).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 26).Phone, undepersonilized.FirstOrDefault(x => x.Id == 26).Phone);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 21).Phone, undepersonilized.FirstOrDefault(x => x.Id == 21).Phone);
        }

        [TestMethod]
        public void EmailUndepersonilizedTest()
        {
            Depersonilize dep = new Depersonilize();
            var depersonilized = dep.Depersonilized(students);
            var undepersonilized = dep.Undepersonilized(depersonilized);

            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 17).Email, undepersonilized.FirstOrDefault(x => x.Id == 17).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 5).Email, undepersonilized.FirstOrDefault(x => x.Id == 5).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 9).Email, undepersonilized.FirstOrDefault(x => x.Id == 9).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 21).Email, undepersonilized.FirstOrDefault(x => x.Id == 21).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 27).Email, undepersonilized.FirstOrDefault(x => x.Id == 27).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 15).Email, undepersonilized.FirstOrDefault(x => x.Id == 15).Email);
            Assert.AreEqual(students.FirstOrDefault(x => x.Id == 22).Email, undepersonilized.FirstOrDefault(x => x.Id == 22).Email);
        }
    }
}
