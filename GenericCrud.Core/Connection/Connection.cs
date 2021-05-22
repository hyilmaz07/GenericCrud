using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Connection
{
  public  class Connection
    {
        protected IDbConnection GetConnection
        {
            get
            {

                return new SqlConnection("Server=127.0.0.1;Database=MyDb;User Id=sa;Password=123456;");


                // return new SqlConnection("Server=192.168.1.215;Database=EczaneCan;User Id=sa;Password=kod+ekibi07;");


            }
        }
    }
}
