namespace DevHorizons.DAL.Test.Parameters
{
    using System;
    using DAL.Shared;
    using Sql;
    using Xunit;

    public class ParametersExplicitTypesTest : Base
    {
        [Fact]
        public void ParameterName()
        {
            var parEmployeeIdName = "EmployeeId";
            var parFirstNameName = "@FirstName";
            var parEmployeeId = new SqlParameter(parEmployeeIdName, SqlDbType.Int);
            var parFirstName = new SqlParameter(parFirstNameName, SqlDbType.NVarChar);

            this.dalCmd.AddParameter(parEmployeeId);
            this.dalCmd.AddParameter(parFirstName);

            Assert.True(this.internalCmdObject.Parameters.Count == 2);

            Assert.True(this.internalCmdObject.Parameters[0].ParameterName == $"@{parEmployeeIdName}");
            Assert.True(this.internalCmdObject.Parameters[1].ParameterName == parFirstNameName);
        }

        [Fact]
        public void IntParameterNull()
        {
            var parName = "EmployeeId";
            var par = new SqlParameter(parName, SqlDbType.Int);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value is null
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }


        [Fact]
        public void IntNullParameter()
        {
            var parName = "EmployeeId";
            int? parValue = null;
            var par = new SqlParameter(name: parName, value: parValue, dataType: SqlDbType.Int);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value == null
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void IntParameterWithValue()
        {
            var parName = "EmployeeId";
            var parValue = 3;
            var par = new SqlParameter(parName, SqlDbType.Int, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<int>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }


        [Fact]
        public void DateTime2Parameter()
        {
            var parName = "OrderDate";
            var parValue = DateTime.Now;
            var par = new SqlParameter(parName, SqlDbType.DateTime2, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<DateTime>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.DateTime2
                );
        }

        [Fact]
        public void SmallDateTimeParameter()
        {
            var parName = "OrderDate";
            var parValue = DateTime.Now;
            var par = new SqlParameter(parName, SqlDbType.SmallDateTime, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<DateTime>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.SmallDateTime
                );
        }

        [Fact]
        public void GuidParameter()
        {
            var parName = "ProductGuid";
            var parValue = Guid.NewGuid();
            var par = new SqlParameter(parName, SqlDbType.UniqueIdentifier, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<Guid>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.UniqueIdentifier
                );
        }

        [Fact]
        public void ImageParameter()
        {
            var parName = "Image";
            var parValue = new byte[2];
            var par = new SqlParameter(parName, SqlDbType.Image, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte[]>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Image
                    && sqlIntParmeter.Size == -1
                );
        }

        [Fact]
        public void StructuredParameter()
        {
            var dob = DateTime.Now;
            var employee = new Employee
            {
                FirstName = "Ahmad",
                LastName = "Gad",
                DateOfBirth = dob,
                Salary = 500
            };

            var parName = "Employee";

            var expectedParValue = employee.ToStructuredDbType(this.dataAccessSettings, null, null);
            Assert.NotNull(expectedParValue);

            Assert.True
                (
                    expectedParValue.Columns.Count == 4
                    && expectedParValue.Columns[0].ColumnName == nameof(employee.FirstName)
                    && expectedParValue.Columns[1].ColumnName == nameof(employee.LastName)
                    && expectedParValue.Columns[2].ColumnName == nameof(employee.DateOfBirth)
                    && expectedParValue.Columns[3].ColumnName == nameof(employee.Salary)
                );
            var par = new SqlParameter(parName, SqlDbType.Structured, employee);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<System.Data.DataTable>().ToJsonString() == expectedParValue.ToJsonString()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Structured
                    && sqlIntParmeter.Size == -1
                );
        }

        [Fact]
        public void XmlParameter()
        {
            var dob = DateTime.Now;
            var employee = new Employee
            {
                FirstName = "Ahmad",
                LastName = "Gad",
                DateOfBirth = dob,
                Salary = 500
            };

            var parName = "Employee";

            var expectedParameterValue = employee.ToXmlString();
            Assert.True(!string.IsNullOrEmpty(expectedParameterValue));

            var par = new SqlParameter(parName, SqlDbType.Xml, employee);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == expectedParameterValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Xml
                    && sqlIntParmeter.Size == -1
                );
        }
    }
}