using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Project.Data.Entities
{
   public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Strength { get; set; }
        public virtual Class Class { get; set; }
    }
}
