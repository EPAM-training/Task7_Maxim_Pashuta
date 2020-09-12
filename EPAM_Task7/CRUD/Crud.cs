using EPAM_Task7.CRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EPAM_Task7.CRUD
{
    /// <summary>
    /// Class for working database.
    /// </summary>
    /// <typeparam name="T">Any class</typeparam>
    public class Crud<T> : ICrud<T> where T : class, new()
    {
        /// <summary>
        /// The method inserts an object into a database table.
        /// </summary>
        /// <param name="obj">Any object</param>
        public void Insert(T obj)
        {
            using (var dbContext = new SessionDataContext())
            {
                dbContext.GetTable<T>().InsertOnSubmit(obj);
                dbContext.SubmitChanges();
            }
        }

        /// <summary>
        /// The method updates an object that locates into a database table.
        /// </summary>
        /// <param name="id">Object id</param>
        /// <param name="obj">Object that inherits the class BaseModel</param>
        public void Update(int id, T obj)
        {
            using (var dbContext = new SessionDataContext())
            {
                // Gets properties that are table columns
                List<PropertyInfo> propertyColumns = typeof(T).GetProperties().Where(property => (!property.PropertyType.IsClass || (property.PropertyType == typeof(string))) &&
                                                                               (property.Name != "ID")).ToList();

                // Creates a custom lambda to find an object by ID.
                var itemParameter = Expression.Parameter(typeof(T), "item");
                var firstExpression = Expression.Lambda<Func<T, bool>>
                    (
                    Expression.Equal(
                        Expression.Property(
                            itemParameter,
                            "id"
                            ),
                        Expression.Constant(id)
                        ),
                    new[] { itemParameter }
                    );

                T newModel = dbContext.GetTable<T>().First(firstExpression);
                
                foreach (PropertyInfo property in propertyColumns)
                {
                    property.SetValue(newModel, property.GetValue(obj));
                }

                dbContext.SubmitChanges();
            }
        }

        /// <summary>
        /// The method deletes an object from a database table.
        /// </summary>
        /// <param name="id">Object id</param>
        public void Delete(int id)
        {
            using (var dbContext = new SessionDataContext())
            {
                // Creates a custom lambda to find an object by ID.
                var itemParameter = Expression.Parameter(typeof(T), "item");
                var firstExpression = Expression.Lambda<Func<T, bool>>
                    (
                    Expression.Equal(
                        Expression.Property(
                            itemParameter,
                            "id"
                            ),
                        Expression.Constant(id)
                        ),
                    new[] { itemParameter }
                    );

                T entity = dbContext.GetTable<T>().First(firstExpression);

                dbContext.GetTable<T>().DeleteOnSubmit(entity);
                dbContext.SubmitChanges();
            }
        }

        /// <summary>
        /// The method searches an object from a database table by id.
        /// </summary>
        /// <param name="id">Object id</param>
        /// <returns>Reading object</returns>
        public T Read(int id)
        {
            using (var dbContext = new SessionDataContext())
            {
                // Creates a custom lambda to find an object by ID.
                var itemParameter = Expression.Parameter(typeof(T), "item");
                var firstExpression = Expression.Lambda<Func<T, bool>>
                    (
                    Expression.Equal(
                        Expression.Property(
                            itemParameter,
                            "id"
                            ),
                        Expression.Constant(id)
                        ),
                    new[] { itemParameter }
                    );

                T readModel = dbContext.GetTable<T>().FirstOrDefault(firstExpression);

                return readModel;
            }
        }
    }
}
