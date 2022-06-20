namespace DevHorizons.DAL.Sql.Test.Parameters.InputParameters
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
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Binary, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(expectedParameterValue.FromBinary<Employee>().ToJsonString(), sqlParameter.Value.To<byte[]>().FromBinary<Employee>().ToJsonString());
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
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.VarBinary, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(expectedParameterValue.FromBinary<Employee>().ToJsonString(), sqlParameter.Value.To<byte[]>().FromBinary<Employee>().ToJsonString());
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
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Binary, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(base64String, sqlParameter.Value.To<byte[]>().ToBase64String());
        }

        [Fact]
        public void BinaryFromPlainTextParameter()
        {
            var plainText = "Hello World";

            byte[] binary = null;
            Assert.Null(binary);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, SqlDbType.Binary, plainText);
            dalCmd.ClearErrors();
            dalCmd.ClearParameters();
            Assert.True(dalCmd.Errors.Count == 0);
            Assert.True(dalCmd.Parameters.Count == 0);
            dalCmd.AddParameter(par);
            Assert.True(dalCmd.Errors.Count == 1);
            var error = dalCmd.Errors[0];
            Assert.NotNull(error);
            Assert.True(error.Exception is FormatException);
            Assert.True(dalCmd.Parameters.Count == 0);
        }

        [Fact]
        public void VarBinaryFromPlainTextParameter()
        {
            var plainText = "Hello World";
            byte[] binary = null;
            Assert.Null(binary);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, SqlDbType.VarBinary, plainText);
            dalCmd.ClearErrors();
            dalCmd.ClearParameters();
            Assert.True(dalCmd.Errors.Count == 0);
            Assert.True(dalCmd.Parameters.Count == 0);
            dalCmd.AddParameter(par);
            Assert.True(dalCmd.Errors.Count == 1);
            var error = dalCmd.Errors[0];
            Assert.NotNull(error);
            Assert.True(error.Exception is FormatException);
            Assert.True(dalCmd.Parameters.Count == 0);
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
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.VarBinary, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(base64String, sqlParameter.Value.To<byte[]>().ToBase64String());
        }

        [Fact]
        public void ImageParameter()
        {
            var base64String = "Hello World".ToBase64String();
            Assert.NotNull(base64String);
            var parName = "EmployeeImage";
            var par = new SqlParameter(parName, SqlDbType.Image, base64String);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Image, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(base64String, sqlParameter.Value.To<byte[]>().ToBase64String());
        }

    }
}