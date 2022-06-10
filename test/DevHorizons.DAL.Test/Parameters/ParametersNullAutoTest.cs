namespace DevHorizons.DAL.Test
{
    using System;
    using System.Data.Common;
    using DAL.Shared;
    using Microsoft.Data.SqlClient;
    using Models;
    using Sql;
    using Xunit;

    public class ParametersNullAutoTest
    {
        private readonly DataAccessSettings dataAccessSettings;
        private readonly Sql.SqlCommand dalCmd;
        private readonly Microsoft.Data.SqlClient.SqlCommand internalCmdObject;
        private readonly Product product = new Product();
        public ParametersNullAutoTest()
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
        public void IntNullParameter()
        {
            var parName = "ProductId";
            int? parValue = null;
            var par = new Sql.SqlParameter(name: parName, value: parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
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
        public void IntZeroParameter()
        {
            var parName = "EmployeeId";
            int? parValue = 0;
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
                    && sqlIntParmeter.Value.To<float>() == parValue
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
                    && sqlIntParmeter.Value.To<float>() == parValue
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