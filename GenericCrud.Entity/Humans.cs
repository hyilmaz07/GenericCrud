using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Entity
{
    public class Humans : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string MobilePhone { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
