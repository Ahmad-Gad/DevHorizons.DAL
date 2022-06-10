namespace DevHorizons.DAL.Test.Parameters
{
    using System;
    using System.Data.Common;
    using DAL.Shared;
    using Microsoft.Data.SqlClient;
    using Sql;

    using Xunit;

    public class ParametersAutoTest
    {
        private readonly DataAccessSettings dataAccessSettings;
        private readonly Sql.SqlCommand dalCmd;
        private readonly Microsoft.Data.SqlClient.SqlCommand internalCmdObject;

        public ParametersAutoTest()
        {
            this.dataAccessSettings = new DataAccessSettings
            {
                ConnectionSettings = new SqlConnectionSettings
                {
                    ConnectionString = "Integrated Security=SSPI; Data Source=.;Initial Catalog=OnlineStore;TrustServerCertificate=True;"
                    //ConnectionString = "Dummy"
                }
            };

            try
            {
                this.dalCmd = new Sql.SqlCommand(this.dataAccessSettings);
                var type = dalCmd.GetType();
                var internalCmdProp = type.GetProperty("Cmd", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                internalCmdObject = internalCmdProp.GetValue(dalCmd) as Microsoft.Data.SqlClient.SqlCommand;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (DbException ex)
            {
                throw;
            }
            catch (Exception ex)
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
        public void ByteParameter()
        {
            var parName = "EmployeeId";
            byte parValue = 3;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<byte>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.TinyInt
                );
        }

        [Fact]
        public void SByteParameter()
        {
            var parName = "EmployeeId";
            sbyte parValue = -3;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<sbyte>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.TinyInt
                );
        }

        [Fact]
        public void ShortParameter()
        {
            var parName = "EmployeeId";
            short parValue = 3;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<short>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.SmallInt
                );
        }

        [Fact]
        public void UShortParameter()
        {
            var parName = "EmployeeId";
            var parValue = ushort.MaxValue;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<ushort>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }

        [Fact]
        public void IntParameter()
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
        public void UIntParameter()
        {
            var parName = "EmployeeId";
            var parValue = uint.MaxValue;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<uint>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void LongParameter()
        {
            var parName = "EmployeeId";
            var parValue = long.MaxValue;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<long>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.BigInt
                );
        }

        [Fact]
        public void ULongParameter()
        {
            var parName = "EmployeeId";
            var parValue = ulong.MaxValue;
            var par = new Sql.SqlParameter(parName, parValue);
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
            var parValue = 0;
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
        public void ExplicitDouble2FloatParameter()
        {
            var parName = "Price";
            var parValue = 3.5D;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<double>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }

        [Fact]
        public void Double2FloatParameter()
        {
            var parName = "Price";
            var parValue = 3.5;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<double>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }

        [Fact]
        public void Float2RealParameter()
        {
            var parName = "Price";
            var parValue = 3.5F;
            var par = new Sql.SqlParameter(parName, parValue);
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
        public void DecimalParameter()
        {
            var parName = "Price";
            var parValue = 3.5M;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<decimal>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void DateTimeParameter()
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
        public void BooleanTrueParameter()
        {
            var parName = "Active";
            var parValue = true;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<bool>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Bit
                );
        }

        [Fact]
        public void BooleanFalseParameter()
        {
            var parName = "Active";
            var parValue = false;
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<bool>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Bit
                );
        }

        [Fact]
        public void GuidParameter()
        {
            var parName = "ProductGuid";
            var parValue = Guid.NewGuid();
            var par = new Sql.SqlParameter(parName, parValue);
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
        public void CharParameterEmptyString()
        {
            var parName = "Description";
            var parValue = 'A';
            var par = new Sql.SqlParameter(parName, parValue);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<char>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == 1
                );
        }

        [Fact]
        public void ObjectCharParameterEmptyString()
        {
            var parName = "Description";
            object parValue = 'A';
            var par = new Sql.SqlParameter(parName, parValue);
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
        public void StringParameter()
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
            var par = new Sql.SqlParameter(parName, employee);
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