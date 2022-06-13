namespace DevHorizons.DAL.Test.Parameters
{
    using System;
    using DAL.Shared;
    using Sql;

    using Xunit;

    public class ParametersSpecialTypesTest : TestBase
    {
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
            var par = new SqlParameter(parName, employee);
            par.SpecialType = SpecialType.Structured;
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

            var par = new SqlParameter(parName, employee);
            par.SpecialType = SpecialType.Json;
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

            var par = new SqlParameter(parName, employee);
            par.SpecialType = SpecialType.Xml;
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

        [Fact]
        public void VarBinaryFromObjectParameter()
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

            var expectedParameterValue = employee.ToBinary();
            Assert.NotNull(expectedParameterValue);

            var par = new SqlParameter(parName, employee);
            par.SpecialType = SpecialType.Binary;
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte[]>().FromBinary<Employee>().ToJsonString() == expectedParameterValue.FromBinary<Employee>().ToJsonString()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.VarBinary
                    && sqlIntParmeter.Size == -1
                );
        }

        [Fact]
        public void VarBinaryFromBase64StringParameter()
        {
            var base64String = "Hello World".ToBase64String();
            Assert.NotNull(base64String);
            var binary = base64String.ToBinary();
            Assert.NotNull(binary);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, binary);
            par.SpecialType = SpecialType.Binary;

            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte[]>().ToBase64String() == base64String
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.VarBinary
                    && sqlIntParmeter.Size == -1
                );
        }

        [Fact]
        public void BinaryFromPlainTextParameter()
        {
            var plainText = "Hello World";

            byte[] binary = null;
            try
            {
                binary = plainText.ToBinary();
            }
            catch (Exception ex)
            {
                Assert.True(ex is FormatException);
            }

            Assert.Null(binary);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, plainText);
            par.SpecialType = SpecialType.Binary;
            this.dalCmd.ClearErrors();
            this.dalCmd.ClearParameters();
            Assert.True(this.dalCmd.Errors.Count == 0);
            Assert.True(this.dalCmd.Parameters.Count == 0);
            this.dalCmd.AddParameter(par);
            Assert.True(this.dalCmd.Errors.Count == 1);
            var error = this.dalCmd.Errors[0];
            Assert.NotNull(error);
            Assert.True(error.Exception is FormatException);
            Assert.True(this.dalCmd.Parameters.Count == 0);
        }

        [Fact]
        public void Base64Parameter()
        {
            var base64String = "Hello World".ToBase64String();
            Assert.NotNull(base64String);
            var binary = base64String.ToBinary();
            Assert.NotNull(binary);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, binary);
            par.SpecialType = SpecialType.Base64;

            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.ToString() == base64String
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == -1
                );
        }
    }
}