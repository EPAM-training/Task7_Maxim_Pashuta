using System;

namespace EPAM_Task7.CustomExceptions
{
    /// <summary>
    /// Class for working custom Exception.
    /// </summary>
    public class ColumnNumberException : Exception
    {
        public ColumnNumberException()
        {
        }

        public ColumnNumberException(string message)
            : base(message)
        {
        }
    }
}
