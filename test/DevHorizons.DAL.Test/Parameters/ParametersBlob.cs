namespace DevHorizons.DAL.Test.Parameters
{
    using System;
    using DAL.Shared;
    using Sql;

    using Xunit;

    public class ParametersBlob : Base
    {
        [Fact]
        public void BinaryParameter()
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
        public void VarBinaryParameter()
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