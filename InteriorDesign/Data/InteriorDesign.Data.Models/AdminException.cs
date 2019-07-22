namespace InteriorDesign.Data.Models
{
    using System;

    public class AdminException
    {
        public int Id { get; set; }

        public string AdminUserName { get; set; }

        public string ExceptionType { get; set; }

        public string ExceptionMessage { get; set; }

        public string CallingMethod { get; set; }

        public DateTime OccurrenceDate { get; set; }
    }
}
