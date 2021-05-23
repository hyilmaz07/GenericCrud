using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Entity
{
    [Table("AuditTracing")]
    public class AuditTracing : BaseEntity
    {
        public string Object { get; set; }
        public int ReferanceID { get; set; }
        public AuditType AuditType { get; set; } 
        public string OldValue { get; set; } 
        public string NewValue { get; set; }
    }
    public enum AuditType
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        Remove = 4
    }
}
