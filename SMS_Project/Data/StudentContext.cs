using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using SMS_Project.Data.Entities;

namespace SMS_Project.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext():base("StudentDb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder Builder)
        {
            Builder.Configurations.Add(new TeacherConfig());
            Builder.Configurations.Add(new StudentConfig());
            Builder.Configurations.Add(new StudentAccountConfiguration());
            Builder.Configurations.Add(new CourseConfiguration());
            Builder.Configurations.Add(new ClassConfig());
            
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAccount> StudentAccounts { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Section> Sections { get; set; }

    }
}
