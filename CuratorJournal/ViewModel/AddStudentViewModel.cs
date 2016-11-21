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




        public Visibility ButtonVisibility
        {
            get { return (Visibility)GetValue(ButtonVisibilityProperty); }
            set { SetValue(ButtonVisibilityProperty, value); }
        }
        public static readonly DependencyProperty ButtonVisibilityProperty =
            DependencyProperty.Register("ButtonVisibility", typeof(Visibility), typeof(AddStudentViewModel), new PropertyMetadata(null));



        #endregion

        #region Конструкторы

        public AddStudentViewModel()
        {
            Initial();
            Student = new Student();
            IsMale = true;
        }
        
        public AddStudentViewModel(long id, long departmentId, bool isVisible)
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


            ButtonVisibility = isVisible ? Visibility.Visible : Visibility.Hidden;
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
            ButtonVisibility = Visibility.Visible;
        }

        private void Save() {
            if(Student != null)
            {
                if (!String.IsNullOrEmpty(Student.FIO) && !String.IsNullOrEmpty(Student.Phone) && !String.IsNullOrEmpty(Student.Email)
                    && IsMale != null)
                {
                    for (int i = 0; i < Student.StudentHabitations.Count; i++)
                    {
                        var hh = DbContext.StudentHabitations.Find(Student.StudentHabitations[i].Id);
                        if (hh != null)
                        {
                            DbContext.StudentHabitations.Remove(hh);
                        }
                    }

                    for (int i = 0; i < Student.StudentInformations.Count; i++)
                    {
                        var ii = DbContext.StudentInformations.Find(Student.StudentInformations[i].Id);
                        if (ii != null)
                        {
                            DbContext.StudentInformations.Remove(ii);
                        }
                    }
                    DbContext.DetectAndSaveChanges();
                    
                    var checkedHab = Habitations.Where(x => x.IsChecked).ToList();
                    foreach (var hab in checkedHab) {
                        DbContext.StudentHabitations.Add(new StudentHabitation { HabitationId = hab.Id, StudentId = Student.Id });
                        DbContext.DetectAndSaveChanges();
                    }
                    
                    var checkedInf = Informations.Where(x => x.IsChecked).ToList();
                    foreach (var inf in checkedInf)
                    {
                        DbContext.StudentInformations.Add(new StudentInformation { InformationId = inf.Id, StudentId = Student.Id });
                        DbContext.DetectAndSaveChanges();
                    }
                    Student.GenderId = (bool)IsMale ? Gender.Male.Id : Gender.Female.Id;
                    DbContext.Entry(Student).State = System.Data.Entity.EntityState.Modified;
                    
                    DbContext.DetectAndSaveChanges();
                }
                else
                {
                    MessageBox.Show("Недостаточно данных для сохранения!");
                }
            }
        }
        private void Cancel()
        {

        }

        #endregion
    }
}
