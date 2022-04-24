namespace DevHorizons.DAL.Test.Shared
{
    using System.Collections.Generic;
    using DAL.Shared;
    using Xunit;

    public class SharedTest
    {
        [Fact]
        public void CompareTwoIdenticalDictionaries()
        {
            var sourceDictionary = new Dictionary<string, string>()
            {
                { "Integrated Security", "SSPI" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            var comparerDictionary = new Dictionary<string, string>()
            {
                { "Integrated Security", "SSPI" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            Assert.True(sourceDictionary.Compare(comparerDictionary));
        }

        [Fact]
        public void CompareTwoNonIdenticalDictionariesValues()
        {
            var sourceDictionary = new Dictionary<string, string>()
            {
                { "Integrated Security", "SSPI" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            var comparerDictionary = new Dictionary<string, string>()
            {
                { "Integrated Security", "sspi" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            Assert.False(sourceDictionary.Compare(comparerDictionary));
        }

        [Fact]
        public void CompareTwoNonIdenticalDictionariesKeys()
        {
            var sourceDictionary = new Dictionary<string, string>()
            {
                { "Integrated Security", "SSPI" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            var comparerDictionary = new Dictionary<string, string>()
            {
                { "Integrated security", "SSPI" },
                { "Data Source", "." },
                { "Initial Catalog", "System" }
            };

            Assert.False(sourceDictionary.Compare(comparerDictionary));
        }
    }
}
