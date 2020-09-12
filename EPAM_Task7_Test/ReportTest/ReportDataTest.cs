using EPAM_Task7;
using EPAM_Task7.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EPAM_Task7_Test.ReportTest
{
    /// <summary>
    /// Class for testing class ReportData.
    /// </summary>
    [TestClass]
    public class ReportDataTest
    {
        /// <summary>
        /// The method tests the method GetAverageMarkBySpeciality.
        /// </summary>
        [TestMethod]
        public void Test_GetAverageMarkBySpeciality()
        {
            int semesterNumber = 1;
            double result = 0;
            double actualResult = 3.444444;

            using (var dbContext = new SessionDataContext())
            {
                Specialty specialty = dbContext.Specialties.First();
                result = ReportData.GetAverageMarkBySpeciality(semesterNumber, specialty);
            }

            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests the method GetAverageMarkByExaminer.
        /// </summary>
        [TestMethod]
        public void Test_GetAverageMarkByExaminer()
        {
            int semesterNumber = 2;
            double result = 0;
            double actualResult = 8;

            using (var dbContext = new SessionDataContext())
            {
                Examiner examiner = dbContext.Examiners.First();
                result = ReportData.GetAverageMarkByExaminer(semesterNumber, examiner);
            }

            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests the method GetAverageMarkByExam.
        /// </summary>
        [TestMethod]
        public void Test_GetAverageMarkByExam()
        {
            double result = 0;
            double actualResult = 3.333333;

            using (var dbContext = new SessionDataContext())
            {
                Exam exam = dbContext.Exams.First();
                result = ReportData.GetAverageMarkByExam(exam);
            }

            Assert.AreEqual(result, actualResult, 0.000001);
        }
    }
}
