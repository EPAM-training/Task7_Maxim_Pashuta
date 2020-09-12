using EPAM_Task7.CustomExceptions;
using EPAM_Task7.Enums;
using OfficeOpenXml;
using System;
using System.IO;

namespace EPAM_Task7.Reports
{
    /// <summary>
    /// Class for generation reports.
    /// </summary>
    public static class Report
    {
        /// <summary>
        /// The method establishes the necessary connections between tables, generates an Excel table with session results and sorts it.
        /// </summary>
        /// <param name="sessionNumber">Session number</param>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeSort">Sort type</param>
        /// <param name="columnToSort">Column number to sort</param>
        public static void GenerateSpecialityResults(int sessionNumber, string filePath, TypeSort typeSort, int columnToSort)
        {
            int leftBoard = 0;
            int rightBoard = 2;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SessionReport");

                int rowNumber = 1;

                // Filling the XLSX file with data
                using (var dbContext = new SessionDataContext())
                {
                    foreach (Specialty specialty in dbContext.Specialties)
                    {
                        worksheet.Cells[rowNumber, 1].Value = sessionNumber;
                        worksheet.Cells[rowNumber, 2].Value = specialty.Name;
                        worksheet.Cells[rowNumber, 3].Value = ReportData.GetAverageMarkBySpeciality(sessionNumber, specialty);

                        rowNumber++;
                    }
                }

                // Selects the sort type and sorts
                if (typeSort == TypeSort.Ascending)
                {
                    worksheet.Cells["A:C"].Sort(columnToSort);
                }
                else
                {
                    worksheet.Cells["A:C"].Sort(columnToSort, true);
                }

                MoveRowsDown(worksheet);

                // Setting column names.
                worksheet.Cells[1, 1].Value = nameof(Session);
                worksheet.Cells[1, 2].Value = nameof(Specialty);
                worksheet.Cells[1, 3].Value = "Average Mark";

                FileInfo file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// The method establishes the necessary connections between tables, generates an Excel table with all session results and sorts it.
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeSort">Sort type</param>
        /// <param name="columnToSort">Column number to sort</param>
        public static void GenerateExaminerResults(int sessionNumber, string filePath, TypeSort typeSort, int columnToSort)
        {
            int leftBoard = 0;
            int rightBoard = 2;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SessionReport");

                int rowNumber = 1;

                // Filling the XLSX file with datas
                using (var dbContext = new SessionDataContext())
                {
                    foreach (Examiner examiner in dbContext.Examiners)
                    {
                        try
                        {
                            worksheet.Cells[rowNumber, 3].Value = ReportData.GetAverageMarkByExaminer(sessionNumber, examiner);
                            worksheet.Cells[rowNumber, 1].Value = sessionNumber;
                            worksheet.Cells[rowNumber, 2].Value = examiner.FullName;
                        }
                        catch (InvalidOperationException)
                        {
                            continue;
                        }


                        rowNumber++;
                    }
                }

                // Selects the sort type and sorts
                if (typeSort == TypeSort.Ascending)
                {
                    worksheet.Cells["A:C"].Sort(columnToSort);
                }
                else
                {
                    worksheet.Cells["A:C"].Sort(columnToSort, true);
                }

                MoveRowsDown(worksheet);

                // Setting column names.
                worksheet.Cells[1, 1].Value = nameof(Session);
                worksheet.Cells[1, 2].Value = nameof(Examiner);
                worksheet.Cells[1, 3].Value = "Average Mark";

                FileInfo file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// The method establishes the necessary connections between tables, generates an Excel table with bad students list and sorts it.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeSort">Sort type</param>
        /// <param name="columnToSort">Column number to sort</param>
        public static void GenerateDynamicsAverageScoreForSubjectByYear(string filePath, TypeSort typeSort, int columnToSort)
        {
            int leftBoard = 0;
            int rightBoard = 2;

            // Checking for the existence of a column
            IsExistColumn(columnToSort, leftBoard, rightBoard);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SessionReport");

                int rowNumber = 1;

                // Filling the XLSX file with datas
                using (var dbContext = new SessionDataContext())
                {
                    foreach (Exam exam in dbContext.Exams)
                    {
                        worksheet.Cells[rowNumber, 1].Value = exam.Date.Year;
                        worksheet.Cells[rowNumber, 2].Value = exam.Discipline.Name;
                        worksheet.Cells[rowNumber, 3].Value = ReportData.GetAverageMarkByExam(exam);

                        rowNumber++;
                    }
                }

                // Selects the sort type and sorts
                if (typeSort == TypeSort.Ascending)
                {
                    worksheet.Cells["A:C"].Sort(columnToSort);
                }
                else
                {
                    worksheet.Cells["A:C"].Sort(columnToSort, true);
                }

                MoveRowsDown(worksheet);

                // Setting column names.
                worksheet.Cells[1, 1].Value = "Year";
                worksheet.Cells[1, 2].Value = nameof(Discipline);
                worksheet.Cells[1, 3].Value = "Average Mark";

                FileInfo file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// The method checks for column existence.
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="leftBoard"></param>
        /// <param name="rightBoard"></param>
        private static void IsExistColumn(int columnNumber, int leftBoard, int rightBoard)
        {
            if ((columnNumber < leftBoard) || (columnNumber > rightBoard))
            {
                throw new ColumnNumberException("This column is not exist.");
            }
        }

        /// <summary>
        /// The method shifts the rows in the table one row down.
        /// </summary>
        /// <param name="worksheet">Table</param>
        private static void MoveRowsDown(ExcelWorksheet worksheet)
        {
            for (int i = worksheet.Dimension.Rows; i > 0; i--)
            {
                for (int j = 1; j <= worksheet.Dimension.Columns; j++)
                {
                    worksheet.Cells[i + 1, j].Value = worksheet.Cells[i, j].Value;
                }
            }
        }
    }
}
