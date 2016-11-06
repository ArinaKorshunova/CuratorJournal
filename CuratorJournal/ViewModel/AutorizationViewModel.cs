using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CuratorJournal.DataBase.Models;
using CuratorJournal.View;
using Microsoft.Practices.Prism.Commands;

namespace CuratorJournal.ViewModel
{
    public class AutorizationViewModel : Page
    {
        public DataBaseContext DbContext { get; set; }
        
        #region Свойства зависимости

        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(AutorizationViewModel), new PropertyMetadata(null));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(AutorizationViewModel), new PropertyMetadata(null));



        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(AutorizationViewModel), new PropertyMetadata(null));



        public DelegateCommand LoginCommand
        {
            get { return (DelegateCommand)GetValue(LoginCommandProperty); }
            set { SetValue(LoginCommandProperty, value); }
        }

        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(DelegateCommand), typeof(AutorizationViewModel), new PropertyMetadata(null));



        public DelegateCommand RegistrationCommand
        {
            get { return (DelegateCommand)GetValue(RegistrationCommandProperty); }
            set { SetValue(RegistrationCommandProperty, value); }
        }

        public static readonly DependencyProperty RegistrationCommandProperty =
            DependencyProperty.Register("RegistrationCommand", typeof(DelegateCommand), typeof(AutorizationViewModel), new PropertyMetadata(null));

        #endregion

        #region Конструкторы
        
        public AutorizationViewModel()
        {
            DbContext = new DataBaseContext();
            LoginCommand = new DelegateCommand(LogIn);
            RegistrationCommand = new DelegateCommand(Registration);
        }

        #endregion

        #region Методы 

        private void LogIn()
        {
            if (!String.IsNullOrEmpty(Login) && !String.IsNullOrEmpty(Password))
            {
                User user = DbContext.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password);
                if (user != null)
                {
                    ErrorMessage = null;
                }
                else
                {
                    ErrorMessage = "Пользователя с таким логином или паролем не существует";
                }
            }
            else
            {
                ErrorMessage = "Для авторизации необходимо ввести логин и пароль";
            }
        }


        private void Registration()
        {
            NavigationWindow win = (NavigationWindow)Application.Current.MainWindow;
            win.Content = new Registration();
            win.Show();
        }
        #endregion
    }
}
