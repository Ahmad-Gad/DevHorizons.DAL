namespace DevHorizons.DAL.Sql.Test.Parameters.InputParameters
{
    using System;
    using DAL.Shared;
    using Sql;
    using Xunit;

    public class ParametersAutoTest : TestBase
    {
        [Fact]
        public void ByteParameter()
        {
            var parName = "EmployeeId";
            byte parValue = 3;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.TinyInt, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<byte>());
        }

        [Fact]
        public void SByteParameter()
        {
            var parName = "EmployeeId";
            sbyte parValue = -3;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.TinyInt, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<sbyte>());
        }

        [Fact]
        public void ShortParameter()
        {
            var parName = "EmployeeId";
            short parValue = 3;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.SmallInt, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<short>());
        }

        [Fact]
        public void UShortParameter()
        {
            var parName = "EmployeeId";
            var parValue = ushort.MaxValue;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Int, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<ushort>());
        }

        [Fact]
        public void IntParameter()
        {
            var parName = "EmployeeId";
            var parValue = 3;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Int, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<int>());
        }

        [Fact]
        public void UIntParameter()
        {
            var parName = "EmployeeId";
            var parValue = uint.MaxValue;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.BigInt, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<uint>());
        }

        [Fact]
        public void LongParameter()
        {
            var parName = "EmployeeId";
            var parValue = long.MaxValue;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.BigInt, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<long>()); 
        }

        [Fact]
        public void ULongParameter()
        {
            var parName = "EmployeeId";
            var parValue = ulong.MaxValue;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Decimal, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<ulong>());
        }

        [Fact]
        public void IntZeroParameter()
        {
            var parName = "EmployeeId";
            var parValue = 0;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Int, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<int>());
        }

        [Fact]
        public void ExplicitDouble2FloatParameter()
        {
            var parName = "Price";
            var parValue = 3.5D;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Float, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<double>());
        }

        [Fact]
        public void Double2FloatParameter()
        {
            var parName = "Price";
            var parValue = 3.5;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Float, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<double>());
        }

        [Fact]
        public void Float2RealParameter()
        {
            var parName = "Price";
            var parValue = 3.5F;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Real, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<float>());
        }

        [Fact]
        public void DecimalParameter()
        {
            var parName = "Price";
            var parValue = 3.5M;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Decimal, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<decimal>());
        }

        [Fact]
        public void DateTimeParameter()
        {
            var parName = "OrderDate";
            var parValue = DateTime.Now;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.DateTime, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<DateTime>());
        }

        [Fact]
        public void BooleanTrueParameter()
        {
            var parName = "Active";
            var parValue = true;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Bit, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<bool>());
        }

        [Fact]
        public void BooleanFalseParameter()
        {
            var parName = "Active";
            var parValue = false;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Bit, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<bool>());
        }

        [Fact]
        public void GuidParameter()
        {
            var parName = "ProductGuid";
            var parValue = Guid.NewGuid();
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.UniqueIdentifier, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<Guid>());
        }

        [Fact]
        public void CharParameter()
        {
            var parName = "Description";
            var parValue = 'A';
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<char>());
        }

        [Fact]
        public void CharParameterEmptyString()
        {
            var parName = "Description";
            var parValue = '\0';
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<char>());
        }

        [Fact]
        public void ObjectCharParameterEmptyString()
        {
            var parName = "Description";
            object parValue = '\0';
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<char>());
        }

        [Fact]
        public void StringParameterEmptyString()
        {
            var parName = "Description";
            var parValue = string.Empty;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(0, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.ToString());
        }

        [Fact]
        public void StringParameter()
        {
            var parName = "Name";
            var parValue = "Ahmad Gad";
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(parValue.Length, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.ToString());
        }

        [Fact]
        public void VarBinaryParameterAuto()
        {
            var parName = "Description";
            var parValue = new byte[2];
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.VarBinary, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(parValue, sqlParameter.Value.To<byte[]>());
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

            var expectedParValue = employee.ToStructuredDbType(dataAccessSettings, null, null);
            Assert.NotNull(expectedParValue);

            Assert.NotEmpty(expectedParValue.Columns);
            Assert.Equal(4, expectedParValue.Columns.Count);
            Assert.Equal(nameof(employee.FirstName), expectedParValue.Columns[0].ColumnName);
            Assert.Equal(nameof(employee.LastName), expectedParValue.Columns[1].ColumnName);
            Assert.Equal(nameof(employee.DateOfBirth), expectedParValue.Columns[2].ColumnName);
            Assert.Equal(nameof(employee.Salary), expectedParValue.Columns[3].ColumnName);
     
            var par = new SqlParameter(parName, employee);
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.NotNull(sqlParameter.Value);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Structured, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            Assert.Equal(expectedParValue.ToJsonString(), sqlParameter.Value.To<System.Data.DataTable>().ToJsonString());
        }
    }
}