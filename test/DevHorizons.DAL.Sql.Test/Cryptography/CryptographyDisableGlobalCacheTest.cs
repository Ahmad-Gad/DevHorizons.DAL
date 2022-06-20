namespace DevHorizons.DAL.Sql.Test.Cryptography
{
    public class CryptographyDisableGlobalCacheTest : CryptographyTest
    {
        public CryptographyDisableGlobalCacheTest()
        {
            this.dataAccessSettings.CacheSettings.Disabled = true;
        }
    }
}
