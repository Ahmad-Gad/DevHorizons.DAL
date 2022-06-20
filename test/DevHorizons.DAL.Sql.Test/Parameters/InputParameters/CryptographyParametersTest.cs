namespace DevHorizons.DAL.Sql.Test.Parameters.InputParameters
{
    using System.Security.Cryptography;
    using DAL.Cryptography;
    using Sql;
    using Xunit;

    public class CryptographyParametersTest : TestBase
    {
        [Fact]
        public void HashedParameter()
        {
            this.dataAccessSettings.CryptographySettings.Hashing.HashKey = "123456";
            this.dataAccessSettings.CryptographySettings.Hashing.KeyDerivationPrf = KeyDerivationPrf.SHA512;
            var password = "MyPassword123";

            var parName = "Password";
            var parValue = password;
            var par = new SqlParameter(parName, parValue);
            par.Hashed = true;
            dalCmd.AddParameter(par);
            Assert.NotNull(internalCmdObject.Parameters);
            Assert.NotEmpty(internalCmdObject.Parameters);
            var sqlParameter = internalCmdObject.Parameters[0];
            Assert.NotNull(sqlParameter.Value);
            Assert.True(sqlParameter.Value.ToString().Length != 0);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(sqlParameter.Value.ToString().Length, sqlParameter.Size);
            Assert.Equal("8dGDJnAMhE9kGry0aJrVXXbyD6g3QrnwJHCUzlu0vyg=", sqlParameter.Value.ToString());
        }

        [Fact]
        public void DeterministicDefaultEncryptionParameter()
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
            Assert.Equal("BiKC78MjjD0am67HBhk+Ew==", sqlParameter.Value.ToString());
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
            Assert.True(sqlParameter.Value.ToString().Length != 0);
            Assert.Equal(System.Data.ParameterDirection.Input, sqlParameter.Direction);
            Assert.Equal(System.Data.SqlDbType.NVarChar, sqlParameter.SqlDbType);
            Assert.Equal(sqlParameter.Value.ToString().Length, sqlParameter.Size);
            Assert.Equal("BiKC78MjjD0am67HBhk+Ew==", sqlParameter.Value.ToString());
        }

        [Fact]
        public void RandomizedEncryptionParameter()
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
            var decryptedName = sqlParameter.Value.ToString().DecryptSymmetric(this.dataAccessSettings, true);
            Assert.NotNull(decryptedName);
            Assert.Null(decryptedName.OutputError);
            Assert.NotNull(decryptedName.Value);
            Assert.Equal(name, decryptedName.Value);
        }
    }
}
