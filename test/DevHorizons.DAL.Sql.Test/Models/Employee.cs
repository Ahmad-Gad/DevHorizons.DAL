namespace DevHorizons.DAL.Sql.Test
{
    using System;

    using DAL.Attributes;

    public class Employee
    {
        [DataField(DataDirection = DataDirection.Inbound)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Salary { get; set; }
    }
}
