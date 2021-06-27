using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace SMS_Project.Data.Entities
{
    public class StudentAccount
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
       public int Amount { get; set; }
         public virtual Student Student { get; set; }
    }
    public class StudentAccountConfiguration : EntityTypeConfiguration<StudentAccount>
    {
        public StudentAccountConfiguration()
        {
            HasKey(e => e.StudentId);
        }
    }
}
