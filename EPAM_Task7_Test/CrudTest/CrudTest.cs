using EPAM_Task7;
using EPAM_Task7.CRUD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace EPAM_Task7_Test.CrudTest
{
    /// <summary>
    /// Class for testing class Crud.
    /// </summary>
    [TestClass]
    public class CrudTest
    {
        /// <summary>
        /// The method tests the method Insert when object id is not exists.
        /// </summary>
        [TestMethod]
        public void Insert_WhenObjectIdIsNotExists_AddObject()
        {
            Crud<Student> crud = new Crud<Student>();
            var student = new Student()
            {
                ID = 4,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 06, 06),
                GroupID = 1
            };

            crud.Insert(student);

            Student result = crud.Read(student.ID);
            crud.Delete(student.ID);

            Assert.AreEqual(result.ID, student.ID);
        }

        /// <summary>
        /// The method tests the method Insert.
        /// </summary>
        [TestMethod]
        public void Insert_WhenObjectIdExists_ThrowSqlException()
        {
            Crud<Student> crud = new Crud<Student>();
            var student = new Student()
            {
                ID = 1,
                FullName = "Dfsdf Lidia Dmitrievna",
                Gender = "Woman",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            Assert.ThrowsException<SqlException>(() => crud.Insert(student));
        }

        /// <summary>
        /// The method tests the method Update.
        /// </summary>
        [TestMethod]
        public void Test_Update()
        {
            Crud<Student> crud = new Crud<Student>();
            var student = new Student()
            {
                ID = 3,
                FullName = "Avseeva Eva Eleseevna",
                Gender = "Woman",
                Birthdate = new DateTime(2001, 4, 18),
                GroupID = 1
            };

            crud.Update(student.ID, student);

            Student result = crud.Read(student.ID);

            Assert.AreEqual(result.FullName, student.FullName);
        }

        /// <summary>
        /// The method tests the method Delete when object exists.
        /// </summary>
        [TestMethod]
        public void Delete_WhenObjectExists_DeleteObject()
        {
            Crud<Student> crud = new Crud<Student>();
            var student = new Student()
            {
                ID = 4,
                FullName = "Avseeva Eva Eleseevna",
                Gender = "Woman",
                Birthdate = new DateTime(2001, 4, 18),
                GroupID = 1
            };

            crud.Insert(student);

            crud.Delete(student.ID);

            Student result = crud.Read(student.ID);

            Assert.IsNull(result);
        }

        /// <summary>
        /// The method tests the method Read when object exists.
        /// </summary>
        [TestMethod]
        public void Read_WhenObjectExists_GetObject()
        {
            Crud<Student> crud = new Crud<Student>();
            var student = new Student()
            {
                ID = 1,
                FullName = "Famov Maxim Gennadievich",
                Gender = "Male",
                Birthdate = new DateTime(2000, 6, 6),
                GroupID = 1
            };

            Student result = crud.Read(student.ID);

            Assert.AreEqual(result.FullName, student.FullName);
        }

        /// <summary>
        /// The method tests the method Read when object does not exists.
        /// </summary>
        [TestMethod]
        public void Read_WhenObjectNotExists_GetNull()
        {
            int id = 5;
            Crud<Student> crud = new Crud<Student>();

            Student result = crud.Read(id);

            Assert.IsNull(result);
        }
    }
}
