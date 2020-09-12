using System.Linq;

namespace EPAM_Task7.Reports
{
    /// <summary>
    /// Class for getting data from database.
    /// </summary>
    public static class ReportData
    {
        /// <summary>
        /// The method gets avetage mark by speciality.
        /// </summary>
        /// <param name="semesterNumber">Semester number</param>
        /// <param name="specialty">Specialty</param>
        /// <returns>Avetage mark by speciality</returns>
        public static double GetAverageMarkBySpeciality(int semesterNumber, Specialty specialty)
        {
            double averageMark = 0;

            foreach (Group group in specialty.Groups)
            {
                foreach (Student student in group.Students)
                {
                    averageMark += student.ExamResults.Where(obj => obj.Exam.Session.SemesterNumber == semesterNumber)
                                                      .Select(obj => obj.Result)
                                                      .Average();
                }
            }

            int countStudent = specialty.Groups.Select(obj => obj.Students.Count).Sum();

            return (averageMark / countStudent);
        }

        /// <summary>
        /// The method gets avetage mark by examiner.
        /// </summary>
        /// <param name="sessionNumber">Semester number</param>
        /// <param name="examiner">Examiner</param>
        /// <returns>Avetage mark by examiner</returns>
        public static double GetAverageMarkByExaminer(int sessionNumber, Examiner examiner)
        {
            double averageMark = 0;

            foreach (Exam exam in examiner.Exams)
            {
                averageMark += exam.ExamResults.Where(obj => obj.Exam.Session.SemesterNumber == sessionNumber)
                                               .Select(obj => obj.Result)
                                               .Average();
            }

            return (averageMark / examiner.Exams.Count);
        }

        /// <summary>
        /// The method gets avetage mark by exam.
        /// </summary>
        /// <param name="exam">Exam</param>
        /// <returns>Avetage mark by exam</returns>
        public static double GetAverageMarkByExam(Exam exam)
        {
            double averageMark = exam.ExamResults.Select(obj => obj.Result).Average();
            return averageMark;
        }
    }
}
