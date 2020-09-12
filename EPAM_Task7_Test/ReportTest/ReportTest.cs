using System.IO;
using EPAM_Task7.CustomExceptions;
using EPAM_Task7.Enums;
using EPAM_Task7.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPAM_Task7_Test.ReportTest
{
    /// <summary>
    /// Class for testing class Report.
    /// </summary>
    [TestClass]
    public class ReportTest
    {
        /// <summary>
        /// The method tests the method GenerateSpecialityResults when column number exists.
        /// </summary>
        [TestMethod]
        public void GenerateSpecialityResults_WhenColumnNumberExists_WriteSessionResult()
        {
            string filePath = @"..\..\..\EPAM_Task7\Resources\report1.xlsx";
            int sessionNumber = 1;
            int columnNumber = 2;

            Report.GenerateSpecialityResults(sessionNumber, filePath, TypeSort.Ascending, columnNumber);

            long result;
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method GenerateSpecialityResults when column number not exists.
        /// </summary>
        [TestMethod]
        public void GenerateSpecialityResults_WhenColumnNumberNotExists_ThrowsColumnNumberException()
        {
            string filePath = @"..\..\..\EPAM_Task7\Resources\report1.xlsx";
            int sessionNumber = 1;
            int columnNumber = 5;

            Assert.ThrowsException<ColumnNumberException>(() => Report.GenerateSpecialityResults(sessionNumber, filePath, TypeSort.Ascending, columnNumber));
        }

        /// <summary>
        /// The method tests the method GenerateExaminerResults when column number exists.
        /// </summary>
        [TestMethod]
        public void GenerateExaminerResults_WhenColumnNumberExists_WriteAllSessionResults()
        {
            string filePath = @"..\..\..\EPAM_Task7\Resources\report2.xlsx";
            int sessionNumber = 2;
            int columnNumber = 1;

            Report.GenerateExaminerResults(sessionNumber, filePath, TypeSort.Descending, columnNumber);

            long result;
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method GenerateExaminerResults when column number not exists.
        /// </summary>
        [TestMethod]
        public void GenerateExaminerResults_WhenColumnNumberNotExists_ThrowsColumnNumberException()
        {
            string filePath = @"..\..\..\EPAM_Task7\Resources\report2.xlsx";
            int sessionNumber = 1;
            int columnNumber = -1;

            Assert.ThrowsException<ColumnNumberException>(() => Report.GenerateExaminerResults(sessionNumber, filePath, TypeSort.Ascending, columnNumber));
        }

        /// <summary>
        /// The method tests the method GenerateDynamicsAverageScoreForSubjectByYear when column number exists.
        /// </summary>
        [TestMethod]
        public void GenerateDynamicsAverageScoreForSubjectByYear_WhenColumnNumberExists_WriteBadStudentsListByGroup()
        {
            string filePath = @"..\..\..\EPAM_Task7\Resources\report3.xlsx";
            int columnNumber = 0;

            Report.GenerateDynamicsAverageScoreForSubjectByYear(filePath, TypeSort.Ascending, columnNumber);

            long result;
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                result = reader.Length;
            }

            Assert.IsTrue(result != 0);
        }

        /// <summary>
        /// The method tests the method GenerateDynamicsAverageScoreForSubjectByYear when column number not exists.
        /// </summary>
        [TestMethod]
        public void GenerateDynamicsAverageScoreForSubjectByYear_WhenColumnNumberNotExists_ThrowsColumnNumberException()
        {
            string filePath = @"..\..\..\EPAM_Task7\Resources\report3.xlsx";
            int columnNumber = 6;

            Assert.ThrowsException<ColumnNumberException>(() => Report.GenerateDynamicsAverageScoreForSubjectByYear(filePath, TypeSort.Ascending, columnNumber));
        }
    }
}
