using CuratorJournal.DataBase.Models;
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


        
        public Department SelectedHeadDepartment
        {
            get { return (Department)GetValue(SelectedHeadDepartmentProperty); }
            set { SetValue(SelectedHeadDepartmentProperty, value); }
        }

        public static readonly DependencyProperty SelectedHeadDepartmentProperty =
            DependencyProperty.Register("SelectedHeadDepartment", typeof(Department), typeof(AdministratorMainPageViewModel), new PropertyMetadata(null));


        #endregion

        #region Конструкторы

        public AdministratorMainPageViewModel()
        {
            DbContext = new DataBaseContext();

            HeadDepartments = DbContext.Departments.Where(x => x.HeadDepartmentId == null).ToList();
        }

        #endregion
    }
}
