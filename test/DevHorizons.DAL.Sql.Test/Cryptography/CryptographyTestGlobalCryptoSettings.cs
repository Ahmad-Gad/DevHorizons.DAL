
namespace DevHorizons.DAL.Sql.Test.Cryptography
{
    using System.Security.Cryptography;
    using DAL.Cache;
    using DAL.Cryptography;

    using Xunit;
    public class CryptographyTestGlobalCryptoSettings : TestBase
    {
        public CryptographyTestGlobalCryptoSettings()
            : base(null, new MemoryCache())
        {
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType = EncryptionType.Randomized;
        }

        [Fact]
        public void TestDefaultCryptographySettingsValues()
        {
            Assert.False(this.dataAccessSettings.CacheSettings.Disabled);
            Assert.False(this.dataAccessSettings.CryptographySettings.DisableCaching);

            Assert.Equal(KeyDerivationPrf.SHA512, this.dataAccessSettings.CryptographySettings.Hashing.KeyDerivationPrf);
            Assert.Equal(EncryptionType.Randomized, this.dataAccessSettings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType);

            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm is SymmetricAlgorithm);
            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm is Aes);

            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Randomized.SymmetricAlgorithm is SymmetricAlgorithm);
            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Randomized.SymmetricAlgorithm is Aes);
        }

        [Fact]
        public void RandomizedExplicitEncryptionParameter()
        {
            var name = "Ahmad Gad";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.EncryptionKey = "P@$$word";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm = Aes.Create();
            var parName = "Password";
            var parValue = name;
            var par = new SqlParameter(parName, parValue);
            par.Encrypted = true;
            par.EncryptionType = EncryptionType.Randomized;
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];

            Assert.NotNull(sqlParameter.Value);
            Assert.True(sqlParameter.Value.ToString().Length != 0);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(sqlParameter.Value.ToString().Length, sqlParameter.Size);
            var decryptedName = sqlParameter.Value.ToString().DecryptSymmetric(this.dataAccessSettings, EncryptionType.Randomized);
            Assert.NotNull(decryptedName);
            Assert.Null(decryptedName.OutputError);
            Assert.NotNull(decryptedName.Value);
            Assert.Equal(name, decryptedName.Value);
        }

        [Fact]
        public void RandomizedDefaultEncryptionParameter()
        {
            var name = "Ahmad Gad";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.EncryptionKey = "P@$$word";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm = Aes.Create();
            var parName = "Password";
            var parValue = name;
            var par = new SqlParameter(parName, parValue);
            par.Encrypted = true;
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];

            Assert.NotNull(sqlParameter.Value);
            Assert.True(sqlParameter.Value.ToString().Length != 0);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(sqlParameter.Value.ToString().Length, sqlParameter.Size);
            var decryptedName = sqlParameter.Value.ToString().DecryptSymmetric(this.dataAccessSettings, EncryptionType.Randomized);
            Assert.NotNull(decryptedName);
            Assert.Null(decryptedName.OutputError);
            Assert.NotNull(decryptedName.Value);
            Assert.Equal(name, decryptedName.Value);
        }

        [Fact]
        public void DeterministicExplicitEncryptionParameter()
        {
            var name = "Ahmad Gad";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.EncryptionKey = "P@$$word";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm = Aes.Create();
            var parName = "Password";
            var parValue = name;
            var par = new SqlParameter(parName, parValue);
            par.Encrypted = true;
            par.EncryptionType = EncryptionType.Deterministic;
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter.Value);
            //9mRRGsBB7G2p9LCfCc5oZQ==
            Assert.True(sqlParameter.Value.ToString().Length != 0);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(sqlParameter.Value.ToString().Length, sqlParameter.Size);
            Assert.Equal("BiKC78MjjD0am67HBhk+Ew==", sqlParameter.Value.ToString());
        }
    }
}
