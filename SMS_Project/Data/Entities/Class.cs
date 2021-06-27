using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_Project.Data.Entities;
namespace SMS_Project.Data.Entities
{
    public class Class
    {
        public Class()
        {
            Sections = new HashSet<Section>();
            //Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Strenght { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
       //public virtual ICollection<Student> Students { get; set; }

    }
    public class ClassConfig : EntityTypeConfiguration<Class>
    {
        public ClassConfig()
        {
            //This is only for showing that EF6 does a delete cascade by default, 
            //we can prevent it as below

            HasRequired(e => e.Teacher).WithMany(e =>e.Classes).WillCascadeOnDelete(false);
        }
    }
}
