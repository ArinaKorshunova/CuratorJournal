using CuratorJournal.DataBase.Models;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.ViewModel
{
    public class EditMainDepartmentViewModel : UserControl
    {
        public DataBaseContext DbContext { get; set; }

        #region Свойства зависимости

        public Department HeadDepartment
        {
            get { return (Department)GetValue(HeadDepartmentProperty); }
            set { SetValue(HeadDepartmentProperty, value); }
        }
        public static readonly DependencyProperty HeadDepartmentProperty =
            DependencyProperty.Register("HeadDepartment", typeof(Department), typeof(EditMainDepartmentViewModel), new PropertyMetadata(null));


        public AdministratorMainPageViewModel AdmininstratorVM
        {
            get { return (AdministratorMainPageViewModel)GetValue(AdmininstratorVMProperty); }
            set { SetValue(AdmininstratorVMProperty, value); }
        }
        public static readonly DependencyProperty AdmininstratorVMProperty =
            DependencyProperty.Register("AdmininstratorVM", typeof(AdministratorMainPageViewModel), typeof(EditMainDepartmentViewModel), new PropertyMetadata(null));

        
        public List<Person> Persons
        {
            get { return (List<Person>)GetValue(PersonsProperty); }
            set { SetValue(PersonsProperty, value); }
        }
        public static readonly DependencyProperty PersonsProperty =
            DependencyProperty.Register("Persons", typeof(List<Person>), typeof(EditMainDepartmentViewModel), new PropertyMetadata(null));


        public Person SelectedDean
        {
            get { return (Person)GetValue(SelectedDeanProperty); }
            set { SetValue(SelectedDeanProperty, value); }
        }
        public static readonly DependencyProperty SelectedDeanProperty =
            DependencyProperty.Register("SelectedDean", typeof(Person), typeof(EditMainDepartmentViewModel), new PropertyMetadata(null));

        
        public string DeanSearchString
        {
            get { return (string)GetValue(DeanSearchStringProperty); }
            set { SetValue(DeanSearchStringProperty, value); }
        }
        public static readonly DependencyProperty DeanSearchStringProperty =
            DependencyProperty.Register("DeanSearchString", typeof(string), typeof(EditMainDepartmentViewModel), new PropertyMetadata(null));

        
        public DelegateCommand DeanSearchStringChangedCommand
        {
            get { return (DelegateCommand)GetValue(DeanSearchStringChangedCommandProperty); }
            set { SetValue(DeanSearchStringChangedCommandProperty, value); }
        }
        public static readonly DependencyProperty DeanSearchStringChangedCommandProperty =
            DependencyProperty.Register("DeanSearchStringChangedCommand", typeof(DelegateCommand), typeof(EditMainDepartmentViewModel), new PropertyMetadata(null));



        public DelegateCommand AddDeanCommand
        {
            get { return (DelegateCommand)GetValue(AddDeanCommandProperty); }
            set { SetValue(AddDeanCommandProperty, value); }
        }
        public static readonly DependencyProperty AddDeanCommandProperty =
            DependencyProperty.Register("AddDeanCommand", typeof(DelegateCommand), typeof(EditMainDepartmentViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public EditMainDepartmentViewModel(long? id, AdministratorMainPageViewModel adminVM)
        {
            DbContext = new DataBaseContext();
            HeadDepartment = DbContext.Departments.Find(id);
            Persons = DbContext.Persons.ToList();
            //DeanSearchStringChangedCommand = new DelegateCommand(DeanSearchStringChanged);
            AddDeanCommand = new DelegateCommand(AddDean);
        }

        #endregion

        #region Методы

        private void AddDean()
        {

        }

        //private void DeanSearchStringChanged()
        //{
        //    //if (!String.IsNullOrEmpty(DeanSearchString) && DeanSearchString.Length > 3)
        //    //{
        //    //    //Persons = DbContext.Database.SqlQuery<Person>("FindPersonByNameAndRank", new { NameAndRank = DeanSearchString}).ToList();
        //    //}
        //}

        #endregion
    }
}
