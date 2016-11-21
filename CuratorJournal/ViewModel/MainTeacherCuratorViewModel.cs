using CuratorJournal.DataBase.Models;
using CuratorJournal.Logic.EnumWork;
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
    public class MainTeacherCuratorViewModel : Page
    {
        public DataBaseContext DbContext { get; set; }

        public bool IsUserCuratorOfGroup { get; set; }
        #region Свойсва зависимости


        public List<Group> Groups
        {
            get { return (List<Group>)GetValue(GroupsProperty); }
            set { SetValue(GroupsProperty, value); }
        }
        public static readonly DependencyProperty GroupsProperty =
            DependencyProperty.Register("Groups", typeof(List<Group>), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));



        public Group SelectedGroup
        {
            get { return (Group)GetValue(SelectedGroupProperty); }
            set { SetValue(SelectedGroupProperty, value); }
        }
        public static readonly DependencyProperty SelectedGroupProperty =
            DependencyProperty.Register("SelectedGroup", typeof(Group), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));




        public Department Department
        {
            get { return (Department)GetValue(DepartmentProperty); }
            set { SetValue(DepartmentProperty, value); }
        }
        public static readonly DependencyProperty DepartmentProperty =
            DependencyProperty.Register("Department", typeof(Department), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));


        public List<Student> Students
        {
            get { return (List<Student>)GetValue(StudentsProperty); }
            set { SetValue(StudentsProperty, value); }
        }
        public static readonly DependencyProperty StudentsProperty =
            DependencyProperty.Register("Students", typeof(List<Student>), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));




        public Student SelectedStudent
        {
            get { return (Student)GetValue(SelectedStudentProperty); }
            set { SetValue(SelectedStudentProperty, value); }
        }
        public static readonly DependencyProperty SelectedStudentProperty =
            DependencyProperty.Register("SelectedStudent", typeof(Student), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));



        public DelegateCommand SelectedGroupCommand
        {
            get { return (DelegateCommand)GetValue(SelectedGroupCommandProperty); }
            set { SetValue(SelectedGroupCommandProperty, value); }
        }
        public static readonly DependencyProperty SelectedGroupCommandProperty =
            DependencyProperty.Register("SelectedGroupCommand", typeof(DelegateCommand), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));




        public Visibility StudentVisible
        {
            get { return (Visibility)GetValue(StudentVisibleProperty); }
            set { SetValue(StudentVisibleProperty, value); }
        }
        public static readonly DependencyProperty StudentVisibleProperty =
            DependencyProperty.Register("StudentVisible", typeof(Visibility), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));




        public DelegateCommand SelectedStudentCommand
        {
            get { return (DelegateCommand)GetValue(SelectedStudentCommandProperty); }
            set { SetValue(SelectedStudentCommandProperty, value); }
        }
        public static readonly DependencyProperty SelectedStudentCommandProperty =
            DependencyProperty.Register("SelectedStudentCommand", typeof(DelegateCommand), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));




        public AddStudentViewModel AddStudentVM
        {
            get { return (AddStudentViewModel)GetValue(AddStudentVMProperty); }
            set { SetValue(AddStudentVMProperty, value); }
        }
        public static readonly DependencyProperty AddStudentVMProperty =
            DependencyProperty.Register("AddStudentVM", typeof(AddStudentViewModel), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));



        public bool IsAddStudentEnable
        {
            get { return (bool)GetValue(IsAddStudentEnableProperty); }
            set { SetValue(IsAddStudentEnableProperty, value); }
        }
        public static readonly DependencyProperty IsAddStudentEnableProperty =
            DependencyProperty.Register("IsAddStudentEnable", typeof(bool), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public MainTeacherCuratorViewModel()
        {
            DbContext = new DataBaseContext();
            var currentUserLogin = Properties.Settings.Default.UserName;

            Department = DbContext.Persons.FirstOrDefault(x => x.User.Login == currentUserLogin).Department;

            int comparingYear = GetCompareYear();
            Groups = DbContext.Groups.Where(x => x.DepartmentId == Department.Id && x.Year == comparingYear).ToList();
            SelectedGroupCommand = new DelegateCommand(SelectGroup);
            SelectedStudentCommand = new DelegateCommand(SelectStudent);
            AddStudentVM = new AddStudentViewModel();
            StudentVisible = Visibility.Hidden;
            IsAddStudentEnable = false;
        }



        #endregion

        #region Методы

        private int GetCompareYear()
        {
            if (DateTime.Now.Month > 8)
            {
                return DateTime.Now.Year;
            }
            else { return DateTime.Now.Year - 1; }
        }


        private void SelectGroup()
        {
            if (SelectedGroup != null)
            {
                var currentPerson = DbContext.Persons.FirstOrDefault(x => x.User.Login == Properties.Settings.Default.UserName);
                if (currentPerson != null && SelectedGroup.СuratorId == currentPerson.Id)
                {
                    IsAddStudentEnable = true;
                }
                else
                {
                    IsAddStudentEnable = false;
                }
                AddStudentVM = new AddStudentViewModel();
                StudentVisible = Visibility.Hidden;
                SelectedStudent = null;
                Students = DbContext.Students.Where(x => x.GroupId == SelectedGroup.Id).ToList();
            }
        }
        private void SelectStudent() {
            if (SelectedStudent != null)
            {
                AddStudentVM = new AddStudentViewModel(SelectedStudent.Id, Department.Id, IsAddStudentEnable);
                StudentVisible = Visibility.Visible;
            }
        }
        #endregion
    }
}
