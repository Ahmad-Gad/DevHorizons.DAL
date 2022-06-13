namespace DevHorizons.DAL.Test.Parameters
{
    using System;
    using DAL.Shared;
    using Sql;
    using Xunit;

    public class ParametersObjectAutoTest : TestBase
    {
        [Fact]
        public void ByteParameter()
        {
            var parName = "EmployeeId";
            object parValue = (byte)3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte>() == parValue.To<byte>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.TinyInt
                );
        }


        [Fact]
        public void SByteParameter()
        {
            var parName = "EmployeeId";
            object parValue = (sbyte)-3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<sbyte>() == parValue.To<sbyte>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.TinyInt
                );
        }

        [Fact]
        public void ShortParameter()
        {
            var parName = "EmployeeId";
            object parValue = (short)3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<short>() == parValue.To<short>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.SmallInt
                );
        }

        [Fact]
        public void ShortMaxValueParameter()
        {
            var parName = "EmployeeId";
            object parValue = short.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<short>() == parValue.To<short>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.SmallInt
                );
        }

        [Fact]
        public void UShortParameter()
        {
            var parName = "EmployeeId";
            object parValue = (ushort)3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<ushort>() == parValue.To<ushort>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void UShortMaxValueParameter()
        {
            var parName = "EmployeeId";
            object parValue = ushort.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<ushort>() == parValue.To<ushort>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void IntParameter()
        {
            var parName = "EmployeeId";
            object parValue = 3;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<int>() == parValue.To<int>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void IntMaxValueParameter()
        {
            var parName = "EmployeeId";
            object parValue = int.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<int>() == parValue.To<int>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void UIntParameter()
        {
            var parName = "EmployeeId";
            object parValue = (uint) 5;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<uint>() == parValue.To<uint>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void UIntMaxValuParameter()
        {
            var parName = "EmployeeId";
            object parValue = uint.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<uint>() == parValue.To<uint>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void LongParameter()
        {
            var parName = "EmployeeId";
            object parValue = (long) 0;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<long>() == parValue.To<long>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void LongMaxValueParameter()
        {
            var parName = "EmployeeId";
            object parValue = long.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<long>() == parValue.To<long>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void ULongParameter()
        {
            var parName = "EmployeeId";
            var parValue = (ulong) 2;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<ulong>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void ULongZeroParameter()
        {
            var parName = "EmployeeId";
            var parValue = (ulong)0;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<ulong>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void ULongMaxValueParameter()
        {
            var parName = "EmployeeId";
            var parValue = ulong.MaxValue;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<ulong>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void IntZeroParameter()
        {
            var parName = "EmployeeId";
            object parValue = 0;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<int>() == parValue.To<int>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void ExplicitDouble2FloatParameter()
        {
            var parName = "Price";
            object parValue = 3.5D;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<double>() == parValue.To<double>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }

        [Fact]
        public void Double2FloatParameter()
        {
            var parName = "Price";
            object parValue = 3.5;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<double>() == parValue.To<double>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }

        [Fact]
        public void Float2RealParameter()
        {
            var parName = "Price";
            object parValue = 3.5F;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<float>() == parValue.To<float>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Real
                );
        }

        [Fact]
        public void DecimalParameter()
        {
            var parName = "Price";
            object parValue = 3.5M;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<decimal>() == parValue.To<decimal>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void DateTimeParameter()
        {
            var parName = "OrderDate";
            object parValue = DateTime.Now;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<DateTime>() == parValue.To<DateTime>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.DateTime
                );
        }

        [Fact]
        public void BooleanTrueParameter()
        {
            var parName = "Active";
            object parValue = true;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<bool>() == parValue.To<bool>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Bit
                );
        }

        [Fact]
        public void BooleanFalseParameter()
        {
            var parName = "Active";
            object parValue = false;
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<bool>() == parValue.To<bool>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Bit
                );
        }

        [Fact]
        public void GuidParameter()
        {
            var parName = "ProductGuid";
            object parValue = Guid.NewGuid();
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<Guid>() == parValue.To<Guid>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.UniqueIdentifier
                );
        }

        [Fact]
        public void CharParameter()
        {
            var parName = "Description";
            object parValue = 'A';
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<char>() == parValue.To<char>()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == 1
                );
        }

        [Fact]
        public void StringParameterEmptyString()
        {
            var parName = "Description";
            object parValue = string.Empty;
            var par = new SqlParameter(parName, parValue);
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
        public void StringParameter()
        {
            var parName = "Name";
            object parValue = "Ahmad Gad";
            var par = new SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == parValue.ToString()
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == parValue.ToString().Length
                );
        }

        [Fact]
        public void VarBinaryParameterAuto()
        {
            var parName = "Description";
            object parValue = new byte[2];
            var par = new SqlParameter(parName, parValue);
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
        public void StructuredParameter()
        {
            var dob = DateTime.Now;
            object employee = new Employee
            {
                FirstName = "Ahmad",
                LastName = "Gad",
                DateOfBirth = dob,
                Salary = 500
            };

            var parName = "Employee";

            var expectedParValue = employee.ToStructuredDbType(this.dataAccessSettings, null, null);
            Assert.NotNull(expectedParValue);

            var emp = employee as Employee;
            Assert.True
                (
                    expectedParValue.Columns.Count == 4
                    && expectedParValue.Columns[0].ColumnName == nameof(emp.FirstName)
                    && expectedParValue.Columns[1].ColumnName == nameof(emp.LastName)
                    && expectedParValue.Columns[2].ColumnName == nameof(emp.DateOfBirth)
                    && expectedParValue.Columns[3].ColumnName == nameof(emp.Salary)
                );
            var par = new SqlParameter(parName, employee);
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
    }
}