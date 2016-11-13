using CuratorJournal.DataBase.Models;
using CuratorJournal.View;
using Microsoft.Practices.Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.ViewModel
{
    public class AdministratorMainPageViewModel : Page
    {
        public DataBaseContext DbContext { get; set; }

        #region Свойства зависиости

        public List<Department> HeadDepartments
        {
            get { return (List<Department>)GetValue(HeadDepartmentsProperty); }
            set { SetValue(HeadDepartmentsProperty, value); }
        }
        public static readonly DependencyProperty HeadDepartmentsProperty =
            DependencyProperty.Register("HeadDepartments", typeof(List<Department>), typeof(AdministratorMainPageViewModel), new PropertyMetadata(null));

        
        public Department SelectedDepartment
        {
            get { return (Department)GetValue(SelectedHeadDepartmentProperty); }
            set { SetValue(SelectedHeadDepartmentProperty, value); }
        }

        public static readonly DependencyProperty SelectedHeadDepartmentProperty =
            DependencyProperty.Register("SelectedHeadDepartment", typeof(Department), typeof(AdministratorMainPageViewModel), new PropertyMetadata(null));

        
        public DelegateCommand ShowSelectedDepartmentDetailsCommand
        {
            get { return (DelegateCommand)GetValue(ShowSelectedDepartmentDetailsCommandProperty); }
            set { SetValue(ShowSelectedDepartmentDetailsCommandProperty, value); }
        }
        public static readonly DependencyProperty ShowSelectedDepartmentDetailsCommandProperty =
            DependencyProperty.Register("ShowSelectedDepartmentDetailsCommand", typeof(DelegateCommand), typeof(AdministratorMainPageViewModel), new PropertyMetadata(null));

        
        public object SelectedViewModel
        {
            get { return (object)GetValue(SelectedViewModelProperty); }
            set { SetValue(SelectedViewModelProperty, value); }
        }
        public static readonly DependencyProperty SelectedViewModelProperty =
            DependencyProperty.Register("SelectedViewModel", typeof(object), typeof(AdministratorMainPageViewModel), new PropertyMetadata(null));

        
        public DelegateCommand EditDepartmentCommand
        {
            get { return (DelegateCommand)GetValue(EditDepartmentCommandProperty); }
            set { SetValue(EditDepartmentCommandProperty, value); }
        }
        public static readonly DependencyProperty EditDepartmentCommandProperty =
            DependencyProperty.Register("EditDepartmentCommand", typeof(DelegateCommand), typeof(AdministratorMainPageViewModel), new PropertyMetadata(null));


        public bool IsEditEnable
        {
            get { return (bool)GetValue(IsEditEnableProperty); }
            set { SetValue(IsEditEnableProperty, value); }
        }

        public static readonly DependencyProperty IsEditEnableProperty =
            DependencyProperty.Register("IsEditEnable", typeof(bool), typeof(AdministratorMainPageViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public AdministratorMainPageViewModel()
        {
            DbContext = new DataBaseContext();

            HeadDepartments = DbContext.Departments.Where(x => x.MainDepartmentId == null).ToList();
            ShowSelectedDepartmentDetailsCommand = new DelegateCommand(ShowSelectedDepartmentDetails);
            EditDepartmentCommand = new DelegateCommand(EditDepartment);
            IsEditEnable = false;
        }

        #endregion

        #region Методы 

        private void ShowSelectedDepartmentDetails()
        {
            if (SelectedDepartment != null)
            {
                IsEditEnable = true;
                if (SelectedDepartment.MainDepartmentId == null)
                {
                    MainDepartmentDetails details = new MainDepartmentDetails();
                    details.DataContext = new MainDepartmentViewModel(SelectedDepartment.Id, this);
                    SelectedViewModel = details;
                }
                else
                {
                    ChildDepartmentDetails details = new ChildDepartmentDetails();
                    details.DataContext = new ChildDepartmentViewModel(SelectedDepartment.Id, this);
                    SelectedViewModel = details;
                }
            }
            else
            {
                IsEditEnable = false;
            }
        }

        private void EditDepartment()
        {
            EditMainDepartment details = new EditMainDepartment();
            details.DataContext = new EditMainDepartmentViewModel(SelectedDepartment.Id, this);
            SelectedViewModel = details;
        }

        #endregion
    }
}
