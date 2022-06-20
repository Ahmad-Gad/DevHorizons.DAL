
namespace DevHorizons.DAL.Sql.Test.Cryptography
{
    using System.Security.Cryptography;
    using DAL.Cache;
    using DAL.Cryptography;

    using Xunit;
    public class CryptographyTest : TestBase
    {
        public CryptographyTest()
            : base(null, new MemoryCache())
        {
        }

        [Fact]
        public void TestDefaultCryptographySettingsValues()
        {
            if (this.GetType().BaseType != typeof(TestBase))
            {
                return;
            }

            Assert.False(this.dataAccessSettings.CacheSettings.Disabled);
            Assert.False(this.dataAccessSettings.CryptographySettings.DisableCaching);

            Assert.Equal(KeyDerivationPrf.SHA512, this.dataAccessSettings.CryptographySettings.Hashing.KeyDerivationPrf);
            Assert.Equal(EncryptionType.Deterministic, this.dataAccessSettings.CryptographySettings.SymmetricEncryption.DefaultEncryptionType);


            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm is SymmetricAlgorithm);
            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm is Aes);

            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Randomized.SymmetricAlgorithm is SymmetricAlgorithm);
            Assert.True(this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Randomized.SymmetricAlgorithm is Aes);
        }

        [Fact]
        public void TestHash()
        {
            this.dataAccessSettings.CryptographySettings.Hashing.HashKey = "123456";
            this.dataAccessSettings.CryptographySettings.Hashing.KeyDerivationPrf = KeyDerivationPrf.SHA512;

            var password = "MyPassword123";
            Assert.Null(this.memoryCache.HashSaltKey);
            var hashedPassword1 = password.ToHash(this.dataAccessSettings, this.memoryCache);
            Assert.NotNull(hashedPassword1);
            Assert.Null(hashedPassword1.OutputError);
            Assert.NotNull(hashedPassword1.Value);
            Assert.NotEqual(password, hashedPassword1.Value);
            Assert.Equal("8dGDJnAMhE9kGry0aJrVXXbyD6g3QrnwJHCUzlu0vyg=", hashedPassword1.Value);

            if (!this.dataAccessSettings.CacheSettings.Disabled && !this.dataAccessSettings.CryptographySettings.DisableCaching)
            {
                Assert.NotNull(this.memoryCache.HashSaltKey);
            }
            else
            {
                Assert.Null(this.memoryCache.HashSaltKey);
            }

            var hashedPassword2 = password.ToHash(this.dataAccessSettings, this.memoryCache);
            Assert.NotNull(hashedPassword2);
            Assert.Null(hashedPassword2.OutputError);
            Assert.NotNull(hashedPassword2.Value);



            Assert.Equal(hashedPassword1.Value, hashedPassword2.Value);
        }

        [Fact]
        public void TestSymmetricDeterministicEncryption()
        {
            var randamized = false;
            var name = "Ahmad Gad";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.EncryptionKey = "P@$$word";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Deterministic.SymmetricAlgorithm = Aes.Create();
            Assert.Null(this.memoryCache.DeterministicEncryptor);
            Assert.Null(this.memoryCache.DeterministicDecryptor);
            Assert.Null(this.memoryCache.RandomizedEncryptor);
            Assert.Null(this.memoryCache.RandomizedDecryptor);
            var encryptedName1 = name.EncryptSymmetric(this.dataAccessSettings, randamized, this.memoryCache);
            Assert.NotNull(encryptedName1);
            Assert.Null(encryptedName1.OutputError);
            Assert.NotNull(encryptedName1.Value);
            Assert.NotEqual(name, encryptedName1.Value);
            Assert.Equal("BiKC78MjjD0am67HBhk+Ew==", encryptedName1.Value);

            if (!this.dataAccessSettings.CacheSettings.Disabled && !this.dataAccessSettings.CryptographySettings.DisableCaching)
            {
                Assert.NotNull(this.memoryCache.DeterministicEncryptor);
                Assert.Null(this.memoryCache.DeterministicDecryptor);
                Assert.Null(this.memoryCache.RandomizedEncryptor);
                Assert.Null(this.memoryCache.RandomizedDecryptor);
            }
            else
            {
                Assert.Null(this.memoryCache.DeterministicEncryptor);
                Assert.Null(this.memoryCache.DeterministicDecryptor);
                Assert.Null(this.memoryCache.RandomizedEncryptor);
                Assert.Null(this.memoryCache.RandomizedDecryptor);
            }

            var encryptedName2 = name.EncryptSymmetric(this.dataAccessSettings, randamized, this.memoryCache);
            Assert.NotNull(encryptedName2);
            Assert.Null(encryptedName2.OutputError);
            Assert.NotNull(encryptedName2.Value);
            Assert.Equal(encryptedName2.Value, encryptedName1.Value);

            var decryptedName = encryptedName1.Value.DecryptSymmetric(this.dataAccessSettings, randamized, this.memoryCache);
            Assert.NotNull(decryptedName);
            Assert.Null(decryptedName.OutputError);
            Assert.NotNull(decryptedName.Value);
            Assert.NotEqual(decryptedName.Value, encryptedName1.Value);
            Assert.Equal(name, decryptedName.Value);
            if (!this.dataAccessSettings.CacheSettings.Disabled && !this.dataAccessSettings.CryptographySettings.DisableCaching)
            {
                Assert.NotNull(this.memoryCache.DeterministicEncryptor);
                Assert.NotNull(this.memoryCache.DeterministicDecryptor);
                Assert.Null(this.memoryCache.RandomizedEncryptor);
                Assert.Null(this.memoryCache.RandomizedDecryptor);
            }
            else
            {
                Assert.Null(this.memoryCache.DeterministicEncryptor);
                Assert.Null(this.memoryCache.DeterministicDecryptor);
                Assert.Null(this.memoryCache.RandomizedEncryptor);
                Assert.Null(this.memoryCache.RandomizedDecryptor);
            }
        }

        [Fact]
        public void TestSymmetricRandomizedEncryption()
        {
            var randamized = true;
            var name = "Ahmad Gad";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Randomized.EncryptionKey = "P@$$word";
            this.dataAccessSettings.CryptographySettings.SymmetricEncryption.Randomized.SymmetricAlgorithm = Aes.Create();
            Assert.Null(this.memoryCache.DeterministicEncryptor);
            Assert.Null(this.memoryCache.DeterministicDecryptor);
            Assert.Null(this.memoryCache.RandomizedEncryptor);
            Assert.Null(this.memoryCache.RandomizedDecryptor);
            var encryptedName1 = name.EncryptSymmetric(this.dataAccessSettings, randamized, this.memoryCache);
            Assert.NotNull(encryptedName1);
            Assert.Null(encryptedName1.OutputError);
            Assert.NotNull(encryptedName1.Value);
            Assert.NotEqual(name, encryptedName1.Value);

            if (!this.dataAccessSettings.CacheSettings.Disabled && !this.dataAccessSettings.CryptographySettings.DisableCaching)
            {
                Assert.NotNull(this.memoryCache.RandomizedEncryptor);
                Assert.Null(this.memoryCache.RandomizedDecryptor);
                Assert.Null(this.memoryCache.DeterministicEncryptor);
                Assert.Null(this.memoryCache.DeterministicDecryptor);
            }
            else
            {
                Assert.Null(this.memoryCache.DeterministicEncryptor);
                Assert.Null(this.memoryCache.DeterministicDecryptor);
                Assert.Null(this.memoryCache.RandomizedEncryptor);
                Assert.Null(this.memoryCache.RandomizedDecryptor);
            }

            var encryptedName2 = name.EncryptSymmetric(this.dataAccessSettings, randamized, this.memoryCache);
            Assert.NotNull(encryptedName2);
            Assert.Null(encryptedName2.OutputError);
            Assert.NotNull(encryptedName2.Value);
            Assert.NotEqual(encryptedName2.Value, encryptedName1.Value);

            var decryptedName1 = encryptedName1.Value.DecryptSymmetric(this.dataAccessSettings, randamized, this.memoryCache);
            Assert.NotNull(decryptedName1);
            Assert.Null(decryptedName1.OutputError);
            Assert.NotNull(decryptedName1.Value);
            Assert.NotEqual(decryptedName1.Value, encryptedName1.Value);
            Assert.Equal(name, decryptedName1.Value);
            if (!this.dataAccessSettings.CacheSettings.Disabled && !this.dataAccessSettings.CryptographySettings.DisableCaching)
            {
                Assert.NotNull(this.memoryCache.RandomizedEncryptor);
                Assert.NotNull(this.memoryCache.RandomizedDecryptor);
                Assert.Null(this.memoryCache.DeterministicEncryptor);
                Assert.Null(this.memoryCache.DeterministicDecryptor);
            }
            else
            {
                Assert.Null(this.memoryCache.DeterministicEncryptor);
                Assert.Null(this.memoryCache.DeterministicDecryptor);
                Assert.Null(this.memoryCache.RandomizedEncryptor);
                Assert.Null(this.memoryCache.RandomizedDecryptor);
            }

            var decryptedName2 = encryptedName2.Value.DecryptSymmetric(this.dataAccessSettings, randamized, this.memoryCache);
            Assert.NotNull(decryptedName2);
            Assert.Null(decryptedName2.OutputError);
            Assert.NotNull(decryptedName2.Value);
            Assert.NotEqual(decryptedName2.Value, encryptedName2.Value);
            Assert.Equal(name, decryptedName2.Value);
        }
    }
}
