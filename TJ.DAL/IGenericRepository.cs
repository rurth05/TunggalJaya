using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJ.DAL
{
    public interface IGenericRepository
    {
        int Count<T>() where T : class;

        #region Get Data
        IQueryable<T> List<T>() where T : class;
        IEnumerable<T> FindAll<T>() where T : class;
        #endregion Get Data

        #region Get Record
        T Get<T>(int id) where T : class;
        T Get<T>(long id) where T : class;
        T Get<T>(string id) where T : class;
        T Get<T>(Guid id) where T : class;
        T Get<T>(decimal id) where T : class;
        T Get<T>(char id) where T : class;
        T Get<T>(double id) where T : class;

        T GetByCode<T>(int code) where T : class;
        T GetByCode<T>(long code) where T : class;
        T GetByCode<T>(string code) where T : class;
        T GetByCode<T>(Guid code) where T : class;
        T GetByCode<T>(decimal code) where T : class;
        T GetByCode<T>(char code) where T : class;
        T GetByCode<T>(double code) where T : class;

        T GetBySpecificField<T>(object value, Type type) where T : class;
        T GetBy<T>(object value, Type type) where T : class;
        #endregion Get Record

        #region Data Operation
        void Save<T>(T entityToCreate) where T : class;
        void SaveTrans<T>(T entityToCreate) where T : class;
        void Update<T>(T entityToEdit) where T : class;
        void UpdateTrans<T>(T entityToEdit) where T : class;
        void Delete<T>(T entityToDelete) where T : class;
        void DeleteTrans<T>(T entityToDelete) where T : class;
        void SubmitTrans();
        int ExecuteCommand(string sql, params object[] parameters);
        #endregion Data Operation

        #region Data Operation - Optimistic Concurrency
        void Update<T>(T entityToEdit, T entityOrigin) where T : class;
        void UpdateTrans<T>(T entityToEdit, T entityOrigin) where T : class;
        #endregion Data Operation - Optimistic Concurrency
    }
}
