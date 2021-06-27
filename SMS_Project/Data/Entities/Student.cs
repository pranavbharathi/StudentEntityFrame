using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace SMS_Project.Data.Entities
{
    public class Student
    {
        public Student()
        {
            Teachers = new HashSet<Teacher>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Hobby { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int? StudentAccountId { get; set; }
        public int CourseId { get; set; }
        //public int ClassId { get; set; }


        public virtual StudentAccount StudentAccount { get; set; }
        public virtual ICollection<Teacher> Teachers{ get; set; }
        public virtual Course Course { get; set; }
        
    }
    public class StudentConfig : EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            Property(e => e.Name).HasMaxLength(30);
            HasOptional(e => e.StudentAccount).WithRequired(e => e.Student);
        }
    }
}
