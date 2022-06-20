namespace DevHorizons.DAL.Sql.Test.Parameters.InputParameters
{
    using System;
    using DAL.Shared;
    using Models;
    using Sql;
    using Xunit;

    public class ParametersNullAutoTest : TestBase
    {

        private readonly Product product = new Product();

        [Fact]
        public void IntNullParameter()
        {
            var parName = nameof(product.ProductId);
            int? parValue = null;
            var par = new SqlParameter(name: parName, value: parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.Discount);
            float? parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.PriceTotal);
            double? parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.Price);
            decimal? parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.Modified);
            DateTime? parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.ProductName);
            string parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
        public void String2NullParameter()
        {
            var parName = nameof(product.ProductName);
            string parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.DiscountCode);
            char? parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.ProductGuid);
            Guid? parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.Active);
            bool? parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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
            var parName = nameof(product.ProductImage);
            byte[] parValue = null;
            var par = new SqlParameter(parName, parValue);
            var prop = product.GetType().GetProperty(parName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            par.SetPropertyInfo(prop);
            dalCmd.AddParameter(par);
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

            var expectedParValue = employee.ToStructuredDbType(dataAccessSettings, null, null);
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
            dalCmd.AddParameter(par);
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