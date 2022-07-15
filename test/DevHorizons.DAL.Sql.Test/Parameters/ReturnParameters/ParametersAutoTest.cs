namespace DevHorizons.DAL.Sql.Test.Parameters.ReturnParameters
{
    using System;
    using System.Reflection;
    using DAL.Shared;
    using Sql;
    using Xunit;

    public class ReturnParameter : TestBase
    {
        [Fact]
        public void ExplicitReturnParameter()
        {
            var parName = "parReturn";
            byte parValue = 3;
            var par = new SqlParameter(name:parName, direction: Direction.ReturnValue);
            Assert.NotNull(par);
            this.dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter);
            Assert.Null(sqlParameter.Value);
            Assert.Null(par.Value);
            Assert.Equal(System.Data.ParameterDirection.ReturnValue, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.Int, sqlParameter.SqlDbType);
            Assert.Equal(-1, sqlParameter.Size);
            sqlParameter.Value = parValue;
            Assert.NotNull(sqlParameter.Value);
            this.dalCmd.ClearErrors();
            var updateParamsMethod = typeof(Abstracts.ACommand).GetMethod("UpdateParameters", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(updateParamsMethod);
            var updateResult = updateParamsMethod.Invoke(this.dalCmd, new object[] { false }).To<bool>();
            Assert.True(updateResult);
            Assert.NotNull(par.Value);
            Assert.Equal(par.Value.To<int>(), parValue);
            Assert.Equal(sqlParameter.Value, par.Value);
        }
    }
}