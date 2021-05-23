using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Entity
{
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public int? UserIDCreated { get; set; }
        public int? UserIDModified { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModifed { get; set; }
        public int? AuditID { get; set; }
    }
}
