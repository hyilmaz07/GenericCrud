using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Entity
{
    [Table("Logs")]
   public class Logs
    {
        [Key]
        public int ID { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public int? Line { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
