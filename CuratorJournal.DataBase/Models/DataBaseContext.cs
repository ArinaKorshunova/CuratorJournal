using System.ComponentModel.Composition;
using System.Data.Entity;
using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Models
{
    [Export(typeof(DbContext))]
    [Export(typeof(DataBaseContext))]
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("Curator")
        {
            // http://stackoverflow.com/a/12190182
            typeof(Database).GetMethod("SetInitializer").MakeGenericMethod(GetType()).Invoke(null, new object[] { null });

            Configuration.AutoDetectChangesEnabled = false;
            EnumWork.AttachRussianEnums(this);
        }
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentDirection> DepartmentDirections { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Habitation> Habitations { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentHabitation> StudentHabitations { get; set; }
        public DbSet<StudentInformation> StudentInformations { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasRequired(x => x.Сurator).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>().HasRequired(x => x.Department).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserRole>().HasRequired(x => x.User).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserRole>().HasRequired(x => x.Role).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Person>().HasOptional(x => x.Department).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<StudentHabitation>().HasRequired(x => x.Student).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<StudentInformation>().HasRequired(x => x.Student).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>().HasRequired(x => x.Gender).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Student>().HasRequired(x => x.Group).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<StudentSubject>().HasRequired(x => x.Student).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<StudentSubject>().HasRequired(x => x.Subject).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<StudentSubject>().HasRequired(x => x.Teacher).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<StudentSubject>().HasRequired(x => x.Semester).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<DepartmentDirection>().HasRequired(x => x.Qualification).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<DepartmentDirection>().HasRequired(x => x.Direction).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<DepartmentDirection>().HasRequired(x => x.Department).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>().Property(x => x.MainDepartmentId).IsOptional();
        }
        
        public void DetectAndSaveChanges()
        {
            ChangeTracker.DetectChanges();
            SaveChanges();
        }

    }
}
