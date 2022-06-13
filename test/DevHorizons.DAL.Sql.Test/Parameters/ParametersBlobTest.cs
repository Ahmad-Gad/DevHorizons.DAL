namespace DevHorizons.DAL.Test.Parameters
{
    using System;
    using DAL.Shared;
    using Sql;

    using Xunit;

    public class ParametersBlobTest : TestBase
    {
        [Fact]
        public void BinaryFromObjectParameter()
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

            var par = new SqlParameter(parName, SqlDbType.Binary, employee);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte[]>().FromBinary<Employee>().ToJsonString() == expectedParameterValue.FromBinary<Employee>().ToJsonString()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Binary
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

            var par = new SqlParameter(parName, SqlDbType.VarBinary, employee);
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
        public void BinaryFromBase64StringParameter()
        {
            var base64String = "Hello World".ToBase64String();
            Assert.NotNull(base64String);
            var binary = base64String.ToBinary();
            Assert.NotNull(binary);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, SqlDbType.Binary, binary);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte[]>().ToBase64String() == base64String
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Binary
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
            var par = new SqlParameter(parName, SqlDbType.Binary, plainText);
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
        public void VarBinaryFromPlainTextParameter()
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
            var par = new SqlParameter(parName, SqlDbType.VarBinary, plainText);
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
        public void VarBinaryFromVBase64StringParameter()
        {
            var base64String = "Hello World".ToBase64String();
            Assert.NotNull(base64String);
            var binary = base64String.ToBinary();
            Assert.NotNull(binary);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, SqlDbType.VarBinary, binary);
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
        public void ImageParameter()
        {
            var base64String = "Hello World".ToBase64String();
            Assert.NotNull(base64String);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, SqlDbType.Image, base64String);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte[]>().ToBase64String() == base64String
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Image
                    && sqlIntParmeter.Size == -1
                );
        }

    }
}