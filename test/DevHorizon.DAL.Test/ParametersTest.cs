namespace DevHorizons.DAL.Test
{
    using System;

    using Microsoft.Data.SqlClient;

    using DAL.Shared;

    using Sql;

    using Xunit;

    public class ParametersTest
    {
        private readonly DataAccessSettings dataAccessSettings;
        private readonly new Sql.Command dalCmd;
        private readonly SqlCommand internalCmdObject;

        public ParametersTest()
        {
            this.dataAccessSettings = new DataAccessSettings
            {
                ConnectionSettings = new ConnectionSettings
                {
                    ConnectionString = "DummyConnectionString"
                }
            };

            try
            {
                this.dalCmd = new Sql.Command(this.dataAccessSettings);
                var type = dalCmd.GetType();
                var internalCmdProp = type.GetProperty("Cmd", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                internalCmdObject = internalCmdProp.GetValue(dalCmd) as SqlCommand;
            }
            catch
            {
                throw;
            }
        }

        [Fact]
        public void InternalCmdObject()
        {
            Assert.NotNull(this.internalCmdObject);
        }

        [Fact]
        public void ParameterName()
        {
            var parEmployeeIdName = "EmployeeId";
            var parFirstNameName = "@FirstName";
            var parEmployeeId = new Sql.SqlParameter(parEmployeeIdName, SqlDbType.Int);
            var parFirstName = new Sql.SqlParameter(parFirstNameName, SqlDbType.NVarChar);

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
            var par = new Sql.SqlParameter(parName, SqlDbType.Int);
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
        public void IntParameterAuto()
        {
            var parName = "EmployeeId";
            var parValue = 3;
            var par = new Sql.SqlParameter(parName, parValue);
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
        public void IntParameterWithValue()
        {
            var parName = "EmployeeId";
            var parValue = 3;
            var par = new Sql.SqlParameter(parName, SqlDbType.Int, parValue);
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
        public void FloatParameterAuto()
        {
            var parName = "Price";
            var parValue = 3.5;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<float>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }

        [Fact]
        public void RealParameterAuto()
        {
            var parName = "Price";
            var parValue = 3.5;
            var par = new Sql.SqlParameter(parName, SqlDbType.Real, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<float>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Real
                );
        }

        [Fact]
        public void DateTimeParameterAuto()
        {
            var parName = "OrderDate";
            var parValue = DateTime.Now;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<DateTime>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.DateTime
                );
        }

        [Fact]
        public void DateTime2Parameter()
        {
            var parName = "OrderDate";
            var parValue = DateTime.Now;
            var par = new Sql.SqlParameter(parName, SqlDbType.DateTime2, parValue);
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
            var par = new Sql.SqlParameter(parName, SqlDbType.SmallDateTime, parValue);
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
        public void StringParameterAutoEmptyString()
        {
            var parName = "Description";
            var parValue = string.Empty;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == 0
                );
        }

        [Fact]
        public void StringParameterAuto()
        {
            var parName = "Name";
            var parValue = "Ahmad Gad";
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == parValue.Length
                );
        }

        [Fact]
        public void VarBinaryParameterAuto()
        {
            var parName = "Description";
            var parValue = new byte[2];
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte[]>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.VarBinary
                    && sqlIntParmeter.Size == -1
                );
        }

        [Fact]
        public void ImageParameter()
        {
            var parName = "Image";
            var parValue = new byte[2];
            var par = new Sql.SqlParameter(parName, SqlDbType.Image, parValue);
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
            if (expectedParValue == null)
            {
                return;
            }

            Assert.True
                (
                    expectedParValue.Columns.Count == 4
                    && expectedParValue.Columns[0].ColumnName == nameof(employee.FirstName)
                    && expectedParValue.Columns[1].ColumnName == nameof(employee.LastName)
                    && expectedParValue.Columns[2].ColumnName == nameof(employee.DateOfBirth)
                    && expectedParValue.Columns[3].ColumnName == nameof(employee.Salary)
                );
            var par = new Sql.SqlParameter(parName, SqlDbType.Structured, employee);
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
        public void JsonParameter()
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

            var expectedParameterValue = employee.ToJsonString();
            Assert.True(!string.IsNullOrEmpty(expectedParameterValue));
            if (string.IsNullOrEmpty(expectedParameterValue))
            {
                return;
            }


            var par = new Sql.SqlParameter(parName, SqlDbType.Json, employee);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == expectedParameterValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
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
            if (string.IsNullOrEmpty(expectedParameterValue))
            {
                return;
            }


            var par = new Sql.SqlParameter(parName, SqlDbType.Xml, employee);
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