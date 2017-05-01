using CuratorJournal.DataBase.Models;
using CuratorJournal.Logic.EnumWork;
using DepersonilizeData;
using Microsoft.Office.Interop.Word;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CuratorJournal.ViewModel
{
    public class MainTeacherCuratorViewModel : System.Windows.Controls.Page
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



        public Visibility IsImportExporvVisible
        {
            get { return (Visibility)GetValue(IsImportExporvVisibleProperty); }
            set { SetValue(IsImportExporvVisibleProperty, value); }
        }
        public static readonly DependencyProperty IsImportExporvVisibleProperty =
            DependencyProperty.Register("IsImportExporvVisible", typeof(Visibility), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));




        public DelegateCommand ExportCommand
        {
            get { return (DelegateCommand)GetValue(ExportCommandProperty); }
            set { SetValue(ExportCommandProperty, value); }
        }
        public static readonly DependencyProperty ExportCommandProperty =
            DependencyProperty.Register("ExportCommand", typeof(DelegateCommand), typeof(MainTeacherCuratorViewModel), new PropertyMetadata(null));


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
            ExportCommand = new DelegateCommand(Export);
            AddStudentVM = new AddStudentViewModel();
            StudentVisible = Visibility.Hidden;
            IsImportExporvVisible = Visibility.Hidden;
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
                    IsImportExporvVisible = Visibility.Visible;
                }
                else
                {
                    IsAddStudentEnable = false;
                    IsImportExporvVisible = Visibility.Hidden;
                }
                AddStudentVM = new AddStudentViewModel();
                StudentVisible = Visibility.Hidden;
                SelectedStudent = null;
                
                Depersonilize dep = new Depersonilize();
                Students = dep.Undepersonilized(DbContext.Students.ToList()).Where(x => x.GroupId == SelectedGroup.Id).ToList();
            }
        }
        private void SelectStudent() {
            if (SelectedStudent != null)
            {
                AddStudentVM = new AddStudentViewModel(SelectedStudent.Id, Department.Id, IsAddStudentEnable);
                StudentVisible = Visibility.Visible;
            }
        }

        private void Export()
        {
            Past(Students);
        }

        public void Past(List<Student> students)
        {
            Microsoft.Office.Interop.Word.Application applicationWord = new Microsoft.Office.Interop.Word.Application();
            applicationWord.Visible = false;
            Document document = new Document();
            object missing = Missing.Value;
            object readOnly = false;
            object isVisible = true;
            object fileName = PrepeareFilePath();

            int[] tableNumbers = new int[] { 2, 9, 18 };

            try
            {
                document = applicationWord.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                document.Activate();
            }
            catch (Exception eccezione)
            {
                MessageBox.Show(eccezione.Message);
                document.Application.Quit(ref missing, ref missing, ref missing);
            }


            int startRow = 2;
            int columIndex = 2;

            try
            {
                for (int i = 0; i < tableNumbers.Length; i++)
                {
                    if (tableNumbers[i] >= document.Tables.Count)
                        throw new Exception("Индекс таблицы {0} превышает число таблиц");

                    Table table = document.Tables[tableNumbers[i]];
                    var currentRow = startRow;

                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        try
                        {
                            var cell = table.Cell(j + currentRow, columIndex);

                            cell.Range.Text = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            j--;
                            currentRow++;
                        }
                    }

                    for (int j = 0; j < students.Count(); j++)
                    {
                        if (j + currentRow >= table.Rows.Count)
                            table.Rows.Add(table.Rows.Last);

                        try
                        {
                            table.Cell(j + currentRow, columIndex).Range.Text = students[j].FIO;
                            if(tableNumbers[i] == 2)
                            {
                                table.Cell(j + currentRow, 3).Range.Text = string.Format("{0}, {1}",students[j].Phone, students[j].Email);
                            }
                        }
                        catch (Exception ex)
                        {
                            j--;
                            currentRow++;
                        }
                    }
                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "doc files (*.doc)|*.docx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == true)
                {
                    object name = saveFileDialog1.FileName;

                    document.SaveAs(ref name,
                     ref missing, ref missing, ref missing, ref missing, ref missing,
                     ref missing, ref missing, ref missing, ref missing, ref missing,
                     ref missing, ref missing, ref missing, ref missing, ref missing);
                }
            }
            catch (Exception eccezione)
            {
                MessageBox.Show(eccezione.Message);
                document.Application.Quit(ref missing, ref missing, ref missing);
            }
        }

        private string PrepeareFilePath()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            return location.Remove(location.LastIndexOf('\\') + 1) + "Журнал куратора.doc";
        }

        private string[] GetStringForInsert(List<Student> students)
        {
            return students.Select(x => string.Format("{0} {1}", x.FIO, x.Phone)).ToArray();
        }
        #endregion
    }
}
