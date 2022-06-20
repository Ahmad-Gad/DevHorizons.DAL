namespace DevHorizons.DAL.Sql.Test.Cryptography
{
    public class CryptographyNoCryptoCacheTest : CryptographyTest
    {
        public CryptographyNoCryptoCacheTest()
        {
            this.dataAccessSettings.CryptographySettings.DisableCaching = true;
        }
    }
}
