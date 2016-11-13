using CuratorJournal.DataBase.Models;
using CuratorJournal.NavigationHelper;
using CuratorJournal.View;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.ViewModel
{
    public class AddPersonViewModel : UserControl
    {
        public DataBaseContext DbContext { get; set; }
        public object BackRedirect { get; set; }

        private const string HasNotRequiredData = "Заполнены не все обязательные поля";

        #region Свойства зависимости

        public Person NewPerson
        {
            get { return (Person)GetValue(NewPersonProperty); }
            set { SetValue(NewPersonProperty, value); }
        }
        public static readonly DependencyProperty NewPersonProperty =
            DependencyProperty.Register("NewPerson", typeof(Person), typeof(AddPersonViewModel), new PropertyMetadata(null));

        
        public User NewUser
        {
            get { return (User)GetValue(NewUserProperty); }
            set { SetValue(NewUserProperty, value); }
        }
        public static readonly DependencyProperty NewUserProperty =
            DependencyProperty.Register("NewUser", typeof(User), typeof(AddPersonViewModel), new PropertyMetadata(null));



        public Visibility UserVisibility
        {
            get { return (Visibility)GetValue(UserVisibilityProperty); }
            set { SetValue(UserVisibilityProperty, value); }
        }
        public static readonly DependencyProperty UserVisibilityProperty =
            DependencyProperty.Register("UserVisibility", typeof(Visibility), typeof(AddPersonViewModel), new PropertyMetadata(null));
        

        public DelegateCommand SaveNewPersonCommand 
        {
            get { return (DelegateCommand)GetValue(SaveNewPersonCommandProperty); }
            set { SetValue(SaveNewPersonCommandProperty, value); }
        }
        public static readonly DependencyProperty SaveNewPersonCommandProperty =
            DependencyProperty.Register("SaveNewPersonCommand", typeof(DelegateCommand), typeof(AddPersonViewModel), new PropertyMetadata(null));



        public DelegateCommand CancelSavingCommand
        {
            get { return (DelegateCommand)GetValue(CancelSavingCommandProperty); }
            set { SetValue(CancelSavingCommandProperty, value); }
        }
        
        public static readonly DependencyProperty CancelSavingCommandProperty =
            DependencyProperty.Register("CancelSavingCommand", typeof(DelegateCommand), typeof(AddPersonViewModel), new PropertyMetadata(null));



        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(AddPersonViewModel), new PropertyMetadata(null));
        

        public Visibility DepartmentVisibility
        {
            get { return (Visibility)GetValue(DepartmentVisibilityProperty); }
            set { SetValue(DepartmentVisibilityProperty, value); }
        }
        public static readonly DependencyProperty DepartmentVisibilityProperty =
            DependencyProperty.Register("DepartmentVisibility", typeof(Visibility), typeof(AddPersonViewModel), new PropertyMetadata(null));



        public List<Department> Departments
        {
            get { return (List<Department>)GetValue(DepartmentsProperty); }
            set { SetValue(DepartmentsProperty, value); }
        }
        public static readonly DependencyProperty DepartmentsProperty =
            DependencyProperty.Register("Departments", typeof(List<Department>), typeof(AddPersonViewModel), new PropertyMetadata(null));



        public Department SelectedDepartment
        {
            get { return (Department)GetValue(SelectedDepartmentProperty); }
            set { SetValue(SelectedDepartmentProperty, value); }
        }
        public static readonly DependencyProperty SelectedDepartmentProperty =
            DependencyProperty.Register("SelectedDepartment", typeof(Department), typeof(AddPersonViewModel), new PropertyMetadata(null));

        


        #endregion

        #region Конструкторы

        public AddPersonViewModel()
        {
            Initialize();
        }
        public AddPersonViewModel(bool isNewUserAdded, bool isDepartmentAdded, object backRedirect)
        {
            Initialize();
            BackRedirect = backRedirect;
            UserVisibility = isNewUserAdded ? Visibility.Visible : Visibility.Hidden;
            DepartmentVisibility = isDepartmentAdded ? Visibility.Visible : Visibility.Hidden;
        }

        private void Initialize()
        {
            DbContext = new DataBaseContext();
            Departments = DbContext.Departments.Where(x => x.MainDepartmentId != null).OrderBy(x => x.Code).ToList();
            SaveNewPersonCommand = new DelegateCommand(SaveNewPerson);
            CancelSavingCommand = new DelegateCommand(CancelSaving);
        }

        #endregion

        #region Методы

        private void SaveNewPerson()
        {
            if (!String.IsNullOrEmpty(NewPerson.LastName) && !String.IsNullOrEmpty(NewPerson.FirstName)
                && !String.IsNullOrEmpty(NewPerson.MiddleName) && !String.IsNullOrEmpty(NewPerson.Rank))
            {
                if (UserVisibility == Visibility.Visible && (String.IsNullOrEmpty(NewUser.Login) || String.IsNullOrEmpty(NewUser.Password)))
                {
                    ErrorMessage = HasNotRequiredData + ". Необходимо заполнить данные пользователя!";
                    return;
                }
                if(DepartmentVisibility == Visibility.Visible && SelectedDepartment == null)
                {
                    ErrorMessage = HasNotRequiredData + ". Необходимо выбрать кафедру!";
                    return;
                }

                if(UserVisibility == Visibility.Visible)
                {
                    DbContext.Users.Add(NewUser);
                    DbContext.DetectAndSaveChanges();
                    User currentUser = DbContext.Users.First(x => x.Login == NewUser.Login);

                    UserRole newUserRole = new UserRole
                    {
                        RoleId = Role.Guest.Id,
                        UserId = currentUser.Id
                    };
                    DbContext.UserRoles.Add(newUserRole);
                    
                    NewPerson.UsereId = currentUser.Id;
                }
                if(DepartmentVisibility == Visibility.Visible)
                {
                    NewPerson.DepartmentId = SelectedDepartment.Id;
                }

                DbContext.Persons.Add(NewPerson);
                DbContext.DetectAndSaveChanges();



                Navigation.NavigateTo(new RedirectMessage(), new RedirectMessageViewModel("Данные сохранены успешно", 1000,
                    new Autorization()));
            }
            else
            {
                ErrorMessage = HasNotRequiredData;
            }
        }

        private void CancelSaving()
        {

        }

        #endregion
    }
}
