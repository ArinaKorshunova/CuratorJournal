using CuratorJournal.DataBase.Models;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.ViewModel
{
    public class ChildDepartmentViewModel : UserControl
    {
        public DataBaseContext DbContext { get; set; }

        #region Свойства зависимости

        public Department ChildDepartment
        {
            get { return (Department)GetValue(ChildDepartmentProperty); }
            set { SetValue(ChildDepartmentProperty, value); }
        }
        public static readonly DependencyProperty ChildDepartmentProperty =
            DependencyProperty.Register("ChildDepartment", typeof(Department), typeof(ChildDepartmentViewModel), new PropertyMetadata(null));


        public AdministratorMainPageViewModel AdmininstratorVM
        {
            get { return (AdministratorMainPageViewModel)GetValue(AdmininstratorVMProperty); }
            set { SetValue(AdmininstratorVMProperty, value); }
        }
        public static readonly DependencyProperty AdmininstratorVMProperty =
            DependencyProperty.Register("AdmininstratorVM", typeof(AdministratorMainPageViewModel), typeof(ChildDepartmentViewModel), new PropertyMetadata(null));

        #endregion

        #region Конструкторы

        public ChildDepartmentViewModel()
        {
            DbContext = new DataBaseContext();
        }
        public ChildDepartmentViewModel(long? id, AdministratorMainPageViewModel adminVM)
        {
            AdmininstratorVM = adminVM;
            DbContext = new DataBaseContext();
            if (id != null)
            {
                ChildDepartment = DbContext.Departments.Find(id);
            }
        }

        #endregion

        #region Методы 

        #endregion

    }
}
