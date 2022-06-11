namespace DevHorizons.DAL.Test
{
    using System;
    using System.Data.Common;
    using Sql;
    using Xunit;

    public class Base
    {
        protected readonly DataAccessSettings dataAccessSettings;
        protected readonly new SqlCommand dalCmd;
        protected readonly Microsoft.Data.SqlClient.SqlCommand internalCmdObject;
        protected readonly SqlConnectionSettings sqlConnectionSettings;
        protected const string INITIALCONNECTIONSTRING = "Integrated Security=SSPI; Data Source=.;Initial Catalog=OnlineStore;";

        public Base(string connectionString = null)
        {
            this.sqlConnectionSettings = new SqlConnectionSettings
            {
                ConnectionString = connectionString ?? INITIALCONNECTIONSTRING
            };

            this.dataAccessSettings = new DataAccessSettings
            {
                ConnectionSettings = this.sqlConnectionSettings
            };

            try
            {
                this.dalCmd = new SqlCommand(this.dataAccessSettings);
                var type = this.dalCmd.GetType();
                var internalCmdProp = type.GetProperty("Cmd", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (internalCmdProp != null)
                {
                    this.internalCmdObject = internalCmdProp.GetValue(dalCmd) as Microsoft.Data.SqlClient.SqlCommand;
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException ex)
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

    }
}
