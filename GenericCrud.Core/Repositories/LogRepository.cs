using Dapper.Contrib.Extensions;
using GenericCrud.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Repositories
{
    public class LogRepository : Connection.Connection
    {
        public int Insert(Logs model)
        {
            try
            {
                using (var con = GetConnection)
                {
                    return int.Parse(con.Insert(model).ToString());
                }
            }
            catch
            {
                return 0;
            }
        }

        public static void CreateLog(Exception ex)
        {
            try
            {
                var st = new StackTrace(ex, true);
                if (st != null)
                {
                    st.GetFrames().Where(k => k.GetFileLineNumber() > 0).ToList().ForEach(k =>
                    {
                        new LogRepository().Insert(new Logs()
                        {
                            CreatedDate = DateTime.Now,
                            Message = ex.Message,
                            Source = ex.Source + " | " + k,
                            Line = k.GetFileLineNumber()
                        });
                    });
                }
                else
                {
                    new LogRepository().Insert(new Logs()
                    {
                        CreatedDate = DateTime.Now,
                        Message = ex.Message,
                        Source = ex.Source,
                        Line = 0
                    });
                }
            }
            catch (Exception exception)
            {
                new LogRepository().Insert(new Logs()
                {
                    CreatedDate = DateTime.Now,
                    Message = exception.Message,
                    Source = exception.Source + " - CreateLogta Sorun var.",
                    Line = 0
                });
            }
        }
    }
}
