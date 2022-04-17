// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Cryptography.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines all the cryptography members required by the engine.
//  </summary>
// <created>
//      <author>Ahmad Gad (ahmad.gad@DevHorizons.com)</author>
//      <datetime>03/07/2019 07:44 PM</datetime>
// </created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.DAL.Cryptography
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using Cache;
    using Interfaces;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;

    /// <summary>
    ///    A public static class which holds all the public cryptography's extension methods.
    /// </summary>
    /// <Created>
    ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
    ///    <DateTime>11/02/2020 12:41 PM</DateTime>
    /// </Created>
    public static class Cryptography
    {
        #region Public Methods

        /// <summary>
        ///   Encrypt the specified text/string using the Advanced Encryption Standard (AES) cipher with a symmetric key (two way symmetric encryption).
        /// </summary>
        /// <param name="data">The string/text to be encrypted.</param>
        /// <param name="dataAccessSettings">The data settings of the "<c>DAL</c>" engine.</param>
        /// <param name="nonDeterministic">If set to true, each time the same exact source/decrypted data will encryted to a unique value. Which means, you cannot run SQL query on it in the data source itself. The only way to validate it or process it, is to use the "<c>DAL</c>" engine to export and it will automatically decrypt it for you.</param>
        /// <param name="memoryCached">The internal cache container.</param>
        /// <returns>An instance of "<see cref="CryptoResult"/>" which would hold the encrypted data in "<c>Base64</c>" string or the output error details if failed.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static CryptoResult EncryptSymmetric(this string data, IDataAccessSettings dataAccessSettings, bool nonDeterministic, IMemoryCache memoryCached = null)
        {
            var cryptoResult = new CryptoResult();

            if (string.IsNullOrWhiteSpace(data) || string.IsNullOrWhiteSpace(dataAccessSettings?.CryptographySettings?.SymmetricEncryption?.Deterministic?.EncryptionKey) || (nonDeterministic && string.IsNullOrWhiteSpace(dataAccessSettings?.CryptographySettings?.SymmetricEncryption?.Randomized.EncryptionKey)))
            {
                var errMessage = "Failed to encrypt the specified data. The symmetric encryption key is not specified";
                var outputError = dataAccessSettings.CreateErrorDetails(new Exception(errMessage), -6010, errMessage, $"{nameof(EncryptSymmetric)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }

            try
            {
                var encryptor = dataAccessSettings.GetEncryptor(nonDeterministic, memoryCached);

                var dataArray = Encoding.UTF8.GetBytes(data);
                var encryptedDataBytes = encryptor.TransformFinalBlock(dataArray, 0, dataArray.Length);
                if (encryptedDataBytes == null || encryptedDataBytes.Length == 0)
                {
                    var errMessage = "Failed to encrypt the specified data.";
                    var outputError = dataAccessSettings.CreateErrorDetails(new Exception(errMessage), -601, errMessage, $"{nameof(EncryptSymmetric)}");
                    cryptoResult.OutputError = outputError;
                    return cryptoResult;
                }

                var encryptedDataString = Convert.ToBase64String(encryptedDataBytes);
                cryptoResult.Value = encryptedDataString;
                return cryptoResult;
            }
            catch (CryptographicException ex)
            {
                var outputError = dataAccessSettings.CreateErrorDetails(ex, -601, "Failed to encrypt the specified data.", $"{nameof(ToHash)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }
            catch (Exception ex)
            {
                var outputError = dataAccessSettings.CreateErrorDetails(ex, -601, "Failed to encrypt the specified data.", $"{nameof(ToHash)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }
        }

        /// <summary>
        ///   Decrypt the specified a "<c>Base64</c>" text/string using the Advanced Encryption Standard (AES) cipher with a  symmetric key (two way symmetric encryption).
        /// </summary>
        /// <param name="encryptedData">The string/text in <c>Base64</c> string format to be decrypted.</param>
        /// <param name="dataAccessSettings">The data settings of the "<c>DAL</c>" engine.</param>
        /// <param name="nonDeterministic">If set to true, each time the same exact source/decrypted data will encryted to a unique value. Which means, you cannot run SQL query on it in the data source itself. The only way to validate it or process it, is to use the "<c>DAL</c>" engine to export and it will automatically decrypt it for you.</param>
        /// <param name="memoryCached">The internal cache container.</param>
        /// <returns>An instance of "<see cref="CryptoResult"/>" which would hold the decrypted data in "<c>Base64</c>" string or the output error details if failed.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static CryptoResult DecryptSymmetric(this string encryptedData, IDataAccessSettings dataAccessSettings, bool nonDeterministic, IMemoryCache memoryCached = null)
        {
            var cryptoResult = new CryptoResult();

            if (string.IsNullOrWhiteSpace(encryptedData) || string.IsNullOrWhiteSpace(dataAccessSettings?.CryptographySettings?.SymmetricEncryption?.Deterministic?.EncryptionKey) || (nonDeterministic && string.IsNullOrWhiteSpace(dataAccessSettings?.CryptographySettings?.SymmetricEncryption?.Randomized.EncryptionKey)))
            {
                var errMessage = "Failed to decrypt the specified data. The symmetric encryption key is not specified";
                var outputError = dataAccessSettings.CreateErrorDetails(new Exception(errMessage), -6020, errMessage, $"{nameof(DecryptSymmetric)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }

            try
            {
                var decryptor = dataAccessSettings.GetDecryptor(nonDeterministic, memoryCached);
                var encryptedDataBytes = Convert.FromBase64String(encryptedData);
                var decryptedDataBytes = decryptor.TransformFinalBlock(encryptedDataBytes, 0, encryptedDataBytes.Length);

                if (decryptedDataBytes == null || decryptedDataBytes.Length == 0)
                {
                    var errMessage = "Failed to decrypt the specified data.";
                    var outputError = dataAccessSettings.CreateErrorDetails(new Exception(errMessage), -602, errMessage, $"{nameof(DecryptSymmetric)}");
                    cryptoResult.OutputError = outputError;
                    return cryptoResult;
                }

                var decryptedDataString = Encoding.UTF8.GetString(decryptedDataBytes);
                cryptoResult.Value = decryptedDataString;
                return cryptoResult;
            }
            catch (CryptographicException ex)
            {
                var outputError = dataAccessSettings.CreateErrorDetails(ex, -602, "Failed to decrypt the specified data. Please make sure you use the correct symmetric encryption key and the encryption type which bave been used for the encryption.", $"{nameof(ToHash)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }
            catch (Exception ex)
            {
                var outputError = dataAccessSettings.CreateErrorDetails(ex, -602, "Failed to decrypt the specified data. Please make sure you use the correct symmetric encryption key and the encryption type which bave been used for the encryption.", $"{nameof(ToHash)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }
        }

        /// <summary>
        ///   Encrypt the specified text/string with one way (hash salt) encryption using one of the supported "<see cref="KeyDerivationPrf"/>" cryptographic hash function. E.g. "<see cref="KeyDerivationPrf.SHA512"/>".
        ///   <para>The Default Value: <see cref="KeyDerivationPrf.SHA512"/>.</para>
        /// </summary>
        /// <param name="data">The string/text to be encrypted.</param>
        /// <param name="dataAccessSettings">The data settings of the "<c>DAL</c>" engine.</param>
        /// <param name="memoryCached">The internal cache container.</param>
        /// <remarks>The encrypted value cannot be reversed. It is usually used for hashing the passwords.</remarks>
        /// <returns>An instance of "<see cref="CryptoResult"/>" which would hold the hashed data in "<c>Base64</c>" string or the output error details if failed.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        public static CryptoResult ToHash(this string data, IDataAccessSettings dataAccessSettings, IMemoryCache memoryCached = null)
        {
            var cryptoResult = new CryptoResult();
            if (string.IsNullOrWhiteSpace(data) || dataAccessSettings == null || dataAccessSettings.CryptographySettings == null || string.IsNullOrWhiteSpace(dataAccessSettings.CryptographySettings.Hashing.HashKey))
            {
                var errMessage = "Failed to get the hashed data. The hash key is missing";
                var outputError = dataAccessSettings.CreateErrorDetails(new Exception(errMessage), -6030, errMessage, $"{nameof(ToHash)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }

            try
            {
                var salt = GetHashSaltKey(dataAccessSettings, memoryCached);

                var hashedDataBytes = KeyDerivation.Pbkdf2(
                    password: data,
                    salt: salt,
                    prf: (Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf)dataAccessSettings.CryptographySettings.Hashing.KeyDerivationPrf,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8);

                if (hashedDataBytes == null || hashedDataBytes.Length == 0)
                {
                    var errMessage = "Failed to get the hashed data.";
                    var outputError = dataAccessSettings.CreateErrorDetails(new Exception(errMessage), -603, errMessage, $"{nameof(ToHash)}");
                    cryptoResult.OutputError = outputError;
                    return cryptoResult;
                }

                var hashedData = Convert.ToBase64String(hashedDataBytes);
                cryptoResult.Value = hashedData;
                return cryptoResult;
            }
            catch (CryptographicException ex)
            {
                var outputError = dataAccessSettings.CreateErrorDetails(ex, -603, "Failed to get the hashed data.", $"{nameof(ToHash)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }
            catch (Exception ex)
            {
                var outputError = dataAccessSettings.CreateErrorDetails(ex, -603, "Failed to get the hashed data.", $"{nameof(ToHash)}");
                cryptoResult.OutputError = outputError;
                return cryptoResult;
            }
        }
        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///    Generate the hashed symmetric encryption key and the <c>IV</c> hashed key from the specified symmetric key string and assign them to the specified "<see cref="Aes"/>" object.
        /// </summary>
        /// <param name="symmetricAlgorithm">The symmetric algorithm which could be for example type of "<see cref="Aes"/>".</param>
        /// <param name="cryptographySettings">The cryptography settings.</param>
        /// <param name="nonDeterministic">If set to true, each time the same exact source/decrypted data will encryted to a unique value. Which means, you cannot run SQL query on it in the data source itself. The only way to validate it or process it, is to use the "<c>DAL</c>" engine to export and it will automatically decrypt it for you.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static void AssignKeys(this SymmetricAlgorithm symmetricAlgorithm, CryptographySettings cryptographySettings, bool nonDeterministic)
        {
            var enc = Encoding.UTF8;
            var crypto = cryptographySettings?.HashAlgorithm ?? SHA512.Create();

            var maxBitKeySize = symmetricAlgorithm.LegalKeySizes.Max(key => key.MaxSize);
            var maxBitBlockSize = symmetricAlgorithm.LegalBlockSizes.Max(key => key.MaxSize);
            var symmetricEncKey = nonDeterministic ? cryptographySettings.SymmetricEncryption.Randomized.EncryptionKey : cryptographySettings.SymmetricEncryption.Deterministic.EncryptionKey;
            var hashKey = symmetricEncKey.GetHashKey(crypto, maxBitKeySize / 8);
            var hashIV = symmetricEncKey.GetHashKey(crypto, maxBitBlockSize / 8);
            symmetricAlgorithm.Key = hashKey;
            symmetricAlgorithm.IV = hashIV;
        }

        /// <summary>
        ///    Generate the hashed key as array of bytes from a plain text key.
        /// </summary>
        /// <param name="key">The plain text key to be hashed.</param>
        /// <param name="crypto">The targeted hash algorithm which implements the "<see cref="HashAlgorithm"/>" abstract class. E.g. "<see cref="SHA256"/>", "<see cref="SHA384"/>", "<see cref="SHA512"/>", etc.</param>
        /// <param name="arraySize">The target key size (array length).</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static byte[] GetHashKey(this string key, HashAlgorithm crypto, int? arraySize = null)
        {
            var enc = Encoding.UTF8;
            var rawKey = enc.GetBytes(key);
            var hashKey = crypto.ComputeHash(rawKey);
            if (arraySize.HasValue && arraySize.Value > 0 && hashKey.Length != arraySize.Value)
            {
                Array.Resize(ref hashKey, arraySize.Value);
            }

            return hashKey;
        }

        /// <summary>
        ///    Gets the designated "<see cref="SymmetricEncryptionSettings.SymmetricAlgorithm"/>" initialized. If not explicitly specified in the specified "<see cref="CryptographySettings"/>", it will be "<see cref="Aes"/>".
        /// </summary>
        /// <param name="cryptographySettings">The cryptography settings.</param>
        /// <param name="nonDeterministic">If set to true, each time the same exact source/decrypted data will encryted to a unique value. Which means, you cannot run SQL query on it in the data source itself. The only way to validate it or process it, is to use the "<c>DAL</c>" engine to export and it will automatically decrypt it for you.</param>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static SymmetricAlgorithm GetTheInitializedSymmetricAlgorithm(this CryptographySettings cryptographySettings, bool nonDeterministic)
        {
            var symmetricAlgorithm = nonDeterministic ? cryptographySettings?.SymmetricEncryption?.Randomized?.SymmetricAlgorithm ?? Aes.Create() : cryptographySettings?.SymmetricEncryption?.Deterministic?.SymmetricAlgorithm ?? Aes.Create();

            symmetricAlgorithm.Mode = CipherMode.CBC;
            if (nonDeterministic)
            {
                symmetricAlgorithm.Padding = PaddingMode.ISO10126;
            }

            symmetricAlgorithm.AssignKeys(cryptographySettings, nonDeterministic);
            return symmetricAlgorithm;
        }

        /// <summary>
        ///    Gets the initialized symmetric encryptor object with the current "<see cref="SymmetricAlgorithm.Key"/>" and the "<see cref="SymmetricAlgorithm.IV"/>" pre embedded/configured.
        /// </summary>
        /// <param name="dataAccessSettings">The data settings of the "<c>DAL</c>" engine.</param>
        /// <param name="nonDeterministic">If set to true, each time the same exact source/decrypted data will encryted to a unique value. Which means, you cannot run SQL query on it in the data source itself. The only way to validate it or process it, is to use the "<c>DAL</c>" engine to export and it will automatically decrypt it for you.</param>
        /// <param name="memoryCached">The internal cache container.</param>
        /// <returns>The decrypted data.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static ICryptoTransform GetEncryptor(this IDataAccessSettings dataAccessSettings, bool nonDeterministic, IMemoryCache memoryCached = null)
        {
            if (nonDeterministic && memoryCached?.RandomizedEncryptor != null)
            {
                return memoryCached.RandomizedEncryptor;
            }
            else if (memoryCached?.DeterministicEncryptor != null)
            {
                return memoryCached.DeterministicEncryptor;
            }

            var before = GC.GetTotalMemory(false);
            var symmetricAlgorithm = dataAccessSettings?.CryptographySettings?.GetTheInitializedSymmetricAlgorithm(nonDeterministic);
            var encryptor = symmetricAlgorithm.CreateEncryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

            if (memoryCached != null && !dataAccessSettings.CacheSettings.Disable && !dataAccessSettings.CryptographySettings.DisableCaching)
            {
                memoryCached.DeterministicEncryptor = encryptor;
                var after = GC.GetTotalMemory(false);
                var size = after - before;
                memoryCached.FirstLevelCacheMemorySize += size;
            }

            return encryptor;
        }

        /// <summary>
        ///    Gets the initialized symmetric decryptor object with the current "<see cref="SymmetricAlgorithm.Key"/>" and the "<see cref="SymmetricAlgorithm.IV"/>" pre embedded/configured.
        /// </summary>
        /// <param name="dataAccessSettings">The data settings of the "<c>DAL</c>" engine.</param>
        /// <param name="nonDeterministic">If set to true, each time the same exact source/decrypted data will encryted to a unique value. Which means, you cannot run SQL query on it in the data source itself. The only way to validate it or process it, is to use the "<c>DAL</c>" engine to export and it will automatically decrypt it for you.</param>
        /// <param name="memoryCached">The internal cache container.</param>
        /// <returns>The decrypted data.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static ICryptoTransform GetDecryptor(this IDataAccessSettings dataAccessSettings, bool nonDeterministic, IMemoryCache memoryCached = null)
        {
            if (nonDeterministic && memoryCached?.RandomizedDecryptor != null)
            {
                return memoryCached.RandomizedDecryptor;
            }
            else if (memoryCached?.DeterministicDecryptor != null)
            {
                return memoryCached.DeterministicDecryptor;
            }

            var before = GC.GetAllocatedBytesForCurrentThread();
            var symmetricAlgorithm = dataAccessSettings?.CryptographySettings?.GetTheInitializedSymmetricAlgorithm(nonDeterministic);
            var decryptor = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);

            if (memoryCached != null && !dataAccessSettings.CacheSettings.Disable && !dataAccessSettings.CryptographySettings.DisableCaching)
            {
                memoryCached.DeterministicDecryptor = decryptor;
                var after = GC.GetAllocatedBytesForCurrentThread();
                var size = after - before;
                memoryCached.FirstLevelCacheMemorySize += size;
            }

            return decryptor;
        }

        /// <summary>
        ///    The internal transformed hash salt key which is required for the cryptography hashing operations for the designated sensitive/private data like the passwords.
        /// </summary>
        /// <param name="dataAccessSettings">The data settings of the "<c>DAL</c>" engine.</param>
        /// <param name="memoryCached">The internal cache container.</param>
        /// <remarks>The encrypted value cannot be reversed. It is usually used for hashing the passwords.</remarks>
        /// <returns>The hashed data in "<c>Base64</c>" string.</returns>
        /// <Created>
        ///    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
        ///    <DateTime>11/02/2020 10:44 AM</DateTime>
        /// </Created>
        private static byte[] GetHashSaltKey(IDataAccessSettings dataAccessSettings, IMemoryCache memoryCached = null)
        {
            if (memoryCached != null && memoryCached.HashSaltKey != null && memoryCached.HashSaltKey.Length > 0)
            {
                return memoryCached.HashSaltKey;
            }

            var before = GC.GetAllocatedBytesForCurrentThread();
            var cryptographySettings = dataAccessSettings.CryptographySettings;
            var crypto = cryptographySettings.HashAlgorithm ?? SHA512.Create();
            var salt = cryptographySettings.Hashing.HashKey.GetHashKey(crypto);

            if (memoryCached != null && !dataAccessSettings.CacheSettings.Disable && !dataAccessSettings.CryptographySettings.DisableCaching)
            {
                memoryCached.HashSaltKey = salt;
                var after = GC.GetAllocatedBytesForCurrentThread();
                var size = after - before;
                memoryCached.FirstLevelCacheMemorySize += size;
            }

            return salt;
        }
        #endregion Private Methods
    }
}
