using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJ.DAL
{
    public abstract class GenericRepositoryBase : IGenericRepository
    {
        public abstract int Count<T>() where T : class;

        #region Get Data Set
        public abstract IQueryable<T> List<T>() where T : class;
        public abstract IEnumerable<T> FindAll<T>() where T : class;
        #endregion Get Data Set

        #region Get Record
        public abstract T Get<T>(int id) where T : class;
        public abstract T Get<T>(long id) where T : class;
        public abstract T Get<T>(string id) where T : class;
        public abstract T Get<T>(Guid id) where T : class;
        public abstract T Get<T>(decimal id) where T : class;
        public abstract T Get<T>(char id) where T : class;
        public abstract T Get<T>(double id) where T : class;

        public abstract T GetByCode<T>(int code) where T : class;
        public abstract T GetByCode<T>(long code) where T : class;
        public abstract T GetByCode<T>(string code) where T : class;
        public abstract T GetByCode<T>(Guid code) where T : class;
        public abstract T GetByCode<T>(decimal code) where T : class;
        public abstract T GetByCode<T>(char code) where T : class;
        public abstract T GetByCode<T>(double code) where T : class;

        public abstract T GetBySpecificField<T>(object value, Type type) where T : class;
        public abstract T GetBy<T>(object value, Type type) where T : class;
        #endregion Get Record

        #region Data Operation
        public abstract void Save<T>(T entityToCreate) where T : class;
        public abstract void SaveTrans<T>(T entityToCreate) where T : class;
        public abstract void Update<T>(T entityToEdit) where T : class;
        public abstract void UpdateTrans<T>(T entityToEdit) where T : class;
        public abstract void Delete<T>(T entityToDelete) where T : class;
        public abstract void DeleteTrans<T>(T entityToDelete) where T : class;
        public abstract void SubmitTrans();
        public abstract int ExecuteCommand(string sql, params object[] parameters);
        #endregion Data Operation

        #region Data Operation - Optimistic Concurrency
        public abstract void Update<T>(T entityToEdit, T entityOrigin) where T : class;
        public abstract void UpdateTrans<T>(T entityToEdit, T entityOrigin) where T : class;
        #endregion Data Operation - Optimistic Concurrency
    }
}
