using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Project.Data.Entities
{
   public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Fees { get; set; }
       
  
        public virtual ICollection<Student> Students { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasKey(e => e.TeacherId);
        }
    }
}
