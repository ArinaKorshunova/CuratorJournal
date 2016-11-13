using CuratorJournal.DataBase.Models;
using CuratorJournal.NavigationHelper;
using CuratorJournal.View;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.ViewModel
{
    public class MainDepartmentViewModel : UserControl
    {
        public DataBaseContext DbContext { get; set; }

        #region Свойства зависимости

        public Department HeadDepartment
        {
            get { return (Department)GetValue(HeadDepartmentProperty); }
            set { SetValue(HeadDepartmentProperty, value); }
        }
        public static readonly DependencyProperty HeadDepartmentProperty =
            DependencyProperty.Register("HeadDepartment", typeof(Department), typeof(MainDepartmentViewModel), new PropertyMetadata(null));



        public DelegateCommand<long?> GoToDepartmentCommand  
        {
            get { return (DelegateCommand<long?>)GetValue(GoToDepartmentCommandProperty); }
            set { SetValue(GoToDepartmentCommandProperty, value); }
        }
        public static readonly DependencyProperty GoToDepartmentCommandProperty =
            DependencyProperty.Register("GoToDepartmentCommand", typeof(DelegateCommand<long?>), typeof(MainDepartmentViewModel), new PropertyMetadata(null));

        
        public AdministratorMainPageViewModel AdmininstratorVM
        {
            get { return (AdministratorMainPageViewModel)GetValue(AdmininstratorVMProperty); }
            set { SetValue(AdmininstratorVMProperty, value); }
        }
        public static readonly DependencyProperty AdmininstratorVMProperty =
            DependencyProperty.Register("AdmininstratorVM", typeof(AdministratorMainPageViewModel), typeof(MainDepartmentViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public MainDepartmentViewModel(long id, AdministratorMainPageViewModel adminVM)
        {
            DbContext = new DataBaseContext();
            AdmininstratorVM = adminVM;
            HeadDepartment = DbContext.Departments.Find(id);
            GoToDepartmentCommand = new DelegateCommand<long?>(GoToDepartment);
        }

        public MainDepartmentViewModel()
        {
            DbContext = new DataBaseContext();
        }

        #endregion

        #region Методы 

        private void GoToDepartment(long? id)
        {
            ChildDepartmentDetails child = new ChildDepartmentDetails();
            child.DataContext = new ChildDepartmentViewModel(id, AdmininstratorVM);

            AdmininstratorVM.SelectedViewModel = child;
        }

        #endregion
    }
}
