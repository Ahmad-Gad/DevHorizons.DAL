namespace DevHorizons.DAL.Sql.Test
{
    using System;
    using System.Data.Common;
    using DAL.Cache;
    using DAL.Cryptography;
    using Sql;

    public class TestBase
    {
        protected readonly DataAccessSettings dataAccessSettings;
        protected readonly SqlCommand dalCmd;
        protected readonly Microsoft.Data.SqlClient.SqlCommand internalCmdObject;
        protected readonly SqlConnectionSettings sqlConnectionSettings;
        protected readonly IMemoryCache memoryCache = new MemoryCache();
        protected const string INITIALCONNECTIONSTRING = "Integrated Security=SSPI; Data Source=.;Initial Catalog=OnlineStore;";

        public TestBase():
            this(null)
        {

        }

        public TestBase(string connectionString)
        {
            this.sqlConnectionSettings = new SqlConnectionSettings
            {
                ConnectionString = connectionString ?? INITIALCONNECTIONSTRING
            };

            var cryptographySettings = new CryptographySettings
            {
                SymmetricEncryption = new SymmetricEncryption
                {
                    DefaultEncryptionType = EncryptionType.Deterministic,
                    Deterministic = new SymmetricEncryptionSettings
                    {
                        EncryptionKey = "P@$$word"
                    },
                    Randomized = new SymmetricEncryptionSettings
                    {
                        EncryptionKey = "P@$$word"
                    }
                },
                Hashing = new HashingSettings
                {
                    HashKey = "123456"
                }
            };

            this.dataAccessSettings = new DataAccessSettings
            {
                ConnectionSettings = this.sqlConnectionSettings,
                CryptographySettings = cryptographySettings,
            };

            try
            {
                this.dalCmd = new SqlCommand(this.dataAccessSettings, this.memoryCache);
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

        public TestBase(string connectionString , IMemoryCache memoryCache)
            :this(connectionString)
        {
            this.memoryCache = memoryCache;
        }

    }
}
