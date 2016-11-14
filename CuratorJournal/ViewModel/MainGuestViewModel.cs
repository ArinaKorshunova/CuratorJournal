using CuratorJournal.DataBase.Models;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.ViewModel
{
    public class MainGuestViewModel : Page
    {
        public DataBaseContext DbContext { get; set; }

        #region Свойсва зависимости


        public List<Group> Groups
        {
            get { return (List<Group>)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }
        public static readonly DependencyProperty GroupsProperty =
            DependencyProperty.Register("Groups", typeof(List<Group>), typeof(MainGuestViewModel), new PropertyMetadata(null));

        

        public Group SelectedGroup
        {
            get { return (Group)GetValue(SelectedGroupProperty); }
            set { SetValue(SelectedGroupProperty, value); }
        }
        public static readonly DependencyProperty SelectedGroupProperty =
            DependencyProperty.Register("SelectedGroup", typeof(Group), typeof(MainGuestViewModel), new PropertyMetadata(null));




        public Department Department
        {
            get { return (Department)GetValue(DepartmentProperty); }
            set { SetValue(DepartmentProperty, value); }
        }
        public static readonly DependencyProperty DepartmentProperty =
            DependencyProperty.Register("Department", typeof(Department), typeof(MainGuestViewModel), new PropertyMetadata(null));

        
        public List<Student> Students
        {
            get { return (List<Student>)GetValue(StudentsProperty); }
            set { SetValue(StudentsProperty, value); }
        }
        public static readonly DependencyProperty StudentsProperty =
            DependencyProperty.Register("Students", typeof(List<Student>), typeof(MainGuestViewModel), new PropertyMetadata(null));

        
        public DelegateCommand SelectedGroupCommand
        {
            get { return (DelegateCommand)GetValue(SelectedGroupCommandProperty); }
            set { SetValue(SelectedGroupCommandProperty, value); }
        }
        public static readonly DependencyProperty SelectedGroupCommandProperty =
            DependencyProperty.Register("SelectedGroupCommand", typeof(DelegateCommand), typeof(MainGuestViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public MainGuestViewModel()
        {
            DbContext = new DataBaseContext();
            var currentUserLogin = Properties.Settings.Default.UserName;

            Department = DbContext.Persons.FirstOrDefault(x => x.User.Login == currentUserLogin).Department;
            
            int comparingYear = GetCompareYear();
            Groups = DbContext.Groups.Where(x => x.DepartmentId == Department.Id && x.Year == comparingYear).ToList();
            SelectedGroupCommand = new DelegateCommand(SelectGroup);
        }

        #endregion

        #region Методы

        private int GetCompareYear()
        {
            if(DateTime.Now.Month > 8)
            {
                return DateTime.Now.Year;
            }
            else { return DateTime.Now.Year - 1; }
        }


        private void SelectGroup() {
            if(SelectedGroup != null)
            {
                Students = DbContext.Students.Where(x => x.GroupId == SelectedGroup.Id).ToList();
            }
        }
        #endregion
    }
}
