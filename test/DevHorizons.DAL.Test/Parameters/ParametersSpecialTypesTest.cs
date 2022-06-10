namespace DevHorizons.DAL.Test
{
    using System;
    using System.Data.Common;
    using DAL.Shared;
    using Microsoft.Data.SqlClient;
    using Sql;

    using Xunit;

    public class ParametersSpecialTypesTest
    {
        private readonly DataAccessSettings dataAccessSettings;
        private readonly Sql.SqlCommand dalCmd;
        private readonly Microsoft.Data.SqlClient.SqlCommand internalCmdObject;

        public ParametersSpecialTypesTest()
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
            par.SpecialType = SpecialType.Structured;
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

        [Fact]
        public void JsonParameter()
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

            var expectedParameterValue = employee.ToJsonString();
            Assert.True(!string.IsNullOrEmpty(expectedParameterValue));
            if (string.IsNullOrEmpty(expectedParameterValue))
            {
                return;
            }


            var par = new Sql.SqlParameter(parName, employee);
            par.SpecialType = SpecialType.Json;
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == expectedParameterValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.NVarChar
                    && sqlIntParmeter.Size == -1
                );
        }

        [Fact]
        public void XmlParameter()
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

            var expectedParameterValue = employee.ToXmlString();
            Assert.True(!string.IsNullOrEmpty(expectedParameterValue));
            if (string.IsNullOrEmpty(expectedParameterValue))
            {
                return;
            }


            var par = new Sql.SqlParameter(parName, employee);
            par.SpecialType = SpecialType.Xml;
            this.dalCmd.AddParameter(par);
            var sqlIntParmeter = internalCmdObject.Parameters[0];
            Assert.True
                (
                    sqlIntParmeter.Direction == System.Data.ParameterDirection.Input
                    && sqlIntParmeter.Value.To<string>() == expectedParameterValue
                    && sqlIntParmeter.SqlDbType == System.Data.SqlDbType.Xml
                    && sqlIntParmeter.Size == -1
                );
        }
    }
}