namespace DevHorizons.DAL.Test.Connection
{
    using DAL.Shared;
    using Sql;
    using System.Collections.Generic;
    using Xunit;

    public class ConnectionStringBuilderTest
    {
        private readonly DataAccessSettings dataAccessSettings;
        private readonly new SqlCommand sqlCmd;
        private readonly Microsoft.Data.SqlClient.SqlCommand internalCmdObject;
        private readonly SqlConnectionSettings sqlConnectionSettings;
        private const string INITIALCONNECTIONSTRING = "Integrated Security=SSPI; Data Source=.;Initial Catalog=OnlineStore;";
        public ConnectionStringBuilderTest()
        {
            this.sqlConnectionSettings = new SqlConnectionSettings
            {
                ConnectionString = INITIALCONNECTIONSTRING
            };

            this.dataAccessSettings = new DataAccessSettings
            {
                ConnectionSettings = this.sqlConnectionSettings
            };

            try
            {
                this.sqlCmd = new SqlCommand(this.dataAccessSettings);
                var type = this.sqlCmd.GetType();
                var internalCmdProp = type.GetProperty("Cmd", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (internalCmdProp != null)
                {
                    this.internalCmdObject = internalCmdProp.GetValue(sqlCmd) as Microsoft.Data.SqlClient.SqlCommand;
                }
            }
            catch
            {
                throw;
            }
        }

        [Fact]
        public void InternalCmdObject()
        {
            Assert.NotNull(this.internalCmdObject);
            Assert.Equal(INITIALCONNECTIONSTRING, this.dataAccessSettings.ConnectionSettings.ConnectionString);
        }

        [Fact]
        public void AggregatedConnectionString()
        {
            var conStringDic = new Dictionary<string, string>()
            {
                { "Integrated Security", "SSPI" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            var extractedConnectionString = ConnectionStringBuilder.ExtractConnectionString(conStringDic);
            var expectedConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=System;";
            Assert.Equal(expectedConnectionString, extractedConnectionString);
        }

        [Fact]
        public void ExtractedConnectionString()
        {
            var expectedConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=System;";
            var extractedconnectionStringDic = ConnectionStringBuilder.ExtractConnectionString(expectedConnectionString);
            var expectedConStringDic = new Dictionary<string, string>()
            {
                { "Integrated Security", "SSPI" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            Assert.True(expectedConStringDic.Compare(extractedconnectionStringDic));
        }

        [Fact]
        public void ConnectionStringWithoutAdditionalSettings()
        {
            var newConnectionString = "Integrated Security=SSPI; Data Source=.;Initial Catalog=OnlineStore;";
            this.sqlConnectionSettings.ConnectionString = newConnectionString;
            this.sqlCmd.ResetHard(true);
            Assert.Equal(this.dataAccessSettings.ConnectionSettings.ConnectionString, newConnectionString);
        }

        [Fact]
        public void PacketSize()
        {
            var newConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=OnlineStore;";
            this.sqlConnectionSettings.ConnectionString = newConnectionString;
            this.sqlConnectionSettings.PacketSize = 4800;
            this.sqlCmd.ResetHard(true);
            var expectedConnectionString = $"{newConnectionString}Packet Size=4800;";
            Assert.Equal(expectedConnectionString, this.dataAccessSettings.ConnectionSettings.ConnectionString);
        }

        [Fact]
        public void PacketSizeOverride()
        {
            var newConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=OnlineStore;Packet Size=1024";
            this.sqlConnectionSettings.ConnectionString = newConnectionString;
            this.sqlConnectionSettings.PacketSize = 4800;
            this.sqlCmd.ResetHard(true);
            var expectedConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=OnlineStore;Packet Size=4800;";
            Assert.Equal(expectedConnectionString, this.dataAccessSettings.ConnectionSettings.ConnectionString);
        }

        [Fact]
        public void ColumnAlwaysEncryptedSettingEnabled()
        {
            var newConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=OnlineStore;";
            this.sqlConnectionSettings.ConnectionString = newConnectionString;
            this.sqlConnectionSettings.ColumnAlwaysEncryptedSettingEnabled = true;
            this.sqlCmd.ResetHard(true);
            var expectedConnectionString = $"{newConnectionString}Column Encryption Setting=Enabled;";
            Assert.Equal(expectedConnectionString, this.dataAccessSettings.ConnectionSettings.ConnectionString);
        }

        [Fact]
        public void ColumnAlwaysEncryptedSettingEnabledOverride()
        {
            var newConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=OnlineStore;Column Encryption Setting=Disabled;";
            this.sqlConnectionSettings.ConnectionString = newConnectionString;
            this.sqlConnectionSettings.ColumnAlwaysEncryptedSettingEnabled = true;
            this.sqlCmd.ResetHard(true);
            var expectedConnectionString = "Integrated Security=SSPI;Data Source=.;Initial Catalog=OnlineStore;Column Encryption Setting=Enabled;";
            Assert.Equal(expectedConnectionString, this.dataAccessSettings.ConnectionSettings.ConnectionString);
        }

        [Fact]
        public void ChangeConnectionString()
        {
            var newConnectionString = "User Id =ahmad.gad;Password = 123; Data Source=.;Initial Catalog=System;";
            this.sqlCmd.ChangeConnectionString(newConnectionString);
            Assert.Equal(this.dataAccessSettings.ConnectionSettings.ConnectionString, newConnectionString);
        }

        [Fact]
        public void ChangeConnectionStringPlusEncryptedWithoutUpdate()
        {
            var newConnectionString = "User Id =ahmad.gad;Password = 123; Data Source=.;Initial Catalog=System;";
            this.sqlConnectionSettings.Encrypted = true;
            this.sqlCmd.ChangeConnectionString(newConnectionString);
            Assert.Equal(this.dataAccessSettings.ConnectionSettings.ConnectionString, newConnectionString);
        }

        [Fact]
        public void ChangeConnectionStringPlusEncryptedWithUpdate()
        {
            var newConnectionString = "User Id =ahmad.gad;Password = 123; Data Source=.;Initial Catalog=System;";
            this.sqlConnectionSettings.Encrypted = true;
            var expectedConnectionString = "User Id=ahmad.gad;Password=123;Data Source=.;Initial Catalog=System;Encrypt=True;";
            this.sqlCmd.ChangeConnectionString(newConnectionString, true);
            Assert.Equal(expectedConnectionString, this.dataAccessSettings.ConnectionSettings.ConnectionString);
        }
    }
}
