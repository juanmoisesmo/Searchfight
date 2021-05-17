using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using Searchfight.ApplicationCore;
using System;
using System.Configuration;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearchFightWithOneWord()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight("typescript");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSearchFightWithTwoWords()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);
            
            var result = logic.ProcessSearchFight("java .net");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSearchFightWithThreeWords()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight("java .net angular");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSarchFightWithOneSpecialChars()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight("@ + #");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSearchFightWordWithSpaceAndDoubleQuote()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);
            
            var result = logic.ProcessSearchFight("\"java script\"");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSarchFightWithOneSpecialCharsAndDoubleQuote()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight("\"@\"");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSearchFightWordWithSpaceAndSingleQuote()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight("\'java script\'");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSarchFightWithOneSpecialCharsAndSingleQuote()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight("\'@\'");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSearchFightWithSpaceWithOutWord()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight(" ");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestSearchFightWithSpaceWithOutWordWithDoubleQuotes()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "App.config" };
            Configuration configSource = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            ISearchEngineLogic logic = new SearchEngineLogic(configSource);

            var result = logic.ProcessSearchFight("\" \"");

            Console.WriteLine(result);

            Assert.IsTrue(!string.IsNullOrEmpty(result));
        }

    }
}
