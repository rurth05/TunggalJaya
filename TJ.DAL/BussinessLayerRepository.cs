using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;


namespace TJ.DAL
{
    public class BussinessLayerRepository : GenericRepositoryBase
    {
        protected DataContext db;

        #region Constructor
        public BussinessLayerRepository()
        {
            DataAccessObject dao = new DataAccessObject();
            db = dao.DataContext;
        }

        public BussinessLayerRepository(DataContext context)
        {
            db = context;
        }
        #endregion Constructor

        #region Base Method
        private string getKeyPropertyName<T>()
        {
            MetaType type = db.Mapping.GetTable(typeof(T)).RowType;

            var temp = (from mdm in type.IdentityMembers
                        select mdm.Name).FirstOrDefault();

            return (temp != null ? temp : string.Empty);
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(int id)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(id, typeof(int));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(long id)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(id, typeof(long));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(string code)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(code, typeof(string));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(Guid code)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(code, typeof(Guid));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(decimal code)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(code, typeof(decimal));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(char code)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(code, typeof(char));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(double code)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(code, typeof(double));
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected Expression<Func<T, bool>> CreateGetExpression<T>(object value, Type type)
        {
            ParameterExpression e = Expression.Parameter(typeof(T), "e");
            PropertyInfo propInfo = typeof(T).GetProperty(getKeyPropertyName<T>());
            MemberExpression m = Expression.MakeMemberAccess(e, propInfo);
            ConstantExpression c = Expression.Constant(value, type);
            BinaryExpression b = Expression.Equal(m, c);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(b, e);
            return lambda;
        }

        protected int GetKeyPropertyValue<T>(object entity)
        {
            return (int)typeof(T).GetProperty(getKeyPropertyName<T>()).GetValue(entity, null);
        }
        #endregion Base Method


        #region Count Method
        public override int Count<T>()
        {
            return db.GetTable<T>().Count();
        }
        #endregion Count Method

        #region Get Data Set Method
        public override IQueryable<T> List<T>()
        {
            return db.GetTable<T>();
        }

        public override IEnumerable<T> FindAll<T>()
        {
            return db.GetTable<T>();
        }
        #endregion Get Data Method

        #region Get Record Method
        public override T Get<T>(int id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override T Get<T>(long id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override T Get<T>(string id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override T Get<T>(Guid id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override T Get<T>(decimal id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override T Get<T>(char id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override T Get<T>(double id)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(id));
        }

        public override T GetByCode<T>(int code)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(code));
        }

        public override T GetByCode<T>(long code)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(code));
        }

        public override T GetByCode<T>(string code)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(code));
        }

        public override T GetByCode<T>(Guid code)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(code));
        }

        public override T GetByCode<T>(decimal code)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(code));
        }

        public override T GetByCode<T>(char code)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(code));
        }

        public override T GetByCode<T>(double code)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(code));
        }

        public override T GetBySpecificField<T>(object value, Type type)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(value, type));
        }

        public override T GetBy<T>(object value, Type type)
        {
            return List<T>().FirstOrDefault(CreateGetExpression<T>(value, type));
        }
        #endregion Get Record Method
        
        #region Data Operation Method
        public override void Save<T>(T entityToCreate)
        {
            db.GetTable<T>().InsertOnSubmit(entityToCreate);
            db.SubmitChanges();
        }

        public override void SaveTrans<T>(T entityToCreate)
        {
            db.GetTable<T>().InsertOnSubmit(entityToCreate);
        }

        public override void Update<T>(T entityToEdit)
        {
            //db.GetTable<T>().Attach(entityToEdit, true);
            db.SubmitChanges();
        }

        public override void UpdateTrans<T>(T entityToEdit)
        {
            //db.GetTable<T>().Attach(entityToEdit, true);
            //db.SubmitChanges();
        }

        public override void Delete<T>(T entityToDelete)
        {
            //db.GetTable<T>().Attach(entityToDelete);
            db.GetTable<T>().DeleteOnSubmit(entityToDelete);
            db.SubmitChanges();
        }

        public override void DeleteTrans<T>(T entityToDelete)
        {
            //db.GetTable<T>().Attach(entityToDelete);
            db.GetTable<T>().DeleteOnSubmit(entityToDelete);
        }

        public override void SubmitTrans()
        {
            db.SubmitChanges();
        }

        public override int ExecuteCommand(string sql, params object[] parameters)
        {
            return db.ExecuteCommand(sql, parameters);
        }
        #endregion Data Operation Method

        #region Data Operation - Optimistic Concurrency
        public override void Update<T>(T entityToEdit, T entityOrigin)
        {
            db.GetTable<T>().Attach(entityToEdit, entityOrigin);
            db.SubmitChanges();
        }

        public override void UpdateTrans<T>(T entityToEdit, T entityOrigin)
        {
            db.GetTable<T>().Attach(entityToEdit, entityOrigin);
        }
        #endregion Data Operation - Optimistic Concurrency
    }
}
