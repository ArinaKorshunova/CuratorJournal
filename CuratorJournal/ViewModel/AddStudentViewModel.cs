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
    public class AddStudentViewModel : Page
    {
        public DataBaseContext DbContext { get; set; }
        public long DepartmentId { get; set; }

        #region Свойства зависимости





        public Student Student
        {
            get { return (Student)GetValue(StudentProperty); }
            set { SetValue(StudentProperty, value); }
        }
        
        public static readonly DependencyProperty StudentProperty =
            DependencyProperty.Register("Student", typeof(Student), typeof(AddStudentViewModel), new PropertyMetadata(null));



        public DelegateCommand SaveCommand
        {
            get { return (DelegateCommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }
        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(DelegateCommand), typeof(AddStudentViewModel), new PropertyMetadata(null));



        public DelegateCommand CancelCommand
        {
            get { return (DelegateCommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(DelegateCommand), typeof(AddStudentViewModel), new PropertyMetadata(null));
        

        public bool? IsMale
        {
            get { return (bool?)GetValue(IsMaleProperty); }
            set { SetValue(IsMaleProperty, value); }
        }
        public static readonly DependencyProperty IsMaleProperty =
            DependencyProperty.Register("IsMale", typeof(bool?), typeof(AddStudentViewModel), new PropertyMetadata(null));



        public List<Habitation> Habitations
        {
            get { return (List<Habitation>)GetValue(HabitationsProperty); }
            set { SetValue(HabitationsProperty, value); }
        }
        
        public static readonly DependencyProperty HabitationsProperty =
            DependencyProperty.Register("Habitations", typeof(List<Habitation>), typeof(AddStudentViewModel), new PropertyMetadata(null));




        public List<Information> Informations
        {
            get { return (List<Information>)GetValue(InformationsProperty); }
            set { SetValue(InformationsProperty, value); }
        }
        public static readonly DependencyProperty InformationsProperty =
            DependencyProperty.Register("Informations", typeof(List<Information>), typeof(AddStudentViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public AddStudentViewModel()
        {
            Initial();
            Student = new Student();
            IsMale = true;
        }
        
        public AddStudentViewModel(long id, long departmentId)
        {
            Initial();
            Student = DbContext.Students.Find(id);
            if(Student != null)
            {
                IsMale = Student.Gender.Is(Gender.Male);
                
                foreach(var hab in Habitations)
                {
                    if (DbContext.StudentHabitations.Any(x => x.StudentId == Student.Id && x.HabitationId == hab.Id)) {
                        hab.IsChecked = true;
                    }
                }
                foreach (var inf in Informations)
                {
                    if (DbContext.StudentInformations.Any(x => x.StudentId == Student.Id && x.InformationId == inf.Id))
                    {
                        inf.IsChecked = true;
                    }
                }
            }
        }

        public AddStudentViewModel(long departmentId)
        {
            Initial();
            Student = new Student();
        }
        
        #endregion

        #region Методы

        private void Initial()
        {
            DbContext = new DataBaseContext();
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            Habitations = Habitation.GetHabitations();
            Informations = Information.GetInformations();
        }

        private void Save() {
            if(Student != null)
            {
                if(Student.Id == 0)
                {

                }
            }
        }
        private void Cancel()
        {

        }

        #endregion
    }
}
