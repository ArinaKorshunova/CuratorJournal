using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CuratorJournal.DataBase.Models;
using CuratorJournal.Logic.PasswordSecurity;
using CuratorJournal.NavigationHelper;
using CuratorJournal.View;
using Microsoft.Practices.Prism.Commands;

namespace CuratorJournal.ViewModel
{
    public class RegistrationViewModel : Page
    {
        public DataBaseContext DbContext { get; set; }
        #region Свойства зависимости

        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));



        public List<Department> Departments
        {
            get { return (List<Department>)GetValue(DepartmentsProperty); }
            set { SetValue(DepartmentsProperty, value); }
        }
        public static readonly DependencyProperty DepartmentsProperty =
            DependencyProperty.Register("Departments", typeof(List<Department>), typeof(RegistrationViewModel), new PropertyMetadata(null));

        
        public Department SelectedDepartment
        {
            get { return (Department)GetValue(SelectedDepartmentProperty); }
            set { SetValue(SelectedDepartmentProperty, value); }
        }
        public static readonly DependencyProperty SelectedDepartmentProperty =
            DependencyProperty.Register("SelectedDepartment", typeof(Department), typeof(RegistrationViewModel), new PropertyMetadata(null));

        
        public Person Person
        {
            get { return (Person)GetValue(PersonProperty); }
            set { SetValue(PersonProperty, value); }
        }
        public static readonly DependencyProperty PersonProperty =
            DependencyProperty.Register("Person", typeof(Person), typeof(RegistrationViewModel), new PropertyMetadata(null));

        
        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public string PasswordFirst
        {
            get { return (string)GetValue(PasswordFirstProperty); }
            set { SetValue(PasswordFirstProperty, value); }
        }
        public static readonly DependencyProperty PasswordFirstProperty =
            DependencyProperty.Register("PasswordFirst", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public string PasswordSecond
        {
            get { return (string)GetValue(PasswordSecondProperty); }
            set { SetValue(PasswordSecondProperty, value); }
        }
        public static readonly DependencyProperty PasswordSecondProperty =
            DependencyProperty.Register("PasswordSecond", typeof(string), typeof(RegistrationViewModel), new PropertyMetadata(null));

        
        public DelegateCommand OkCommand
        {
            get { return (DelegateCommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }
        public static readonly DependencyProperty OkCommandProperty =
            DependencyProperty.Register("OkCommand", typeof(DelegateCommand), typeof(RegistrationViewModel), new PropertyMetadata(null));


        public DelegateCommand CancelCommand
        {
            get { return (DelegateCommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(DelegateCommand), typeof(RegistrationViewModel), new PropertyMetadata(null));


        #endregion

        #region Конструкторы

        public RegistrationViewModel()
        {
            DbContext = new DataBaseContext();
            Departments = DbContext.Departments.Where(x => x.MainDepartmentId != null).OrderBy(x => x.Code).ToList();
            Person = new Person();
            OkCommand = new DelegateCommand(Register);
            CancelCommand = new DelegateCommand(Cancel);
        }

        #endregion

        #region Методы

        private void Register()
        {
            if (!String.IsNullOrEmpty(Person.FirstName) && !String.IsNullOrEmpty(Person.LastName) &&
                !String.IsNullOrEmpty(Person.Rank) &&
                !String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(PasswordFirst) &&
                !String.IsNullOrEmpty(PasswordSecond) && SelectedDepartment != null)
            {
                if (!Security.Verify(PasswordSecond, PasswordFirst))
                {
                    ErrorMessage = "Пароли не совпадают!";
                    return;
                }

                if (DbContext.Users.Any(x => x.Login == Login))
                {
                    ErrorMessage = "Пользователь с таким логином уже существует";
                    return;
                }
                try
                {
                    using (var dbContextTransaction = DbContext.Database.BeginTransaction())
                    {
                        User newUser = new User
                        {
                            Login = Login,
                            Password = PasswordFirst
                        };
                        DbContext.Users.Add(newUser);
                        DbContext.DetectAndSaveChanges();
                        User currentUser = DbContext.Users.First(x => x.Login == Login);

                        UserRole newUserRole = new UserRole
                        {
                            RoleId = Role.Guest.Id,
                            UserId = currentUser.Id
                        };
                        DbContext.UserRoles.Add(newUserRole);

                        Person.DepartmentId = SelectedDepartment.Id;
                        Person.UsereId = currentUser.Id;
                        DbContext.Persons.Add(Person);
                        DbContext.DetectAndSaveChanges();

                        dbContextTransaction.Commit();
                    }
                    
                    Navigation.NavigateTo(new RedirectMessage(), new RedirectMessageViewModel("Регистрация прошла успешно", 1000,
                        new Autorization()));
                }
                catch (Exception ex)
                {
                    ErrorMessage = string.Format("При выполнении операции возникла следующая ошибка: {0}", ex.Message);
                    return;
                }

            }
            else
            {
                ErrorMessage = "Заполнены не все обязательные поля!";
            }
        }

        private void Cancel()
        {
            Navigation.NavigateTo(new Autorization());
        }
        #endregion

    }
}
