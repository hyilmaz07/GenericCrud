using Dapper.Contrib.Extensions;
using GenericCrud.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCrud.Core.Repositories
{
    public class BaseRepository<T> : Connection.Connection, IGenericRepository<T> where T : class
    {
        public int Add(T entity)
        {
            try
            {
                using (var con = GetConnection)
                {
                    return (int)con.Insert(entity);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return -1;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                using (var con = GetConnection)
                {
                    Entity.AuditTracing at = new Entity.AuditTracing();
                    Type type = typeof(T);
                    at.Object = type.Name;
                    at.AuditType = Entity.AuditType.Update;
                    at.DateCreated = Convert.ToDateTime(entity.GetType().GetProperty("DateCreated").GetValue(entity));
                    at.DateModifed = Convert.ToDateTime(entity.GetType().GetProperty("DateModifed").GetValue(entity));
                    at.UserIDCreated = Convert.ToInt32(entity.GetType().GetProperty("UserIDCreated").GetValue(entity));
                    at.UserIDModified = Convert.ToInt32(entity.GetType().GetProperty("UserIDModified").GetValue(entity));
                    at.Object = entity.GetType().ToString();
                    at.ReferanceID = Convert.ToInt32(entity.GetType().GetProperty("ID").GetValue(entity));

                    T oldEntity = con.Get<T>(at.ReferanceID);
                    at.OldValue = Helper.Object.Serialize(oldEntity);
                    at.NewValue = Helper.Object.Serialize(entity);
                    int AuditID = AuditRepository.CreateAuditTracing(at);

                    entity.GetType().GetProperty("AuditID").SetValue(entity, AuditID);

                    return con.Update(entity);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }
        }
        public bool Update(T entityOld, T entityNews)
        {
            try
            {
                using (var con = GetConnection)
                {
                    Entity.AuditTracing at = new Entity.AuditTracing();
                    Type type = typeof(T);
                    at.Object = type.Name;
                    at.AuditType = Entity.AuditType.Update;
                    at.DateCreated = Convert.ToDateTime(entityNews.GetType().GetProperty("DateCreated").GetValue(entityNews));
                    at.DateModifed = Convert.ToDateTime(entityNews.GetType().GetProperty("DateModifed").GetValue(entityNews));
                    at.UserIDCreated = Convert.ToInt32(entityNews.GetType().GetProperty("UserIDCreated").GetValue(entityNews));
                    at.UserIDModified = Convert.ToInt32(entityNews.GetType().GetProperty("UserIDModified").GetValue(entityNews));
                    at.Object = entityNews.GetType().ToString();
                    at.ReferanceID = Convert.ToInt32(entityNews.GetType().GetProperty("ID").GetValue(entityNews));

                    at.OldValue = Helper.Object.Serialize(entityOld);
                    at.NewValue = Helper.Object.Serialize(entityNews);
                    int AuditID = AuditRepository.CreateAuditTracing(at);

                    entityNews.GetType().GetProperty("AuditID").SetValue(entityNews, AuditID);
                    return con.Update(entityNews);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }
        }
        public T Get(int ID)
        {
            try
            {
                using (var con = GetConnection)
                {
                    return con.Get<T>(ID);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                using (var con = GetConnection)
                {
                    return con.GetAll<T>();
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return null;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                using (var con = GetConnection)
                {
                    entity.GetType().GetProperty("IsActive").SetValue(entity, false);
                    return con.Update(entity);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }
        }

        public bool Delete(int ID)
        {
            try
            {
                using (var con = GetConnection)
                {
                    T entity = con.Get<T>(ID);
                    entity.GetType().GetProperty("IsActive").SetValue(entity, false);
                    return con.Update(entity);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }

        }

        public bool DeleteAll()
        {
            try
            {
                using (var con = GetConnection)
                {
                    IEnumerable<T> entities = con.GetAll<T>();
                    foreach (T entity in entities)
                    {
                        entity.GetType().GetProperty("IsActive").SetValue(entity, false);
                    }
                    return con.Update(entities);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }
        }



        public bool Remove(T entity)
        {
            try
            {
                using (var con = GetConnection)
                {
                    entity.GetType().GetProperty("IsActive").SetValue(entity, false);
                    return con.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }
        }

        public bool Remove(int ID)
        {
            try
            {
                using (var con = GetConnection)
                {
                    T entity = con.Get<T>(ID);
                    return con.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }
        }

        public bool RemoveAll()
        {
            try
            {
                using (var con = GetConnection)
                {
                    return con.DeleteAll<T>();
                }
            }
            catch (Exception ex)
            {
                LogRepository.CreateLog(ex);
                return false;
            }
        }

    }
}
