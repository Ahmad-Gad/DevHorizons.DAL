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
        public void BinaryConvertion()
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
        public void Object2Base64Serialization()
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

        [Fact]
        public void String2Base64Encoding()
        {
            var name = "Ahmad Gad";
            var base64Result = name.ToBase64String();
            Assert.NotNull(base64Result);
            Assert.True(base64Result.Length > 0);

            var decodedString = base64Result.FromBase64String();
            Assert.NotNull(decodedString);

            Assert.Equal(name, decodedString);
        }

        [Fact]
        public void Base64ToBinary()
        {
            var str = "Hello World";
            var base64String = str.ToBase64String();

            Assert.NotNull(base64String);
            Assert.True(base64String.Length > 0);
            Assert.NotNull(Convert.FromBase64String(base64String));

            var binary = base64String.ToBinary();
            Assert.NotNull(binary);
            Assert.True(binary.Length > 0);
            Assert.NotNull(Convert.ToBase64String(binary));

            var base64StringBack = binary.ToBase64String();
            Assert.NotNull(binary);
            Assert.True(base64StringBack.Length > 0);
            Assert.Equal(base64StringBack, base64String);

        }

        [Fact]
        public void TestResetModeFlags()
        {
            var resetParameters = ResetMode.ResetParameters;
            var resetWarnings = ResetMode.ResetWarnings;
            var resetErrors = ResetMode.ResetErrors;
            var resetCommandName = ResetMode.ResetCommandName;
            var resetTransactions = ResetMode.ResetTransaction;
            var resetFull = ResetMode.Full;
            var resetHard = ResetMode.Hard;
            var resetHardRefresh = ResetMode.HardRefresh;
            var resetFullFlags = ResetMode.ResetParameters | ResetMode.ResetWarnings | ResetMode.ResetErrors | ResetMode.ResetCommandName | ResetMode.ResetTransaction;
            var enumIntValue = (int)resetParameters + (int)resetWarnings + (int)resetErrors + (int)resetCommandName + (int)resetTransactions;
            Assert.Equal(31, enumIntValue);
            Assert.Equal(31, (int)resetFullFlags);
            Assert.Equal(resetFull, resetFullFlags);
            Assert.Equal(enumIntValue, (int)resetFull);

            Assert.True((resetFullFlags & ResetMode.ResetErrors) == ResetMode.ResetErrors);
            Assert.True((resetCommandName & ResetMode.ResetErrors) != ResetMode.ResetErrors);
            Assert.True((resetCommandName & ResetMode.ResetErrors) != ResetMode.ResetCommandName);
            Assert.True((resetHard & ResetMode.Hard) == ResetMode.Hard);
            Assert.True((resetHard & ResetMode.ResetErrors) == ResetMode.ResetErrors);
            Assert.True((resetHardRefresh & ResetMode.Hard) == ResetMode.Hard);
            Assert.True((resetHardRefresh & ResetMode.HardRefresh) == ResetMode.HardRefresh);
            Assert.True((resetHard & ResetMode.Hard) != ResetMode.HardRefresh);
            Assert.True(resetFullFlags  == ResetMode.Full);
            Assert.True(resetFullFlags < ResetMode.Hard);
            Assert.True(ResetMode.Hard < ResetMode.HardRefresh);
            Assert.True(resetFullFlags < ResetMode.HardRefresh);
        }
    }
}
