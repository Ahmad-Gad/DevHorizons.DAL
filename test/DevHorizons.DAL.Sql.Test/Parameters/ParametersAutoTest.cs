namespace DevHorizons.DAL.Sql.Test.Parameters
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
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<byte>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.TinyInt
                );
        }

        [Fact]
        public void SByteParameter()
        {
            var parName = "EmployeeId";
            sbyte parValue = -3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<sbyte>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.TinyInt
                );
        }

        [Fact]
        public void ShortParameter()
        {
            var parName = "EmployeeId";
            short parValue = 3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<short>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.SmallInt
                );
        }

        [Fact]
        public void UShortParameter()
        {
            var parName = "EmployeeId";
            var parValue = ushort.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<ushort>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void IntParameter()
        {
            var parName = "EmployeeId";
            var parValue = 3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<int>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void UIntParameter()
        {
            var parName = "EmployeeId";
            var parValue = uint.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<uint>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void LongParameter()
        {
            var parName = "EmployeeId";
            var parValue = long.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<long>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void ULongParameter()
        {
            var parName = "EmployeeId";
            var parValue = ulong.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<ulong>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void IntZeroParameter()
        {
            var parName = "EmployeeId";
            var parValue = 0;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<int>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void ExplicitDouble2FloatParameter()
        {
            var parName = "Price";
            var parValue = 3.5D;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<double>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }

        [Fact]
        public void Double2FloatParameter()
        {
            var parName = "Price";
            var parValue = 3.5;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<double>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }

        [Fact]
        public void Float2RealParameter()
        {
            var parName = "Price";
            var parValue = 3.5F;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<float>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Real
                );
        }

        [Fact]
        public void DecimalParameter()
        {
            var parName = "Price";
            var parValue = 3.5M;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<decimal>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void DateTimeParameter()
        {
            var parName = "OrderDate";
            var parValue = DateTime.Now;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<DateTime>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.DateTime
                );
        }

        [Fact]
        public void BooleanTrueParameter()
        {
            var parName = "Active";
            var parValue = true;
            var par = new SqlParameter(parName, parValue);
            Assert.NotNull(par);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParmeter);
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<bool>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Bit
                );
        }

        [Fact]
        public void BooleanFalseParameter()
        {
            var parName = "Active";
            var parValue = false;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<bool>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Bit
                );
        }

        [Fact]
        public void GuidParameter()
        {
            var parName = "ProductGuid";
            var parValue = Guid.NewGuid();
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<Guid>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.UniqueIdentifier
                );
        }

        [Fact]
        public void CharParameterEmptyString()
        {
            var parName = "Description";
            var parValue = 'A';
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<char>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlParmeter.Size == 1
                );
        }

        [Fact]
        public void ObjectCharParameterEmptyString()
        {
            var parName = "Description";
            object parValue = 'A';
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<char>() == parValue.To<char>()
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlParmeter.Size == 1
                );
        }

        [Fact]
        public void StringParameterEmptyString()
        {
            var parName = "Description";
            var parValue = string.Empty;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<string>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlParmeter.Size == 0
                );
        }

        [Fact]
        public void StringParameter()
        {
            var parName = "Name";
            var parValue = "Ahmad Gad";
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<string>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlParmeter.Size == parValue.Length
                );
        }

        [Fact]
        public void VarBinaryParameterAuto()
        {
            var parName = "Description";
            var parValue = new byte[2];
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<byte[]>() == parValue
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.VarBinary
                    && sqlParmeter.Size == -1
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
            var par = new SqlParameter(parName, employee);
            this.dalCmd.AddParameter(par);
            var sqlParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlParmeter.Value.To<System.Data.DataTable>().ToJsonString() == expectedParValue.ToJsonString()
                    && sqlParmeter.SqlDbType == System.Data.SqlDbType.Structured
                    && sqlParmeter.Size == -1
                );
        }
    }
}