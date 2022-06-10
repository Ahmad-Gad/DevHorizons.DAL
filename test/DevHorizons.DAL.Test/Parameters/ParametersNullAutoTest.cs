namespace DevHorizons.DAL.Test.Parameters
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
            var parName = nameof(this.product.ProductId);
            int? parValue = null;
            var par = new Sql.SqlParameter(name: parName, value: parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.To<int?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Int
                );
        }


        [Fact]
        public void FloatNullParameter()
        {
            var parName = nameof(this.product.Discount);
            float? parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<float?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Real
                );
        }

        [Fact]
        public void DoubleNullParameter()
        {
            var parName = nameof(this.product.PriceTotal);
            double? parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<float?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Float
                );
        }


        [Fact]
        public void DecimalNullParameter()
        {
            var parName = nameof(this.product.Price);
            decimal? parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<decimal?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Decimal
                );
        }

        [Fact]
        public void DateTimeNullParameter()
        {
            var parName = nameof(this.product.Modified);
            DateTime? parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<DateTime?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.DateTime
                );
        }


        [Fact]
        public void StringNullParameter()
        {
            var parName = nameof(this.product.ProductName);
            string parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == 1
                );
        }

        public void String2NullParameter()
        {
            var parName = nameof(this.product.ProductName);
            string parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == 1
                );
        }

        [Fact]
        public void CharNullParameter()
        {
            var parName = nameof(this.product.DiscountCode);
            char? parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<char?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == 1
                );
        }


        [Fact]
        public void GuidNullParameter()
        {
            var parName = nameof(this.product.ProductGuid);
            Guid? parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<Guid?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.UniqueIdentifier
                    && sqlIntParmeter.Size == -1
                );
        }


        [Fact]
        public void BooleanNullParameter()
        {
            var parName = nameof(this.product.Active);
            bool? parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<bool?>() == parValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Bit
                    && sqlIntParmeter.Size == -1
                );
        }


        [Fact]
        public void VarBinaryNullParameter()
        {
            var parName = nameof(this.product.ProductImage);
            byte[] parValue = null;
            var par = new Sql.SqlParameter(parName, parValue);
            var prop = this.product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
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