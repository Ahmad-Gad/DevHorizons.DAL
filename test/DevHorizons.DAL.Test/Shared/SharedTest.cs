namespace DevHorizons.DAL.Test.Shared
{
    using System;
    using System.Collections.Generic;
    using DAL.Shared;
    using Newtonsoft.Json;
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

        [Fact]
        public void TestBinaryConvertion()
        {
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Ahmad",
                LastName = "Gad",
                DateOfBirth = DateTime.Now,
                Salary = 10
            };

            var binaryEmployee = employee.ToBinary();
            Assert.NotNull(binaryEmployee);
            Assert.True(binaryEmployee.Length > 0);

            var deserializedEmployee = binaryEmployee.FromBinary<Employee>();
            Assert.NotNull(deserializedEmployee);

            Assert.Equal(JsonConvert.SerializeObject(employee), JsonConvert.SerializeObject(deserializedEmployee));
        }

        [Fact]
        public void TestObject2Base64Serialization()
        {
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Ahmad",
                LastName = "Gad",
                DateOfBirth = DateTime.Now,
                Salary = 10
            };

            var base64Result = employee.ToBase64String();
            Assert.NotNull(base64Result);
            Assert.True(base64Result.Length > 0);

            var deserializedEmployee = base64Result.FromBase64String<Employee>();
            Assert.NotNull(deserializedEmployee);

            Assert.Equal(JsonConvert.SerializeObject(employee), JsonConvert.SerializeObject(deserializedEmployee));
        }
    }
}
